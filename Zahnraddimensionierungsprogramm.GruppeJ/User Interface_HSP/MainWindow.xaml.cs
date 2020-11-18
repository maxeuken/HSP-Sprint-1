using System;
using System.Windows;


namespace User_Interface_HSP
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private class Zahnrad
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
            public int Verzahnung = 0;

            //Methoden
            internal void Berechnung()
            {
                c = m * cf;                                     //Kopfspiel
                h = 2 * m + c;                                  //Zahnhöhe
                hf = m + c;                                     //Zahnfußhöhe
                ha = m;                                         //Zahnkopfhöhe
                p = 3.14 * m;                                   //Teilung
                z = d / m;                                      //Zahnzahl
                db = m * z * Math.Cos(vw);                      //Grundkreisdurchmesser
            }
            internal void SonderrechnungAussen()
            {
                df = d - 2 * (m + c);                           //Fußkreisdurchmesser
                da = d + 2 * m;                                 //Kopfkreisdurchmesser
            }
            internal void SonderrechnungInnen()
            {
                df = d + 2 * (m + c);                           //Fußkreisdurchmesser
                da = d - 2 * m;                                 //Kopfkreisdurchmesser
            }
            internal void SonderrechnungSchrägverzahnt()
            {
                c = m * cf;                                     //Kopfspiel
                h = 2 * m + c;                                  //Zahnhöhe
                hf = m + c;                                     //Zahnfußhöhe
                ha = m;                                         //Zahnkopfhöhe
                p = 3.14 * m;                                   //Teilung
                z = d / (m / Math.Cos(cos));                    //Zahnzahl
                db = m * z * Math.Cos(vw);                      //Grundkreisdurchmesser (cos(20°)= 0,9397)

            }
            internal void Rundung()
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


        //Bestätigungsbutton Event
        private void bestätigen_BTN_Click(object sender, RoutedEventArgs e)
        {
            Zahnrad ZR1 = new Zahnrad();

            //Modul
            ZR1.m = Convert.ToDouble(Modul_Dropbox.Text);

            //Kopfspielfaktor
            ZR1.cf = Convert.ToDouble(cf_txt.Text);
            if ((ZR1.cf < 0.1) || (ZR1.cf > 0.3))
            {
               MessageBox.Show ("Fehler: Der Kopfspielfaktor muss zwischen 0.1 und 0.3 liegen. Bitte Eingabe korrigieren");
            }

            //Teilkreisdurchmesser
            ZR1.d = Convert.ToInt32(d_txt.Text);
            if (ZR1.d == 0) 
            {
                MessageBox.Show("Fehler: Teilkreisdurchmesser muss größer als 0 sein. Bitte Eingabe korrigieren");
            }

            //Verzahnungwinkel
            ZR1.vw = Convert.ToInt32(vw_txt.Text);
            if ((ZR1.vw < 0) || (ZR1.vw >= 90))
            {
                MessageBox.Show("Fehler: Verzahnungswinkel muss zwischen 0 und 90 Grad liegen. Bitte Eingabe korrigieren");
            }

            //Schrägungswinkel    
            ZR1.cos = Convert.ToInt32(cos_txt.Text);
            if ((ZR1.cos < 0) || (ZR1.cos >= 90))
            {
                MessageBox.Show("Fehler: Winkel muss zwischen 0 und 90 Grad liegen");;
            }

            ZR1.Berechnung();

            

            //Zahnzahl Fehlerbox
            if (ZR1.z <= 4)
            {
                MessageBox.Show("Fehler: Durch eingegebene Parameter ist die Zahnzahl unter/gleich 4");
            }

            //Ausgabe

            //Innenverzahnung schrägverzahnt
            if (rb_IV.IsChecked == true)
            {
                if (CB_SV.IsChecked == true)
                {
                    ZR1.SonderrechnungSchrägverzahnt();
                    ZR1.Rundung();
                    ZR1.SonderrechnungInnen();
                    df_aus_Innen.Content = ZR1.df;
                    da_aus_Innen.Content = ZR1.da;
                    c_aus_Innen.Content = ZR1.c;
                    h_aus_Innen.Content = ZR1.h;
                    hf_aus_Innen.Content = ZR1.hf;
                    ha_aus_Innen.Content = ZR1.ha;
                    p_aus_Innen.Content = ZR1.p;
                    db_aus_Innen.Content = ZR1.db;
                    z_aus_Innen.Content = ZR1.z;
                }
                //Innenverzahnt geradverzahnt
                else
                {
                    ZR1.SonderrechnungInnen();
                    ZR1.Rundung();
                    df_aus_Innen.Content = ZR1.df;
                    da_aus_Innen.Content = ZR1.da;
                    c_aus_Innen.Content = ZR1.c;
                    h_aus_Innen.Content = ZR1.h;
                    hf_aus_Innen.Content = ZR1.hf;
                    ha_aus_Innen.Content = ZR1.ha;
                    p_aus_Innen.Content = ZR1.p;
                    db_aus_Innen.Content = ZR1.db;
                    z_aus_Innen.Content = ZR1.z;
                }
            }
            else
            {
                //Aussenverzahnt schrägverzahnt

                
               if (CB_SV.IsChecked == true)
               {
                    ZR1.SonderrechnungSchrägverzahnt();
                    ZR1.Rundung();
                    ZR1.SonderrechnungAussen();
                    c_aus.Content = ZR1.c;
                    h_aus.Content = ZR1.h;
                    hf_aus.Content = ZR1.hf;
                    ha_aus.Content = ZR1.ha;
                    p_aus.Content = ZR1.p;
                    db_aus.Content = ZR1.db;
                    z_aus.Content = ZR1.z;
                    df_aus.Content = ZR1.df;
                    da_aus.Content = ZR1.da;
               }
               //Aussenverzahnt geradverzahnt
               else
               {
                    ZR1.SonderrechnungAussen();
                    ZR1.Rundung();
                    c_aus.Content = ZR1.c;
                    h_aus.Content = ZR1.h;
                    hf_aus.Content = ZR1.hf;
                    ha_aus.Content = ZR1.ha;
                    p_aus.Content = ZR1.p;
                    db_aus.Content = ZR1.db;
                    z_aus.Content = ZR1.z;
                    df_aus.Content = ZR1.df;
                    da_aus.Content = ZR1.da;
               }
                 
            }

        }

        //Verzahnnungswinkel Checkbox
        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            vw_txt.IsEnabled = true;
        }
        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            vw_txt.IsEnabled = false;
            vw_txt.Text = Convert.ToString(20);
        }

        //Verdrehwinkel Checkbox
        private void CheckBox_Unchecked_2(object sender, RoutedEventArgs e)
        {
            cos_txt.IsEnabled = true;
        }
        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            cos_txt.IsEnabled = false;
            cos_txt.Text = Convert.ToString(0);
        }

        //Info Button Event
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User_Interface_HSP.Window1 window1 = new Window1();
            window1.Show();
        }


        //Schrägverzahnt Checkbox Visibility Check
        private void CB_SV_Unchecked(object sender, RoutedEventArgs e)
        {
            cos_txt.Visibility = Visibility.Hidden;
            cos_lbl.Visibility = Visibility.Hidden;
            CB_cos.Visibility = Visibility.Hidden;
        }

        private void CB_SV_Checked(object sender, RoutedEventArgs e)
        {
            cos_txt.Visibility = Visibility.Visible;
            cos_lbl.Visibility = Visibility.Visible;
            CB_cos.Visibility = Visibility.Visible;
        }

        //Checkbox Kopfspielfaktor
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            cf_txt.IsEnabled = false;
            cf_txt.Text = Convert.ToString(0.167);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            cf_txt.IsEnabled = true;
        }

    }
}
