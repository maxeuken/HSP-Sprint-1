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
            int Fehler = 0;

            //Parametereingabe mit Wertbegrenzungen
            Console.WriteLine("Eingabe der Zahnradparameter");
            //Modul m
            Console.WriteLine("Zahnradmodul m");
            double m = Convert.ToDouble(Console.ReadLine());
            if (m <= 0)
            { Console.WriteLine("Fehler: Der Modul muss größer als 0 sein"); Fehler = 1; }
            //Kopfspiel c
            Console.WriteLine("Kopfspielfaktor cf");
            Double cf = Convert.ToDouble(Console.ReadLine());
            if ((cf < 0.1) || (cf > 0.3)) 
            { Console.WriteLine("Fehler: Der Kopfspielfaktor muss zwischen 0.1 und 0.3 liegen"); Fehler = 1; }
            //Teilkreisdurchmesser
            Console.WriteLine("Teilkreisdurchmesser d");
            Double d = Convert.ToDouble(Console.ReadLine());
            if (d <= 0)
            { Console.WriteLine("Fehler: Teilkreisdurchmesser muss größer als 0 sein"); Fehler = 1; }

            if (Fehler == 0)
            {
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
                double df = d - 2 * (m + cf);
               

                //Runden der Ergebnisse
                double Zahnhöhe = Math.Round(h, 2);
                double Zahnfußhöhe = Math.Round(hf, 2);
                double Zahnkopfhöhe = Math.Round(ha, 2);
                double Teilung = Math.Round(p, 2);
                double Zahnzahl = Math.Round(z, 0);
                double Fußkreisdurchmesser = Math.Round(df, 2);
                double Kopfspiel = Math.Round(c, 2);

                //Ausgabe
                Console.WriteLine("Kopfspiel c=                 " + Kopfspiel);
                Console.WriteLine("Zahnhöhe h =                 " + Zahnhöhe);
                Console.WriteLine("Zahnfußhöhe hf =             " + Zahnfußhöhe);
                Console.WriteLine("Zahnkopfhöhe ha =            " + Zahnkopfhöhe);
                Console.WriteLine("Teilung p =                  " + Teilung);
                Console.WriteLine("Zahnzahl z=                  " + Zahnzahl);
                Console.WriteLine("Fußkreisdurchmesser df =     " + Fußkreisdurchmesser);
                Console.ReadKey();

            }
            else { Console.WriteLine("Bitte Eingabe überprüfen");
                Console.ReadKey();
            }




        }
    }
}
