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
            public double m;                                                        //Modul
            public double cf;                                                       //Kopfspielfaktor
            public double d;                                                        //Teilkreisdurchmesser
            public double sw;                                                       //Schrägungswinkel (meist zwischen 8° und 25°)
            public double ew;                                                       //Eingriffswinkel (In der Regel 20°)
            //Ausgabeparameter
            public double drz;                                                      //Teilkreisdurchmesser nach Rundung von z
            public double c;                                                        //Kopfspiel
            public double h;                                                        //Zahnhöhe
            public double hf;                                                       //Zahnfußhöhe
            public double ha;                                                       //Zahnkopfhöhe
            public double p;                                                        //Teilung
            public double z;                                                        //Zahnzahl
            public double df;                                                       //Fußkreisdurchmesser
            public double db;                                                       //Grundkreisdurchmesser
            public double da;                                                       //Kopfkreisdurchmesser

            public double mt;                                                       //Stirnmodul
            public double pt;                                                       //Stirnteilung
            public double alphat;                                                   //Stirneingriffswinkel

            public int Verzahnung = 0;
            public double Zahnbreite;                                               //Zahnbreite
            public double BD;                                                       //Bohrungsdurchmesser
            public double A;                                                        //Fläche
            public double V;                                                        //Volumen
            public string Material;                                                 //Zahnradmaterial
            public double MTL_hlp;                                                  //Dichte
            public double Masse;                                                    //Masse

            //Methoden
            internal void Berechnung()
            {
                c = m * cf;                                                         //Kopfspiel
                h = 2 * m + c;                                                      //Zahnhöhe
                hf = m + c;                                                         //Zahnfußhöhe
                ha = m;                                                             //Zahnkopfhöhe
                p = Math.PI * m;                                                     //Teilung
                z = Math.Round(d / m, 0);                                           //Zahnzahl
                drz = z * m;                                                        //angepasster Teilkreisdurchmesser nach Rundung von z
                db = drz * Math.Cos(ew);                                            //Grundkreisdurchmesser

            }
            internal void SonderrechnungAussen()
            {
                df = d - 2 * (m + c);                                               //Fußkreisdurchmesser
                da = d + 2 * m;                                                     //Kopfkreisdurchmesser
                A = ((Math.PI * ((da * da) - (BD * BD)) / 4) - (Math.PI * m * h * z) / 2);//Fläche
                V = A * Zahnbreite;                                                 //Volumen
                Masse = V * MTL_hlp;                                                //Masse
            }
            internal void SonderrechnungInnen()
            {
                df = d + 2 * (m + c);                                               //Fußkreisdurchmesser
                da = d - 2 * m;                                                     //Kopfkreisdurchmesser
                A = ((Math.PI * ((da * da) - (BD * BD)) / 4) - (Math.PI * m * h * z) / 2);//Fläche
                V = A * Zahnbreite;                                                 //Volumen
                Masse = V * MTL_hlp;                                                 //Masse
            }
            internal void SonderrechnungSchrägverzahnt()
            {
                mt = m / Math.Cos(sw);                                             //Stirnmodul
                p = m * Math.PI;                                                   //Teilung
                pt = p / Math.Cos(sw);                                             //Stirnteilung
                c = m * cf;                                                         //Kopfspiel
                h = 2 * m + c;                                                      //Zahnhöhe
                hf = m + c;                                                         //Zahnfußhöhe
                ha = m;                                                             //Zahnkopfhöhe
                z = d / mt;                                                         //Zahnzahl
                drz = mt * Math.Round(z, 0);                                        //angepasster Teilkreisdurchmesser nach Rundung von z
                alphat = Math.Atan((Math.Tan(ew) / Math.Cos(sw)));                   //Stirneingriffswinkel
                db = drz*Math.Cos(alphat);                                          //Grundkreisdurchmesser (cos(20°)= 0,9397)
                A = ((Math.PI * ((da * da) - (BD * BD)) / 4) - (Math.PI * m * h * z) / 2);//Fläche
                V = A * Zahnbreite;                                                 //Volumen
               Masse = V * MTL_hlp;                                                 //Masse

            }
            internal void Rundung()
            {
                c = Math.Round(c, 2);
                d = Math.Round(d, 2);
                drz = Math.Round(drz, 2);
                h = Math.Round(h, 2);
                hf = Math.Round(hf, 2);
                ha = Math.Round(ha, 2);
                p = Math.Round(p, 2);
                z = Math.Round(z, 0);
                df = Math.Round(df, 2);
                db = Math.Round(db, 2);
                da = Math.Round(da, 2);
                V = Math.Round(V, 2);
                Masse = Math.Round(Masse, 2);
                alphat = Math.Round(alphat, 2);
                mt = Math.Round(mt, 2);

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
            string Zahlencheck = cf_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.cf = Convert.ToDouble(cf_txt.Text);
                if ((ZR1.cf < 0.1) || (ZR1.cf > 0.3))
                {
                    MessageBox.Show("Fehler: Der Kopfspielfaktor muss zwischen 0.1 und 0.3 liegen. Bitte Eingabe korrigieren");
                }
            }
            else
            {
                MessageBox.Show("Bitte Eingabe zum Kopfspielfaktor überprüfen");
            }
            //Teilkreisdurchmesser
            Zahlencheck = d_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.d = Convert.ToInt32(d_txt.Text);
                if (ZR1.d == 0)
                {
                    MessageBox.Show("Fehler: Teilkreisdurchmesser muss größer als 0 sein. Bitte Eingabe korrigieren");
                }
            }
            else
            {
                MessageBox.Show("Bitte Eingabe zum Teilkreisdurchmesser überprüfen");
            }

            //Eingriffswinkel
            Zahlencheck = ew_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.ew = Convert.ToInt32(ew_txt.Text);
                if ((ZR1.ew < 0) || (ZR1.ew >= 90))
                {
                    MessageBox.Show("Fehler: Der Eingriffswinkel muss zwischen 0 und 90 Grad liegen. Bitte Eingabe korrigieren");
                }
            }
            else
            {
                MessageBox.Show("Bitte Eingabe zum Eingriffsswinkel überprüfen");
            }

            //Schrägungswinkel   
            Zahlencheck = sw_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.sw = Convert.ToInt32(sw_txt.Text);
                if ((ZR1.sw < 0) || (ZR1.sw >= 90))
                {
                    MessageBox.Show("Fehler: Winkel muss zwischen 0 und 90 Grad liegen"); ;
                }
            }
            else
            {
                MessageBox.Show("Bitte Eingabe zum Schrägungswinkel überprüfen");
            }

            //Bohrungsdurchmesser
            Zahlencheck = BD_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.BD = Convert.ToDouble(BD_txt.Text);
                if (ZR1.BD < 0)
                {
                    MessageBox.Show("Fehler: Bohrungsdurchmesser darf nicht 0 oder mehr als Kopfkreisdurchmesser betragen");
                }
            }
            else
            {
                MessageBox.Show("Bitte Eingabe zum Bohrungsdurchmesser überprüfen");
            }

            //Zahnbreite
            Zahlencheck = Zahnbreite_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.Zahnbreite = Convert.ToDouble(Zahnbreite_txt.Text);
                if (ZR1.Zahnbreite < 0)
                {
                    MessageBox.Show("Zahnbreite muss über 0 liegen");
                }
            }
            else
            {
                MessageBox.Show("Bitte Eingabe zur Zahnbreite überprüfen");
            }

            //Zähnezahl
            Zahlencheck = z_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.z = Convert.ToDouble(z_txt.Text);
                if (ZR1.z < 0)
                {
                    MessageBox.Show("Zähnezahl muss über 0 liegen");
                }
            }
            else
            {
                MessageBox.Show("Bitte Eingabe zur Zähnezahl überprüfen");
            }

            //Material
            ZR1.Material = Convert.ToString(Material_Dropbox.Text);
            switch (ZR1.Material)
            {
                case "Stahl":
                    ZR1.MTL_hlp = 0.00000785;
                    break;
                case "Messing":
                    ZR1.MTL_hlp = 0.0000084;
                    break;
                case "Kunststoff":
                    ZR1.MTL_hlp = 0.00000022;
                    break;
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
                    df_aus_Innen.Content = ZR1.df+" mm";
                    da_aus_Innen.Content = ZR1.da+" mm";
                    c_aus_Innen.Content = ZR1.c+" mm";
                    h_aus_Innen.Content = ZR1.h+" mm";
                    hf_aus_Innen.Content = ZR1.hf+" mm";
                    ha_aus_Innen.Content = ZR1.ha+" mm";
                    p_aus_Innen.Content = ZR1.p+" mm";
                    db_aus_Innen.Content = ZR1.db+" mm";
                    z_aus_Innen.Content = ZR1.z;
                    drz_aus_Innen.Content = ZR1.drz+" mm";
                    m_aus_Innen.Content = ZR1.m+" mm";
                    V_aus_Innen.Content = ZR1.V+" mm^3";
                    Masse_aus_Innen.Content = ZR1.Masse + " Kg";
                }
                //Innenverzahnt geradverzahnt
                else
                {
                    ZR1.SonderrechnungInnen();
                    ZR1.Rundung();
                    df_aus_Innen.Content = ZR1.df+" mm";
                    da_aus_Innen.Content = ZR1.da + " mm";
                    c_aus_Innen.Content = ZR1.c + " mm";
                    h_aus_Innen.Content = ZR1.h + " mm";
                    hf_aus_Innen.Content = ZR1.hf + " mm";
                    ha_aus_Innen.Content = ZR1.ha + " mm";
                    p_aus_Innen.Content = ZR1.p + " mm";
                    db_aus_Innen.Content = ZR1.db + " mm";
                    z_aus_Innen.Content = ZR1.z;
                    drz_aus_Innen.Content = ZR1.drz + " mm";
                    m_aus_Innen.Content = ZR1.m + " mm";
                    V_aus_Innen.Content = ZR1.V+" mm^3";
                    Masse_aus_Innen.Content = ZR1.Masse + " Kg";
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
                    c_aus.Content = ZR1.c + " mm";
                    h_aus.Content = ZR1.h + " mm";
                    hf_aus.Content = ZR1.hf + " mm";
                    ha_aus.Content = ZR1.ha + " mm";
                    p_aus.Content = ZR1.p + " mm";
                    db_aus.Content = ZR1.db + " mm";
                    z_aus.Content = ZR1.z;
                    df_aus.Content = ZR1.df + " mm";
                    da_aus.Content = ZR1.da + " mm";
                    drz_aus.Content = ZR1.drz + " mm";
                    m_aus.Content = ZR1.m + " mm";
                    V_aus.Content = ZR1.V+" mm^3";
                    Masse_aus.Content = ZR1.Masse + " Kg";
               }
               //Aussenverzahnt geradverzahnt
               else
               {
                    ZR1.SonderrechnungAussen();
                    ZR1.Rundung();
                    c_aus.Content = ZR1.c + " mm";
                    h_aus.Content = ZR1.h + " mm";
                    hf_aus.Content = ZR1.hf + " mm";
                    ha_aus.Content = ZR1.ha + " mm";
                    p_aus.Content = ZR1.p + " mm";
                    db_aus.Content = ZR1.db + " mm";
                    z_aus.Content = ZR1.z;
                    df_aus.Content = ZR1.df + " mm";
                    da_aus.Content = ZR1.da + " mm";
                    drz_aus.Content = ZR1.drz + " mm";
                    m_aus.Content = ZR1.m + " mm";
                    V_aus.Content = ZR1.V+" mm^3";
                    Masse_aus.Content = ZR1.Masse + " Kg";
               }

            }

        }

        //Zahlüberprüfung
        private bool Zahlprüfung(string Zahlcheck)
        {
            try
            {
                double doublezahl = double.Parse(Zahlcheck);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        //Eingriffswinkel Checkbox
        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            ew_txt.IsEnabled = true;
        }
        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            ew_txt.IsEnabled = false;
            ew_txt.Text = Convert.ToString(20);
        }

        //Schrägungswinkel Checkbox
        private void CheckBox_Unchecked_2(object sender, RoutedEventArgs e)
        {
            sw_txt.IsEnabled = false;
            sw_txt.Text = Convert.ToString(0);
        }
        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            sw_txt.IsEnabled = true;
            
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
            sw_txt.Visibility = Visibility.Hidden;
            sw_lbl.Visibility = Visibility.Hidden;
            CB_sw.Visibility = Visibility.Hidden;

        }

        private void CB_SV_Checked(object sender, RoutedEventArgs e)
        {
            sw_txt.Visibility = Visibility.Visible;
            sw_lbl.Visibility = Visibility.Visible;
            CB_sw.Visibility = Visibility.Visible;
        }

        //Checkbox Kopfspielfaktor
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            cf_txt.IsEnabled = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            cf_txt.IsEnabled = false;
            cf_txt.Text = Convert.ToString(0.167);
        }

        //Checkbox Modul
        private void Modul_CB_Checked(object sender, RoutedEventArgs e)
        {
            Modul_Dropbox.IsEnabled = true;
        }

        private void Modul_CB_Unchecked(object sender, RoutedEventArgs e)
        {
            Modul_Dropbox.IsEnabled = false;
        }

        //Checkbox Teilkreisdurchmesser
        private void Teilkreis_CB_Checked(object sender, RoutedEventArgs e)
        {
            d_txt.IsEnabled = true;
        }

        private void Teilkreis_CB_Unchecked(object sender, RoutedEventArgs e)
        {
            d_txt.IsEnabled = false;
        }

        //Checkbox Zahnzahl
        private void Zahnzahl_CB_Checked(object sender, RoutedEventArgs e)
        {
            z_txt.IsEnabled = true;
        }

        private void Zahnzahl_CB_Unchecked(object sender, RoutedEventArgs e)
        {
            z_txt.IsEnabled = false;
        }

        //Checkbox Eingriffsswinkel
        private void Eingriffswinkel_CB_Checked(object sender, RoutedEventArgs e)
        {
            ew_txt.IsEnabled = true;
        }

        private void Eingriffswinkel_CB_Unchecked(object sender, RoutedEventArgs e)
        {
            ew_txt.IsEnabled = false;
            ew_txt.Text = Convert.ToString("20");
        }

        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
