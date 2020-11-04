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
            if (m <= 0)
            { Console.WriteLine("Fehler: Der Modul muss größer als 0 sein"); }
            //Teilkreisdurchmesser
            Console.WriteLine("Teilkreisdurchmesser d");
            double d = Convert.ToDouble(Console.ReadLine());
            if (d <= 0)
            { Console.WriteLine("Fehler: Der Teilkreisdurchmesser muss größer als 0 sein"); }


            //Einführung der Kopfspielzahl als Konstante
            double Kopfspielzahl = 0.167;


            //Berechnungen:

            //Kopfspiel
            double c = Kopfspielzahl * m;
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
            //Fußkreisdurchmesser
            double df = d - 2 * (m + c);


            //Ausgabe
            Console.WriteLine("Kopfspiel c =                " + c);   
            Console.WriteLine("Zahnhöhe h =                 " + h);
            Console.WriteLine("Zahnfußhöhe hf =             " + hf);
            Console.WriteLine("Zahnkopfhöhe ha =            " + ha);
            Console.WriteLine("Teilung p =                  " + p);
            Console.WriteLine("Zahnzahl z =                  " + z);
            Console.WriteLine("Fußkreisdurchmesser df =     " + df);
            Console.ReadLine();
        }
    }
}
