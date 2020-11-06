using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahnraddimensionierungsprogramm.GruppeJ
{
    class Program
    {
        static void Main(string[] args)
        {   
            //Parametereingabe mit Wertbegrenzungen
            Console.WriteLine("Eingabe der Zahnradparameter");

            //Modul m
            Console.WriteLine("Zahnradmodul m");
            double m = Convert.ToDouble(Console.ReadLine());
            while (m <= 0)
            { Console.WriteLine("Fehler: Der Modul muss größer als 0 sein. Bitte Eingabe korrigieren");
              m = Convert.ToDouble(Console.ReadLine()); }

            //Kopfspiel c
            Console.WriteLine("Kopfspielfaktor cf");
            Double cf = Convert.ToDouble(Console.ReadLine());
            while ((cf < 0.1) || (cf > 0.3)) 
            { Console.WriteLine("Fehler: Der Kopfspielfaktor muss zwischen 0.1 und 0.3 liegen. Bitte Eingabe korrigieren");
             cf = Convert.ToDouble(Console.ReadLine());}

            //Teilkreisdurchmesser
            Console.WriteLine("Teilkreisdurchmesser d");
            Double d = Convert.ToDouble(Console.ReadLine());
            while (d <= 0)
            { Console.WriteLine("Fehler: Teilkreisdurchmesser muss größer als 0 sein. Bitte Eingabe korrigieren");
              d = Convert.ToDouble(Console.ReadLine());}

                //Berechnungen
                //Kopfspiel
                double c = (cf * m);
                //Zahnhöhe
                double h = 2 * m + c;
                //Zahnfußhöhe
                double hf = m + c;
                //Zahnkopfhöhe
                double ha = m;
                //Teilung
                double p = 3.14 * m;
                //Zahnzahl
                double z = d / m;
                //Fußkreisdurchmesser (Außenverzahnung)
                double df = d - 2 * (m + c);
                //Grundkreisdurchmesser (cos(20°)= 0,9397)
                double db = m * z * 0.9397;

                //Runden der Ergebnisse
                Math.Round(c, 2);
                Math.Round(h, 2);
                Math.Round(hf, 2);
                Math.Round(ha, 2);
                Math.Round(p, 2);
                Math.Round(z, 0);
                Math.Round(df, 2);
                Math.Round(db, 2);

                //Ausgabe
                Console.WriteLine("Kopfspiel c=                 " + c);
                Console.WriteLine("Zahnhöhe h =                 " + h);
                Console.WriteLine("Zahnfußhöhe hf =             " + hf);
                Console.WriteLine("Zahnkopfhöhe ha =            " + ha);
                Console.WriteLine("Teilung p =                  " + p);
                Console.WriteLine("Zahnzahl z=                  " + z);
                Console.WriteLine("Fußkreisdurchmesser df =     " + df);
                Console.WriteLine("Grundkreisdurchmesser db =   " + db);
                Console.ReadKey();


            
           




        }
    }
}
