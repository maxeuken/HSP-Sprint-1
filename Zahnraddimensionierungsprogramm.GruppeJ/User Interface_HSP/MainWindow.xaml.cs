using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace User_Interface_HSP
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
            //Eingangsparameter
            public double m { get; set; }                   //Modul
            public double cf { get; set; }                  //Kopfspielfaktor
            public double d { get; set; }                   //Teilkreisdurchmesser
            public double cos { get; set; }                 //Verzahnungswinkel
            public double vw { get; set; }                  //Verdrehwinkel
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
                z = d / (m / Math.Cos(cos));                      //Zahnzahl
                db = m * z * Math.Cos(vw);                      //Grundkreisdurchmesser (cos(20°)= 0,9397)

            }
            public void Ausgabe()
            {
                c = Math.Round(c, 2);
                h = Math.Round(h, 2);
                hf = Math.Round(hf, 2);
                ha = Math.Round(ha, 2);
                p = Math.Round(p, 2);
                z = Math.Round(z, 0);
                df = Math.Round(df, 2);
                db = Math.Round(db, 2);
                da = Math.Round(da, 2);

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
        



        public MainWindow()
        {
            InitializeComponent();
        }


        public void Bestätigen_BTN_Click(object sender, RoutedEventArgs e)
        {

            //Modul
            m = Convert.ToInt32(Console.ReadLine());
            while (m <= 0)
            {
                Error_txt.Content = "Fehler: Der Modul muss größer als 0 sein. Bitte Eingabe korrigieren";
                m = Convert.ToDouble(m_txt.Text);
            }
            //Kopfspielfaktor
            cf = Convert.ToDouble(Console.ReadLine());
            while ((cf < 0.1) || (cf > 0.3))
            {
                Error_txt.Content = "Fehler: Der Kopfspielfaktor muss zwischen 0.1 und 0.3 liegen. Bitte Eingabe korrigieren";
                cf = Convert.ToDouble(cf_txt.Text);
            }
            //Teilkreisdurchmesser
            d = Convert.ToInt32(Console.ReadLine());
            while (d <= 0)
            {
                Error_txt.Content = "Fehler: Teilkreisdurchmesser muss größer als 0 sein. Bitte Eingabe korrigieren";
                d = Convert.ToDouble(d_txt.Text);
            }
            //Verzahnungwinkel
            vw = Convert.ToInt32(Console.ReadLine());
            while ((vw <= 0) || (vw >= 90))
            {
                Error_txt.Content = "Fehler: Winkel muss zwischen 0 und 90 Grad liegen";
                vw = Convert.ToDouble(vw_txt.Text);
            }

            Berechnung();

            m_aus.Content = m;



        }
    }
}
