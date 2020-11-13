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
        public class Zahnrad
        {
            //Eingangsparameter
            public double m;                                    //Modul
            public double cf;                                   //Kopfspielfaktor
            public double d;                                    //Teilkreisdurchmesser
            public double cos;                                  //Verzahnungswinkel
            public double vw;                                   //Verdrehwinkel
            //Ausgabeparameter
            public double c;
            public double h;
            public double hf;
            public double ha;
            public double p;
            public double z;
            public double df;
            public double db;
            public double da;

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
                z = d / (m / Math.Cos(cos));                    //Zahnzahl
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

            }
        }



        public MainWindow()
        {
            InitializeComponent();
        }

        private void bestätigen_BTN_Click(object sender, RoutedEventArgs e)
        {
            Zahnrad ZR1 = new Zahnrad();

            //Modul
            ZR1.m = Convert.ToDouble(CB1);
            if (ZR1.m <= 1)
            {
                Error_txt.Content = "Error";
               
            }
            //Kopfspielfaktor
            ZR1.cf = Convert.ToDouble(cf_txt.Text);

            //Teilkreisdurchmesser
            ZR1.d = Convert.ToInt32(d_txt.Text);

            //Verzahnungwinkel
            ZR1.vw = Convert.ToInt32(vw_txt.Text);

            ZR1.Ausgabe();
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
         
        }
    }
}
