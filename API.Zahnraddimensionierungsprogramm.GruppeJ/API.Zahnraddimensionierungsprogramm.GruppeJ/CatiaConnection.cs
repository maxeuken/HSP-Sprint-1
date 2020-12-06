using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFITF;
using MECMOD;
using PARTITF;
using System.Windows;
using HybridShapeTypeLib;
using KnowledgewareTypeLib;
using ProductStructureTypeLib;


namespace API.Zahnraddimensionierungsprogramm.GruppeJ
{
    class CatiaConnection
    {
        INFITF.Application hsp_catiaApp;
        MECMOD.PartDocument hsp_catiaPart;
        MECMOD.Sketch hsp_catiaProfil;

        public bool CATIALaeuft()
        {
            try
            {
                object catiaObject = System.Runtime.InteropServices.Marshal.GetActiveObject(
                    "CATIA.Application");
                hsp_catiaApp = (INFITF.Application)catiaObject;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean ErzeugePart()
        {
            INFITF.Documents catDocuments1 = hsp_catiaApp.Documents;
            hsp_catiaPart = catDocuments1.Add("Part") as MECMOD.PartDocument;
            return true;

        }

        public void ErstelleLeereSkizze()
        {
            // geometrisches Set auswaehlen und umbenennen
            HybridBodies catHybridBodies1 = hsp_catiaPart.Part.HybridBodies;
            HybridBody catHybridBody1;
            try
            {
                catHybridBody1 = catHybridBodies1.Item("Geometrisches Set.1");
            }
            catch (Exception)
            {
                MessageBox.Show("Kein geometrisches Set gefunden! " + Environment.NewLine +
                    "Ein PART manuell erzeugen und ein darauf achten, dass 'Geometisches Set' aktiviert ist.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catHybridBody1.set_Name("Profile");
            // neue Skizze im ausgewaehlten geometrischen Set anlegen
            Sketches catSketches1 = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPart.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;
            hsp_catiaProfil = catSketches1.Add(catReference1);

            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        private void ErzeugeAchsensystem()
        {
            object[] arr = new object[] {0.0, 0.0, 0.0,
                                         0.0, 1.0, 0.0,
                                         0.0, 0.0, 1.0 };
            hsp_catiaProfil.SetAbsoluteAxisData(arr);
        }


        //Implementierung der Variablen
        //Eingabewerte
        double x1 = 8;                                                              //X-Koordinate Mittelpunkt 2
        double x2 = 4;                                                              //X-Koordiante Mittelpunkt 1
        double y1 = 16;                                                             //Y-Koordinate Mittelpunkt 1
        double y2 = 8;                                                              //Y-Koordinate Mittelpunkt 2
        double r1;                                                                  //Radius 1
        double r2;                                                                  //Radius 2
        //Ausgabewerte
        double x;
        double y;
        //Berechnungsvariablen 
        double L;
        double h;
        double d;

        public void Mittelpunktbestimmung(Double ew)
        {
            double x = Math.Cos(ew) * 0.94 * d;
            double y = Math.Sin(ew) * 0.94 * d;
        }

        public void ErzeugeZahnradGeometrie(Double z, Double Zahnbreite, Double d, Double da, Double df)
        {
            // Skizze umbenennen
            hsp_catiaProfil.set_Name("Rechteck");

            // ZahnradGeometrie in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            //  erzeugen
            double[] Koordinatenliste = new double[3];
            //Zeile1
            Koordinatenliste[0] = 45;
            Koordinatenliste[0] = 45;
            //Zeile2
            Koordinatenliste[1] = 50;
            Koordinatenliste[1] = 50;
            //Zeile3
            Koordinatenliste[2] = 55;
            Koordinatenliste[2] = 55;

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, df);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(90 / z, da);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(0, df);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(-90 / z, da);

            // dann die Linien
            Circle2D catCircle2D1 = catFactory2D1.CreateCircle(10,20, 3, x, y);
            catCircle2D1.StartPoint = catPoint2D2;
            catCircle2D1.EndPoint = catPoint2D1;
            Circle2D catCircle2D2 = catFactory2D1.CreateCircle(10, 20, 3, x, y);
            catCircle2D2.StartPoint = catPoint2D3;
            catCircle2D2.EndPoint = catPoint2D4;

            Evolventenerzeugung();

            //Kreismuster erzeugen                                                                          (Dokument aus Moodle)
            ShapeFactory SF = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            HybridShapeFactory HSF = (HybridShapeFactory)hsp_catiaPart.Part.HybridShapeFactory;
            Part myPart = hsp_catiaPart.Part;

            Factory2D Factory2D1 = hsp_catiaProfil.Factory2D;
            HybridShapePointCoord Ursprung = HSF.AddNewPointCoord(0, 0, 0);
            Reference RefUrsprung = myPart.CreateReferenceFromObject(Ursprung);
            HybridShapeDirection XDir = HSF.AddNewDirectionByCoord(1, 0, 0);
            Reference RefXDir = myPart.CreateReferenceFromObject(XDir);



            CircPattern Kreismuster = SF.AddNewSurfacicCircPattern(Factory2D1, 1, 2, 0, 0, 1, 1, RefUrsprung, RefXDir, false, 0, true, false);
            Kreismuster.CircularPatternParameters = CatCircularPatternParameters.catInstancesandAngularSpacing;
            AngularRepartition angularRepartition1 = Kreismuster.AngularRepartition;
            Angle angle1 = angularRepartition1.AngularSpacing;
            angle1.Value = Convert.ToDouble(360 / Convert.ToDouble(z));                                   //Zähnezahl
            AngularRepartition angularRepartition2 = Kreismuster.AngularRepartition;
            IntParam intParam1 = angularRepartition2.InstancesCount;
            intParam1.Value = Convert.ToInt32(z) + 1;                                                     //Zähnezahl

            Reference Ref_Kreismuster = myPart.CreateReferenceFromObject(Kreismuster);
            HybridShapeAssemble Verbindung = HSF.AddNewJoin(Ref_Kreismuster, Ref_Kreismuster);
            Reference Ref_Verbindung = myPart.CreateReferenceFromObject(Verbindung);
            HSF.GSMVisibility(Ref_Verbindung, 0); myPart.Update();
            Bodies bodies = myPart.Bodies; Body myBody = bodies.Add();
            myBody.set_Name("Zahnrad"); myBody.InsertHybridShape(Verbindung);
            myPart.Update();

            myPart.InWorkObject = myBody;
            Pad myPad = SF.AddNewPadFromRef(Ref_Verbindung, Zahnbreite);                                  //Zahnbreite prüfen
            myPart.Update();

            // Skizzierer verlassen
            hsp_catiaProfil.CloseEdition();
            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }


        public void ErzeugeBlock(Double Zahnbreite)
        {
            // Hauptkoerper in Bearbeitung definieren
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            // Block erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaProfil, Zahnbreite);                          //Zahnbreite prüfen

            // Block umbenennen
            catPad1.set_Name("Zahnrad");

            // Part aktualisieren
            hsp_catiaPart.Part.Update();
        }

        private void Evolventenerzeugung()
        {
            d = Math.Round(Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)), 0);
            MessageBox.Show("d=" + Convert.ToString(d));
            L = (Math.Pow(r1, 2) + Math.Pow(r2, 2) + Math.Pow(d, 2)) / (2 * d);
            MessageBox.Show("L=" + L);
            h = (Math.Sqrt(Math.Pow(r1, 2) - Math.Pow(r2, 2)));
        }

    }
}
