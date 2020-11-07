﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahnraddimensionierungsprogramm.GruppeJ
{
    public class Zahnrad
    {
        //Eingangsparameter
        public double m { get; set; }       //Modul
        public double cf { get; set; }      //Kopfspielfaktor
        public double d { get; set; }       //Teilkreisdurchmesser
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
            c = m * cf; Math.Round(c, 2);                   //Kopfspiel
            h = 2 * m + c; Math.Round(h, 2);                //Zahnhöhe
            hf = m + c; Math.Round(hf, 2);                  //Zahnfußhöhe
            ha = m; Math.Round(ha, 2);                      //Zahnkopfhöhe
            p = 3.14 * m; Math.Round(p, 2);                 //Teilung
            z = d / m; Math.Round(z, 0);                    //Zahnzahl
            df = d - 2 * (m + c); Math.Round(df, 2);        //Fußkreisdurchmesser (Außenverzahnung)
            db = m * z * 0.9397; Math.Round(db, 2);         //Grundkreisdurchmesser (cos(20°)= 0,9397)
            da = d + 2 * m; Math.Round(da, 2);              //Kopfkreisdurchmesser
        }
        public void Ausgabe()
        {
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
    public class Zahnradaussen
    {
        //Eingangsparameter
        public double m { get; set; }       //Modul
        public double cf { get; set; }      //Kopfspielfaktor
        public double d { get; set; }       //Teilkreisdurchmesser
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
            c = m * cf; Math.Round(c, 2);                   //Kopfspiel
            h = 2 * m + c; Math.Round(h, 2);                //Zahnhöhe
            hf = m + c; Math.Round(hf, 2);                  //Zahnfußhöhe
            ha = m; Math.Round(ha, 2);                      //Zahnkopfhöhe
            p = 3.14 * m; Math.Round(p, 2);                 //Teilung
            z = d / m; Math.Round(z, 0);                    //Zahnzahl
            df = d + 2 * (m + c); Math.Round(df, 2);        //Fußkreisdurchmesser (Innenverzahnung)
            db = m * z * 0.9397; Math.Round(db, 2);         //Grundkreisdurchmesser (cos(20°)= 0,9397)
            da = d - 2 * m; Math.Round(da, 2);              //Kopfkreisdurchmesser
        }
        public void Ausgabe()
        {
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
            Console.WriteLine("Für Aussenverzahnung     1   drücken");
            Console.WriteLine("Für Innenverzahnung      2   drücken");
            Console.WriteLine(" ");
            int Verzahnung = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");
            switch (Verzahnung)
            {
                case 1:
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
                    ZR1.Berechnung();
                    ZR1.Ausgabe();
                    break;
                case 2:
                    Zahnradaussen ZR2 = new Zahnradaussen();
                    //Modul
                    Console.WriteLine("Modul m:");
                    ZR2.m = Convert.ToInt32(Console.ReadLine());
                    while (ZR2.m <= 0)
                    {
                        Console.WriteLine("Fehler: Der Modul muss größer als 0 sein. Bitte Eingabe korrigieren");
                        ZR2.m = Convert.ToDouble(Console.ReadLine());
                    }
                    //Kopfspielfaktor
                    Console.WriteLine("Kopfspielfaktor cf:");
                    ZR2.cf = Convert.ToDouble(Console.ReadLine());
                    while ((ZR2.cf < 0.1) || (ZR2.cf > 0.3))
                    {
                        Console.WriteLine("Fehler: Der Kopfspielfaktor muss zwischen 0.1 und 0.3 liegen. Bitte Eingabe korrigieren");
                        ZR2.cf = Convert.ToDouble(Console.ReadLine());
                    }
                    //Teilkreisdurchmesser
                    Console.WriteLine("Teilkreisdurchmesser");
                    ZR2.d = Convert.ToInt32(Console.ReadLine());
                    while (ZR2.d <= 0)
                    {
                        Console.WriteLine("Fehler: Teilkreisdurchmesser muss größer als 0 sein. Bitte Eingabe korrigieren");
                        ZR2.d = Convert.ToDouble(Console.ReadLine());
                    }

                    ZR2.Berechnung();
                    ZR2.Ausgabe();
                    break;

            }
            Console.ReadKey();
        }








    }
}