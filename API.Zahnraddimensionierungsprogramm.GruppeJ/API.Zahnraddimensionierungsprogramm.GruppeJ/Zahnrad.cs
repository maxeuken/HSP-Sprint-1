using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Zahnraddimensionierungsprogramm.GruppeJ
{
    class Zahnrad
    {
        //Eingangsparameter
        public double m;                                                                            //Modul
        public double cf;                                                                           //Kopfspielfaktor(0,1-0,3: häufig 0,167)
        public double d;                                                                            //Teilkreisdurchmesser
        public double sw;                                                                           //Schrägungswinkel (meist zwischen 8° und 25°)
        public double ew;                                                                           //Eingriffswinkel (In der Regel 20°)
                                                                                                    //Ausgabeparameter
        public double drz;                                                                          //Teilkreisdurchmesser nach Rundung von z
        public double c;                                                                            //Kopfspiel
        public double h;                                                                            //Zahnhöhe
        public double hf;                                                                           //Zahnfußhöhe
        public double ha;                                                                           //Zahnkopfhöhe
        public double p;                                                                            //Teilung
        public double z;                                                                            //Zahnzahl
        public double df;                                                                           //Fußkreisdurchmesser
        public double db;                                                                           //Grundkreisdurchmesser
        public double da;                                                                           //Kopfkreisdurchmesser
        public double dm;                                                                           //Mindestaußendurchmesser Hohlrad
        public double mt;                                                                           //Stirnmodul
        public double pt;                                                                           //Stirnteilung
        public double alphat;                                                                       //Stirneingriffswinkel
        public int Verzahnung = 0;
        public double Zahnbreite;                                                                   //Zahnbreite
        public double BD;                                                                           //Bohrungsdurchmesser
        public double A;                                                                            //Fläche
        public double V;                                                                            //Volumen
        public string Material;                                                                     //Zahnradmaterial
        public double MTL_hlp;                                                                      //Dichte
        public double Masse;                                                                        //Masse
        int dezimal = 2;                                                                            //Rundungsvariable
        public bool Catiakonstruktionserlaubnis;                                                    //Erlaubnis für Catia, 3D zu erzeugen
        public double PassfederBreite;                                                              //Passfedernutbreite
        public double PassfederHöhe;                                                                //Passfederhöhe
        public double BR;                                                                           //Bohrungsradius

        //BERECHNUNGSMETHODEN
        public void Berechnung_geradverzahnt_Außenverzahnung_m_und_d()                            //GERADVERZAHNT-AUßENVERZAHNUNG-M-UND-D
        {
            z = Math.Round((d / m), 0);                                                             //Zahnzahl
            p = Math.Round((Math.PI * m), dezimal);                                                 //Teilung
            c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
            ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
            hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
            h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
            drz = Math.Round((z * m), dezimal);                                                     //Teilkreisdurchmesser nach Rundung von z
            da = Math.Round((drz + 2 * m), dezimal);                                                //Kopfkreisdurchmesser
            df = Math.Round((drz - (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
            db = Math.Round((drz * Math.Cos(ew * (Math.PI / 180))), dezimal);                       //Grundkreisdurchmesser
            A = ((Math.PI * ((da * da) - (BD * BD)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
            V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
            Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            Verzahnung = 0;
            BR = BD / 2;                                                                            //Bohrungsradius
        }
        public void Berechnung_geradverzahnt_Außenverzahnung_m_und_z()                            //GERADVERZAHNT-AUßENVERZAHNUNG-M-UND-Z
        {
            drz = Math.Round((m * z), dezimal);                                                     //Teilkreisdurchmesser
            p = Math.Round((Math.PI * m), dezimal);                                                 //Teilung
            c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
            ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
            hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
            h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
            da = Math.Round((m * (z + 2)), dezimal);                                                //Kopfkreisdurchmesser
            df = Math.Round((drz - (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
            db = Math.Round((drz * Math.Cos(ew * (Math.PI / 180))), dezimal);                       //Grundkreisdurchmesser
            A = ((Math.PI * ((da * da) - (BD * BD)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
            V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
            Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            BR = BD / 2;                                                                            //Bohrungsradius
            Verzahnung = 0;

        }
        public void Berechnung_geradverzahnt_Innenverzahnung_m_und_d()                            //GERADVERZAHNT-INNENVERZAHNUNG-M-UND-D 
        {
            z = Math.Round((d / m), 0);                                                             //Zahnzahl
            p = Math.Round((Math.PI * m), dezimal);                                                 //Teilung
            c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
            ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
            hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
            h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
            drz = Math.Round((z * m), dezimal);                                                     //Teilkreisdurchmesser nach Rundung von z
            da = Math.Round((drz - 2 * m), dezimal);                                                //Kopfkreisdurchmesser
            df = Math.Round((drz + (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
            db = Math.Round((drz * Math.Cos(ew * (Math.PI / 180))), dezimal);                       //Grundkreisdurchmesser
            dm = Math.Round((drz * 1.4), dezimal);                                                  //Mindestaußendurchmesser Hohlrad
            A = ((Math.PI * ((dm * dm) - (da * da)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
            V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
            Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            Verzahnung = 1;
        }
        public void Berechnung_geradverzahnt_Innenverzahnung_m_und_z()                            //GERADVERZAHNT-INNENVERZAHNUNG-M-UND-Z 
        {
            drz = Math.Round((m * z), dezimal);                                                     //Teilkreisdurchmesser
            p = Math.Round((Math.PI * m), dezimal);                                                 //Teilung
            c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
            ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
            hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
            h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
            da = Math.Round((m * (z - 2)), dezimal);                                                //Kopfkreisdurchmesser
            df = Math.Round((drz + (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
            db = Math.Round((drz * Math.Cos(ew * (Math.PI / 180))), dezimal);                       //Grundkreisdurchmesser
            dm = Math.Round((drz * 1.4), dezimal);                                                  //Mindestaußendurchmesser Hohlrad
            A = ((Math.PI * ((dm * dm) - (da * da)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
            V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
            Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            Verzahnung = 1;
        }
        public void Berechnung_schrägverzahnt_Außenverzahnung_m_und_d()                           //SCHRÄGVERZAHNT-AUßENVERZAHNUNG-M-UND-D 
        {
            mt = Math.Round((m / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnmodul
            pt = Math.Round((p / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnteilung
            p = Math.Round(Math.PI * m, dezimal);                                                   //Normalteilung
            z = Math.Round((d / mt), 0);                                                            //Zahnzahl
            c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
            ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
            hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
            h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
            drz = Math.Round((z * m), dezimal);                                                     //Teilkreisdurchmesser nach Rundung von z
            da = Math.Round((drz + 2 * m), dezimal);                                                //Kopfkreisdurchmesser
            df = Math.Round((drz - (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
            alphat = Math.Atan(Math.Tan(ew * (Math.PI / 180)) / Math.Cos(sw * (Math.PI / 180)));    //Stirneingriffswinkel
            db = Math.Round((drz * Math.Cos(alphat)), dezimal);                                     //Grundkreisdurchmesser
            A = ((Math.PI * ((da * da) - (BD * BD)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
            V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
            Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            BR = BD / 2;                                                                            //Bohrungsradius
            Verzahnung = 2;
        }
        public void Berechnung_schrägverzahnt_Außenverzahnung_m_und_z()                           //SCHRÄGVERZAHNT-AUßENVERZAHNUNG-M-UND-Z
        {
            mt = Math.Round((m / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnmodul
            pt = Math.Round((p / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnteilung
            p = Math.Round(Math.PI * m, dezimal);                                                   //Normalteilung
            drz = Math.Round((mt * z), dezimal);                                                    //Teilkreisdurchmesser
            c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
            ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
            hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
            h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
            da = Math.Round((drz + 2 * m), dezimal);                                                //Kopfkreisdurchmesser
            df = Math.Round((drz - (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
            alphat = Math.Atan(Math.Tan(ew * (Math.PI / 180)) / Math.Cos(sw * (Math.PI / 180)));    //Stirneingriffswinkel
            db = Math.Round((drz * Math.Cos(alphat)), dezimal);                                     //Grundkreisdurchmesser
            A = ((Math.PI * ((da * da) - (BD * BD)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
            V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
            Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            BR = BD / 2;                                                                            //Bohrungsradius
            Verzahnung = 2;
        }
        public void Berechnung_schrägverzahnt_Innenverzahnung_m_und_d()                           //SCHRÄGVERZAHNT-INNENVERZAHNUNG-M-UND-D 
        {
            mt = Math.Round((m / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnmodul
            pt = Math.Round((p / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnteilung
            p = Math.Round(Math.PI * m, dezimal);                                                   //Normalteilung
            z = Math.Round((d / mt), 0);                                                            //Zahnzahl
            c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
            ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
            hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
            h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
            drz = Math.Round((z * m), dezimal);                                                     //Teilkreisdurchmesser nach Rundung von z
            da = Math.Round((drz - 2 * m), dezimal);                                                //Kopfkreisdurchmesser
            df = Math.Round((drz + (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
            alphat = Math.Atan((Math.Tan(ew * (Math.PI / 180)) / Math.Cos(sw * (Math.PI / 180))));  //Stirneingriffswinkel
            db = Math.Round((drz * Math.Cos(alphat)), dezimal);                                     //Grundkreisdurchmesser
            dm = Math.Round((drz * 1.4), dezimal);                                                  //Mindestaußendurchmesser Hohlrad
            A = ((Math.PI * ((dm * dm) - (da * da)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
            V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
            Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            Verzahnung = 3;
        }
        public void Berechnung_schrägverzahnt_Innenverzahnung_m_und_z()                           //SCHRÄGVERZAHNT-INNENVERZAHNUNG-M-UND-Z
        {
            mt = Math.Round((m / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnmodul
            pt = Math.Round((p / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnteilung
            p = Math.Round(Math.PI * m, dezimal);                                                   //Normalteilung
            d = Math.Round((mt * z), dezimal);                                                      //Teilkreisdurchmesser
            drz = Math.Round((mt * z), dezimal);                                                    //Teilkreisdurchmesser Rückrechnung
            c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
            ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
            hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
            h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
            da = Math.Round((drz - 2 * m), dezimal);                                                //Kopfkreisdurchmesser
            df = Math.Round((drz + (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
            alphat = Math.Atan((Math.Tan(ew * (Math.PI / 180)) / Math.Cos(sw * (Math.PI / 180))));  //Stirneingriffswinkel
            db = Math.Round((drz * Math.Cos(alphat)), dezimal);                                     //Grundkreisdurchmesser
            dm = Math.Round((drz * 1.4), dezimal);                                                  //Mindestaußendurchmesser Hohlrad
            A = ((Math.PI * ((dm * dm) - (da * da)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
            V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
            Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            Verzahnung = 3;

        }
        public void Passfederberechnung()
        {
            if(BD > 6 && BD <= 8)
            {
                PassfederHöhe = BR + 1;
            }
            if(BD > 8 && BD <= 10)
            {
                PassfederHöhe = BR + 1.4;
            }
            if (BD > 10 && BD <= 12)
            {
                PassfederHöhe = BR + 1.8;
            }
            if (BD > 12 && BD <= 17)
            {
                PassfederHöhe = BR + 2.3;
            }
            if (BD > 17 && BD <= 22)
            {
                PassfederHöhe = BR + 2.8;
            }
            if (BD > 22 && BD <= 44)
            {
                PassfederHöhe = BR + 3.3;
            }
            if (BD > 44 && BD <= 50)
            {
                PassfederHöhe = BR + 3.8;
            }
            if (BD > 50 && BD <= 58)
            {
                PassfederHöhe = BR + 4.3;
            }
            if (BD > 58 && BD <= 65)
            {
                PassfederHöhe = BR + 4.4;
            }
            if (BD > 65 && BD <= 75)
            {
                PassfederHöhe = BR + 4.9;
            }
            if (BD > 75 && BD <= 95)
            {
                PassfederHöhe = BR + 5.4;
            }
            if (BD > 95 && BD <= 110)
            {
                PassfederHöhe = BR + 6.4;
            }
            if (BD > 110 && BD <= 130)
            {
                PassfederHöhe = BR + 7.4;
            }
            if (BD > 130 && BD <= 150)
            {
                PassfederHöhe = BR + 8.4;
            }
            if (BD > 150 && BD <= 170)
            {
                PassfederHöhe = BR + 9.4;
            }
            if (BD > 170)
            {
                PassfederHöhe = BR + 10.4;
            }
            if(BD > 6 && BD <= 8)
            {
                PassfederBreite = 2;
            }
            if(BD > 8 && BD <= 10)
            {
                PassfederBreite = 3;
            }
            if (BD > 10 && BD <= 12)
            {
                PassfederBreite = 4;
            }
            if (BD > 12 && BD <= 17)
            {
                PassfederBreite = 5;
            }
            if (BD > 17 && BD <= 22)
            {
                PassfederBreite = 6;
            }
            if (BD > 22 && BD <= 30)
            {
                PassfederBreite = 8;
            }
            if (BD > 30 && BD <= 38)
            {
                PassfederBreite = 10;
            }
            if (BD > 38 && BD <= 44)
            {
                PassfederBreite = 12;
            }
            if (BD > 44 && BD <= 50)
            {
                PassfederBreite = 14;
            }
            if (BD > 50 && BD <= 58)
            {
                PassfederBreite = 16;
            }
            if (BD > 58 && BD <= 65)
            {
                PassfederBreite = 18;
            }
            if (BD > 65 && BD <= 75)
       
            {
                PassfederBreite = 20;
            }
            if (BD > 75 && BD <= 85)
            {
                PassfederBreite = 22;
            }
            if (BD > 85 && BD <= 95)
            {
                PassfederBreite = 25;
            }
            if (BD > 95 && BD <= 110)
            {
                PassfederBreite = 28;
            }
            if (BD > 110 && BD <= 130)
            {
                PassfederBreite = 32;
            }
            if (BD > 130 && BD <= 150)
            {
                PassfederBreite = 36;
            }
            if (BD > 150 && BD <= 170)
            {
                PassfederBreite = 40;
            }
            if (BD > 170)
            {
                PassfederBreite = 45;
            }

        }

    }
}
