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
            int m = Convert.ToInt32(Console.ReadLine());
            if (m <= 0)
            { Console.WriteLine("Fehler: Parameter muss größer als 0 sein"); Fehler = 1; }
            //Kopfspiel c
            Console.WriteLine("Kopfspielfaktor cf");
            Double cf = Convert.ToDouble(Console.ReadLine());
            if ((cf < 0.1) || (cf > 0.3)) 
            { Console.WriteLine("Fehler: Parameter muss zwischen 0.1 und 0.3 liegen"); Fehler = 1; }
            //Teilkreisdurchmesser
            Console.WriteLine("Teilkreisdurchmesser d");
            Double d = Convert.ToDouble(Console.ReadLine());
            if (d <= 0)
            { Console.WriteLine("Fehler: Teilkreisdurchmesser muss größer als 0 sein"); Fehler = 1; }

            if (Fehler == 0)
            {
                //Berechnungen
                //Zahnhöhe
                double h = 2 * m + cf;
                //Zahnfußhöhe
                double hf = m + cf;
                //Zahnkopfhöhe
                double ha = m;
                //Teilung
                double p = 3.14 * m;
                //Zahnzahl
                double z = d / m;
                //Fußkreisdurchmesser
                double df = d - 2 * (m + cf);
                //Kopfspiel
                Double c = (cf * m);

                //Ausgabe
                Console.WriteLine("Zahnhöhe h =                 " + h);
                Console.WriteLine("Zahnfußhöhe hf =             " + hf);
                Console.WriteLine("Zahnkopfhöhe ha =            " + ha);
                Console.WriteLine("Teilung p =                  " + p);
                Console.WriteLine("Zahnzahl z=                  " + z);
                Console.WriteLine("Fußkreisdurchmesser df =     " + df);
                Console.WriteLine("Kopfspiel c=                 " + c);
                Console.ReadKey();

            }
            else { Console.WriteLine("Bitte Eingabe überprüfen");
                Console.ReadKey();
            }




        }
    }
}
