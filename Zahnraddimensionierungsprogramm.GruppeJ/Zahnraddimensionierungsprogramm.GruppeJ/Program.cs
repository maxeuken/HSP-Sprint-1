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
            Console.WriteLine("Für Aussenverzahnung     1   drücken");
            Console.WriteLine("Für Innenverzahnung      2   drücken");
            Console.WriteLine(" ");
            int Verzahnung = Convert.ToInt32(Console.ReadLine());
            switch (Verzahnung)
            {

                case 1:
                    //Parametereingabe mit Wertbegrenzungen
                    Console.WriteLine(" ");
                    Console.WriteLine("Eingabe der Zahnradparameter");
                    Console.WriteLine(" ");

                    //Modul m
                    Console.WriteLine("Zahnradmodul m");
                    double m = Convert.ToDouble(Console.ReadLine());
                    while (m <= 0)
                    {
                        Console.WriteLine("Fehler: Der Modul muss größer als 0 sein. Bitte Eingabe korrigieren");
                        m = Convert.ToDouble(Console.ReadLine());
                    }

                    //Kopfspiel c
                    Console.WriteLine("Kopfspielfaktor cf");
                    Double cf = Convert.ToDouble(Console.ReadLine());
                    while ((cf < 0.1) || (cf > 0.3))
                    {
                        Console.WriteLine("Fehler: Der Kopfspielfaktor muss zwischen 0.1 und 0.3 liegen. Bitte Eingabe korrigieren");
                        cf = Convert.ToDouble(Console.ReadLine());
                    }

                    //Teilkreisdurchmesser
                    Console.WriteLine("Teilkreisdurchmesser d");
                    Double d = Convert.ToDouble(Console.ReadLine());
                    while (d <= 0)
                    {
                        Console.WriteLine("Fehler: Teilkreisdurchmesser muss größer als 0 sein. Bitte Eingabe korrigieren");
                        d = Convert.ToDouble(Console.ReadLine());
                    }

                    //Berechnungen
                    //Kopfspiel
                    double c = (cf * m); Math.Round(c, 2);
                    //Zahnhöhe
                    double h = 2 * m + c; Math.Round(h, 2);
                    //Zahnfußhöhe
                    double hf = m + c; Math.Round(hf, 2);
                    //Zahnkopfhöhe
                    double ha = m; Math.Round(ha, 2);
                    //Teilung
                    double p = 3.14 * m; Math.Round(p, 2);
                    //Zahnzahl
                    double z = d / m; Math.Round(z, 0);
                    //Fußkreisdurchmesser (Außenverzahnung)
                    double df = d - 2 * (m + c); Math.Round(df, 2);
                    //Grundkreisdurchmesser (cos(20°)= 0,9397)
                    double db = m * z * 0.9397; Math.Round(db, 2);
                    //Kopfkreisdurchmesser
                    double da = d + 2 * m;

                    //Ausgabe
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
                    break;

                case 2:
                    //Parametereingabe mit Wertbegrenzungen
                    Console.WriteLine("Eingabe der Zahnradparameter");
                    Console.WriteLine(" ");

                    //Modul m
                    Console.WriteLine("Zahnradmodul m");
                    m = Convert.ToDouble(Console.ReadLine());
                    while (m <= 0)
                    {
                        Console.WriteLine("Fehler: Der Modul muss größer als 0 sein. Bitte Eingabe korrigieren");
                        m = Convert.ToDouble(Console.ReadLine());
                    }

                    //Kopfspiel c
                    Console.WriteLine("Kopfspielfaktor cf");
                    cf = Convert.ToDouble(Console.ReadLine());
                    while ((cf < 0.1) || (cf > 0.3))
                    {
                        Console.WriteLine("Fehler: Der Kopfspielfaktor muss zwischen 0.1 und 0.3 liegen. Bitte Eingabe korrigieren");
                        cf = Convert.ToDouble(Console.ReadLine());
                    }

                    //Teilkreisdurchmesser
                    Console.WriteLine("Teilkreisdurchmesser d");
                    d = Convert.ToDouble(Console.ReadLine());
                    while (d <= 0)
                    {
                        Console.WriteLine("Fehler: Teilkreisdurchmesser muss größer als 0 sein. Bitte Eingabe korrigieren");
                        d = Convert.ToDouble(Console.ReadLine());
                    }

                    //Berechnungen
                    //Kopfspiel
                    c = (cf * m); Math.Round(c, 2);
                    //Zahnhöhe
                    h = 2 * m + c; Math.Round(h, 2);
                    //Zahnfußhöhe
                    hf = m + c; Math.Round(hf, 2);
                    //Zahnkopfhöhe
                    ha = m; Math.Round(ha, 2);
                    //Teilung
                    p = 3.14 * m; Math.Round(p, 2);
                    //Zahnzahl
                    z = d / m; Math.Round(z, 0);
                    //Fußkreisdurchmesser (Außenverzahnung)
                    df = d - 2 * (m + c); Math.Round(df, 2);
                    //Grundkreisdurchmesser (cos(20°)= 0,9397)
                    db = m * z * 0.9397; Math.Round(db, 2);
                    //Kopfkreisdurchmesser
                    da = d - 2 * m;

                    //Ausgabe
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
                    break;





            }
            int[,] Zahnradwerte = new int[31, 3];
            //Spalte 1
            //HB
            Zahnradwerte[0, 0] = 190;
            Zahnradwerte[1, 0] = 220;
            Zahnradwerte[2, 0] = 150;
            Zahnradwerte[3, 0] = 235;
            Zahnradwerte[4, 0] = 180;
            Zahnradwerte[5, 0] = 240;
            Zahnradwerte[6, 0] = 300;
            Zahnradwerte[7, 0] = 160;
            Zahnradwerte[8, 0] = 180;
            Zahnradwerte[9, 0] = 120;
            Zahnradwerte[10, 0] = 160;
            Zahnradwerte[11, 0] = 190;
            Zahnradwerte[12, 0] = 190;
            Zahnradwerte[13, 0] = 270;
            Zahnradwerte[14, 0] = 300;
            Zahnradwerte[15, 0] = 310;
            Zahnradwerte[16, 0] = 320;
            Zahnradwerte[17, 0] = 350;
            //HRC
            Zahnradwerte[18, 0] = 50;
            Zahnradwerte[19, 0] = 50;
            Zahnradwerte[20, 0] = 50;
            Zahnradwerte[21, 0] = 50;
            Zahnradwerte[22, 0] = 48;
            Zahnradwerte[23, 0] = 48;
            Zahnradwerte[24, 0] = 30;
            Zahnradwerte[25, 0] = 45;
            Zahnradwerte[26, 0] = 55;
            Zahnradwerte[27, 0] = 58;
            Zahnradwerte[26, 0] = 58;
            Zahnradwerte[29, 0] = 58;
            Zahnradwerte[30, 0] = 58;

            Console.WriteLine(" ");
            Console.WriteLine("Bitte Härtewert nach Brinell eingeben");
            Console.WriteLine(" ");
            int Hw = Convert.ToInt32(Console.ReadLine());
            int sort = 0;
            if (Hw > 160 && Hw < 200) { sort = 1; };
            if (Hw > 250 && Hw < 250) { sort = 2; };
            if (Hw > 300 && Hw < 350) { sort = 3; };
            if (Hw > 350) { sort = 4; };
            switch (sort)
            {
                case 1:
                    Console.WriteLine("Vorgeschlagene Werkstoffe:" + Zahnradwerte[5, 0] + Zahnradwerte[9, 0]); 
                    break;
            }

            Console.ReadKey();
        }   

    }
}