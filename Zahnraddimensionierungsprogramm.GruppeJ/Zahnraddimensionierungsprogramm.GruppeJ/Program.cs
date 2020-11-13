using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zahnraddimensionierungsprogramm.GruppeJ
{
    public class Zahnrad
    {
        //Eingangsparameter
        public double m;                                    //Modul
        public double cf;                                   //Kopfspielfaktor
        public double d;                                    //Teilkreisdurchmesser
        public double cos;                                  //Verzahnungswinkel
        public double vw;                                   //Verdrehwinkel
        //Ausgabeparameter
        public double c { get; set; }
        public double h { get; set; }
        public double hf { get; set; }
        public double ha { get; set; }
        public double p { get; set; }
        public double z { get; set; }
        public double df { get; set; }
        public double db { get; set; }
        public double da { get; set; }

        //Methoden
        public void Berechnung()
        {
            c = m * cf;                                     //Kopfspiel
            h = 2 * m + c;                                  //Zahnhöhe
            hf = m + c;                                     //Zahnfußhöhe
            ha = m;                                         //Zahnkopfhöhe
            p = 3.14 * m;                                   //Teilung
            z = d / m;                                      //Zahnzahl
            db = m * z * Math.Cos(vw);                      //Grundkreisdurchmesser
        }
        public void BerechnungSchrägverzahnt()
        {
            c = m * cf;                                     //Kopfspiel
            h = 2 * m + c;                                  //Zahnhöhe
            hf = m + c;                                     //Zahnfußhöhe
            ha = m;                                         //Zahnkopfhöhe
            p = 3.14 * m;                                   //Teilung
            z = d / m;                                      //Zahnzahl
            db = m * z * Math.Cos(vw);                      //Grundkreisdurchmesser

        }
        public void SonderrechnungAussen()
        {
            df = d - 2 * (m + c);                           //Fußkreisdurchmesser
            da = d + 2 * m;                                 //Kopfkreisdurchmesser
        }
        public void SonderrechnungInnen()
        {
            df = d + 2 * (m + c);                           //Fußkreisdurchmesser
            da = d - 2 * m;                                 //Kopfkreisdurchmesser
        }
        public void SonderrechnungSchrägverzahnt() 
        {
            c = m * cf;                                     //Kopfspiel
            h = 2 * m + c;                                  //Zahnhöhe
            hf = m + c;                                     //Zahnfußhöhe
            ha = m;                                         //Zahnkopfhöhe
            p = 3.14 * m;                                   //Teilung
            z = d / (m/Math.Cos(cos));                      //Zahnzahl
            db = m * z * Math.Cos(vw);                      //Grundkreisdurchmesser (cos(20°)= 0,9397)

        }
        public void Ausgabe()
        {
            c = Math.Round(c, 2);
            h = Math.Round(h, 2);
            hf= Math.Round(hf, 2);
            ha= Math.Round(ha, 2);
            p = Math.Round(p, 2);
            z = Math.Round(z, 0);
            df= Math.Round(df, 2);
            db= Math.Round(db, 2);
            da= Math.Round(da, 2);

            Console.WriteLine(" ");
            Console.WriteLine("Kopfspiel c=                 " + c);
            Console.WriteLine("Zahnhöhe h =                 " + h);
            Console.WriteLine("Zahnfußhöhe hf =             " + hf);
            Console.WriteLine("Zahnkopfhöhe ha =            " + ha);
            Console.WriteLine("Teilung p =                  " + p);
            Console.WriteLine("Zahnzahl z=                  " + z);
            Console.WriteLine("Fußkreisdurchmesser df =     " + df);
            Console.WriteLine("Grundkreisdurchmesser db =   " + db);
            Console.WriteLine("Kopfkreisdurchmesser da =    " + da);
        }
    }


    public class Ausführung
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Für Aussenverzahnung         1   drücken");
            Console.WriteLine("Für Innenverzahnung          2   drücken");
            Console.WriteLine("Für Aussenschrägverzahnung   3   drücken");
            Console.WriteLine("Für Innenschrägverzahnung    4   drücken");
            Console.WriteLine(" ");

            int Verzahnung = Convert.ToInt32(Console.ReadLine());
            while ((Verzahnung < 1) || (Verzahnung > 4))
            {
                Console.WriteLine("Fehler: Bitte Eingabe korrigieren");
                Verzahnung = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine(" ");

            Zahnrad ZR1 = new Zahnrad();
            //Modul
            Console.WriteLine("Modul m:");
            ZR1.m = Convert.ToInt32(Console.ReadLine());
            while (ZR1.m <= 0)
            {
                Console.WriteLine("Fehler: Der Modul muss größer als 0 sein. Bitte Eingabe korrigieren");
                ZR1.m = Convert.ToDouble(Console.ReadLine());
            }
            //Kopfspielfaktor
            Console.WriteLine("Kopfspielfaktor cf:");
            ZR1.cf = Convert.ToDouble(Console.ReadLine());
            while ((ZR1.cf < 0.1) || (ZR1.cf > 0.3))
            {
                Console.WriteLine("Fehler: Der Kopfspielfaktor muss zwischen 0.1 und 0.3 liegen. Bitte Eingabe korrigieren");
                ZR1.cf = Convert.ToDouble(Console.ReadLine());
            }
            //Teilkreisdurchmesser
            Console.WriteLine("Teilkreisdurchmesser");
            ZR1.d = Convert.ToInt32(Console.ReadLine());
            while (ZR1.d <= 0)
            {
                Console.WriteLine("Fehler: Teilkreisdurchmesser muss größer als 0 sein. Bitte Eingabe korrigieren");
                ZR1.d = Convert.ToDouble(Console.ReadLine());
            }
            //Verzahnungwinkel
            Console.WriteLine("Verzahnungswinkel");
            ZR1.vw = Convert.ToInt32(Console.ReadLine());
            while ((ZR1.vw <= 0) || (ZR1.vw >= 90))
            {
                Console.WriteLine("Fehler: Winkel muss zwischen 0 und 90 Grad liegen");
                ZR1.vw = Convert.ToDouble(Console.ReadLine());
            }
            if (Verzahnung == 3 || Verzahnung == 4)
            {
                //Schrägungswinkel    
                Console.WriteLine("Schrägungswinkel");
                ZR1.cos = Convert.ToInt32(Console.ReadLine());
                while ((ZR1.cos <= 0) || (ZR1.cos >= 90))
                {
                    Console.WriteLine("Fehler: Winkel muss zwischen 0 und 90 Grad liegen");
                    ZR1.cos = Convert.ToDouble(Console.ReadLine());
                }
            }
            switch (Verzahnung)
            {
                case 1:
                    ZR1.Berechnung();
                    ZR1.SonderrechnungAussen();
                    break;
                case 2:
                    ZR1.Berechnung();
                    ZR1.SonderrechnungInnen();
                    break;
                case 3:
                    ZR1.Berechnung();
                    ZR1.SonderrechnungSchrägverzahnt();
                    ZR1.SonderrechnungAussen();
                    break;
                case 4:
                    ZR1.Berechnung();
                    ZR1.SonderrechnungSchrägverzahnt();
                    ZR1.SonderrechnungInnen();
                    break;
            }
            ZR1.Ausgabe();
            Console.ReadKey();
        }
    }
}