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

        //BERECHNUNGSMETHODEN
        internal void Berechnung_geradverzahnt_Außenverzahnung_m_und_d()                            //GERADVERZAHNT-AUßENVERZAHNUNG-M-UND-D
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
        }
        internal void Berechnung_geradverzahnt_Außenverzahnung_m_und_z()                            //GERADVERZAHNT-AUßENVERZAHNUNG-M-UND-Z
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
        }
        internal void Berechnung_geradverzahnt_Innenverzahnung_m_und_d()                            //GERADVERZAHNT-INNENVERZAHNUNG-M-UND-D 
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
        }
        internal void Berechnung_geradverzahnt_Innenverzahnung_m_und_z()                            //GERADVERZAHNT-INNENVERZAHNUNG-M-UND-Z 
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
        }
        internal void Berechnung_schrägverzahnt_Außenverzahnung_m_und_d()                           //SCHRÄGVERZAHNT-AUßENVERZAHNUNG-M-UND-D 
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
        }
        internal void Berechnung_schrägverzahnt_Außenverzahnung_m_und_z()                           //SCHRÄGVERZAHNT-AUßENVERZAHNUNG-M-UND-Z
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
        }
        internal void Berechnung_schrägverzahnt_Innenverzahnung_m_und_d()                           //SCHRÄGVERZAHNT-INNENVERZAHNUNG-M-UND-D 
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
        }
        internal void Berechnung_schrägverzahnt_Innenverzahnung_m_und_z()                           //SCHRÄGVERZAHNT-INNENVERZAHNUNG-M-UND-Z
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

        }

    }
}
