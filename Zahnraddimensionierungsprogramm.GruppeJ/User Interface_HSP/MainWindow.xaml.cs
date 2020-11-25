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
            public double m;                                                                            //Modul
            public double cf;                                                                           //Kopfspielfaktor(0,1-0,3: häufig 0,167)
            public double d;                                                                            //Teilkreisdurchmesser
            public double sw;                                                                           //Schrägungswinkel (meist zwischen 8° und 25°)
            public double ew;                                                                           //Eingriffswinkel (In der Regel 20°)
            //Ausgabeparameter
            public double drz;                                                                          //Teilkreisdurchmesser nach Rundung von z
            public double c;                                                                            //Kopfspiel
            public double h;                                                                            //Zahnhöhe
            public double hf;                                                                           //Zahnfußhöhe
            public double ha;                                                                           //Zahnkopfhöhe
            public double p;                                                                            //Teilung
            public double z;                                                                            //Zahnzahl
            public double df;                                                                           //Fußkreisdurchmesser
            public double db;                                                                           //Grundkreisdurchmesser
            public double da;                                                                           //Kopfkreisdurchmesser
            public double dm;                                                                           //Mindestaußendurchmesser Hohlrad
            public double mt;                                                                           //Stirnmodul
            public double pt;                                                                           //Stirnteilung
            public double alphat;                                                                       //Stirneingriffswinkel
            public int Verzahnung = 0;
            public double Zahnbreite;                                                                   //Zahnbreite
            public double BD;                                                                           //Bohrungsdurchmesser
            public double A;                                                                            //Fläche
            public double V;                                                                            //Volumen
            public string Material;                                                                     //Zahnradmaterial
            public double MTL_hlp;                                                                      //Dichte
            public double Masse;                                                                        //Masse
            int dezimal = 2;                                                                            //Rundungsvariable
<<<<<<< Updated upstream
=======
            

>>>>>>> Stashed changes
            //Berechnungsmethoden
            internal void Berechnung_geradverzahnt_Außenverzahnung_m_und_d()
            { 
                z = Math.Round((d / m), 0);                                                             //Zahnzahl
                p = Math.Round((Math.PI * m), dezimal);                                                 //Teilung
                c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
                ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
                hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
                h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
                drz = Math.Round((z * m), dezimal);                                                     //Teilkreisdurchmesser nach Rundung von z
                da = Math.Round((drz + 2 * m), dezimal);                                                //Kopfkreisdurchmesser
                df = Math.Round((drz - (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
                db = Math.Round((drz * Math.Cos(ew * (Math.PI / 180))), dezimal);                       //Grundkreisdurchmesser
                A = ((Math.PI * ((da * da) - (BD * BD)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
                V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
                Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            }
            internal void Berechnung_geradverzahnt_Außenverzahnung_m_und_z() 
            {
                drz = Math.Round((m * z), dezimal);                                                     //Teilkreisdurchmesser
                p = Math.Round((Math.PI * m), dezimal);                                                 //Teilung
                c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
                ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
                hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
                h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
                da = Math.Round((m * (z + 2)), dezimal);                                                //Kopfkreisdurchmesser
                df = Math.Round((drz - (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
                db = Math.Round((drz * Math.Cos(ew * (Math.PI / 180))), dezimal);                       //Grundkreisdurchmesser
                A = ((Math.PI * ((da * da) - (BD * BD)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
                V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
                Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            }
            internal void Berechnung_geradverzahnt_Innenverzahnung_m_und_d() 
            {
                z = Math.Round((d / m), 0);                                                             //Zahnzahl
                p = Math.Round((Math.PI * m), dezimal);                                                 //Teilung
                c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
                ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
                hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
                h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
                drz = Math.Round((z * m), dezimal);                                                     //Teilkreisdurchmesser nach Rundung von z
                da = Math.Round((drz - 2 * m), dezimal);                                                //Kopfkreisdurchmesser
                df = Math.Round((drz + (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
                db = Math.Round((drz * Math.Cos(ew * (Math.PI / 180))), dezimal);                       //Grundkreisdurchmesser
                dm = Math.Round((drz * 1.4), dezimal);                                                  //Mindestaußendurchmesser Hohlrad
                A = ((Math.PI * ((dm * dm) - (da * da)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
                V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
                Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            }
            internal void Berechnung_geradverzahnt_Innenverzahnung_m_und_z() 
            {
                d = Math.Round((m * z), dezimal);                                                       //Teilkreisdurchmesser
                p = Math.Round((Math.PI * m), dezimal);                                                 //Teilung
                c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
                ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
                hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
                h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
                da = Math.Round((m * (z - 2)), dezimal);                                                //Kopfkreisdurchmesser
                df = Math.Round((d + (2 * (m + c))), dezimal);                                          //Fußkreisdurchmesser
                db = Math.Round((d * Math.Cos(ew * (Math.PI / 180))), dezimal);                         //Grundkreisdurchmesser
                dm = Math.Round((drz * 1.4), dezimal);                                                  //Mindestaußendurchmesser Hohlrad
                A = ((Math.PI * ((dm * dm) - (da * da)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
                V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
                Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            }
            internal void Berechnung_schrägverzahnt_Außenverzahnung_m_und_d() 
            {
                mt = Math.Round((m / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnmodul
                pt = Math.Round((p / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnteilung
                p = Math.Round(Math.PI * m, dezimal);                                                   //Normalteilung
                z = Math.Round((d / mt), 0);                                                            //Zahnzahl
                c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
                ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
                hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
                h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
                drz = Math.Round((z * m), dezimal);                                                     //Teilkreisdurchmesser nach Rundung von z
                da = Math.Round((drz + 2 * m), dezimal);                                                //Kopfkreisdurchmesser
                df = Math.Round((drz - (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
                alphat = Math.Atan(Math.Tan(ew * (Math.PI / 180)) / Math.Cos(sw * (Math.PI / 180)));    //Stirneingriffswinkel
                db = Math.Round((drz * Math.Cos(alphat)), dezimal);                                     //Grundkreisdurchmesser
                A = ((Math.PI * ((da * da) - (BD * BD)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
                V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
                Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            }
            internal void Berechnung_schrägverzahnt_Außenverzahnung_m_und_z() 
            {
                mt = Math.Round((m / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnmodul
                pt = Math.Round((p / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnteilung
                p = Math.Round(Math.PI * m, dezimal);                                                   //Normalteilung
                drz = Math.Round((mt * z), dezimal);                                                    //Teilkreisdurchmesser
                c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
                ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
                hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
                h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
                da = Math.Round((drz + 2 * m), dezimal);                                                //Kopfkreisdurchmesser
                df = Math.Round((drz - (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
                alphat = Math.Atan(Math.Tan(ew * (Math.PI / 180)) / Math.Cos(sw * (Math.PI / 180)));    //Stirneingriffswinkel
                db = Math.Round((drz * Math.Cos(alphat)), dezimal);                                     //Grundkreisdurchmesser
                A = ((Math.PI * ((da * da) - (BD * BD)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
                V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
                Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            }
            internal void Berechnung_schrägverzahnt_Innenverzahnung_m_und_d() 
            {
                mt = Math.Round((m / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnmodul
                pt = Math.Round((p / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnteilung
                p = Math.Round(Math.PI * m, dezimal);                                                   //Normalteilung
                z = Math.Round((d / mt), 0);                                                            //Zahnzahl
                c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
                ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
                hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
                h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
                drz = Math.Round((z * m), dezimal);                                                     //Teilkreisdurchmesser nach Rundung von z
                da = Math.Round((drz - 2 * m), dezimal);                                                //Kopfkreisdurchmesser
                df = Math.Round((drz + (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
                alphat = Math.Atan((Math.Tan(ew * (Math.PI / 180)) / Math.Cos(sw * (Math.PI / 180))));  //Stirneingriffswinkel
                db = Math.Round((drz * Math.Cos(alphat)), dezimal);                                     //Grundkreisdurchmesser
                dm = Math.Round((drz * 1.4), dezimal);                                                  //Mindestaußendurchmesser Hohlrad
                A = ((Math.PI * ((dm * dm) - (da * da)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
                V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
                Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            }
            internal void Berechnung_schrägverzahnt_Innenverzahnung_m_und_z() 
            {
                mt = Math.Round((m / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnmodul
                pt = Math.Round((p / Math.Cos(sw * (Math.PI / 180))), dezimal);                         //Stirnteilung
                p = Math.Round(Math.PI * m, dezimal);                                                   //Normalteilung
                d = Math.Round((mt * z), dezimal);                                                      //Teilkreisdurchmesser
                drz = Math.Round((mt * z), dezimal);                                                    //Teilkreisdurchmesser Rückrechnung
                c = Math.Round((cf * m), dezimal);                                                      //Kopfspiel
                ha = Math.Round(m, dezimal);                                                            //Zahnkopfhöhe
                hf = Math.Round((m + c), dezimal);                                                      //Zahnfußhöhe
                h = Math.Round((2 * m + c), dezimal);                                                   //Zahnhöhe
                da = Math.Round((drz - 2 * m), dezimal);                                                //Kopfkreisdurchmesser
                df = Math.Round((drz + (2 * (m + c))), dezimal);                                        //Fußkreisdurchmesser
                alphat = Math.Atan((Math.Tan(ew * (Math.PI / 180)) / Math.Cos(sw * (Math.PI / 180))));  //Stirneingriffswinkel
                db = Math.Round((drz * Math.Cos(alphat)), dezimal);                                     //Grundkreisdurchmesser
                dm = Math.Round((drz * 1.4), dezimal);                                                  //Mindestaußendurchmesser Hohlrad
                A = ((Math.PI * ((dm * dm) - (da * da)) / 4) - (Math.PI * m * h * z) / 2);              //Fläche
                V = Math.Round(A * Zahnbreite, dezimal);                                                //Volumen
                Masse = Math.Round(V * MTL_hlp, dezimal);                                               //Masse
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        //Bestätigungsbutton Event
        private void Bestätigen_BTN_Click(object sender, RoutedEventArgs e)
        {
            int Error = 0;
            Zahnrad ZR1 = new Zahnrad
            {
                //Modul
                m = Convert.ToDouble(Modul_Dropbox.Text)
            };
            //Kopfspielfaktor
            string Zahlencheck = cf_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.cf = Convert.ToDouble(cf_txt.Text);
                if ((ZR1.cf < 0.1) || (ZR1.cf > 0.3))
                {
                    MessageBox.Show("Fehler: Der Kopfspielfaktor muss zwischen 0.1 und 0.3 liegen. Bitte Eingabe korrigieren");
                    Error = 1;
                }
            }
            else
            {
                MessageBox.Show("Bitte Eingabe zum Kopfspielfaktor überprüfen");
                Error = 1;
            }
            //Teilkreisdurchmesser
            Zahlencheck = d_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.d = Convert.ToInt32(d_txt.Text);
                if (ZR1.d <= 0)
                {
                    if (RB_MT.IsChecked == true)
                    {
                        MessageBox.Show("Fehler: Teilkreisdurchmesser muss größer als 0 sein. Bitte Eingabe korrigieren");
                        Error = 1;
                    }
                }
            }
            else
            {
                if (RB_MT.IsChecked == true)
                {
                    MessageBox.Show("Bitte Eingabe zum Teilkreisdurchmesser überprüfen");
                    Error = 1;
                }
            }
            //Eingriffswinkel
            Zahlencheck = ew_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.ew = Convert.ToInt32(ew_txt.Text);
                if ((ZR1.ew < 0) || (ZR1.ew >= 90))
                {
                    MessageBox.Show("Fehler: Der Eingriffswinkel muss zwischen 0 und 90 Grad liegen. Bitte Eingabe korrigieren");
                    Error = 1;
                }
            }
            else
            {
                MessageBox.Show("Bitte Eingabe zum Eingriffsswinkel überprüfen");
                Error = 1;
            }
            //Schrägungswinkel   
            Zahlencheck = sw_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.sw = Convert.ToInt32(sw_txt.Text);
                if ((ZR1.sw < 0) || (ZR1.sw >= 90))
                {
                    MessageBox.Show("Fehler: Winkel muss zwischen 0 und 90 Grad liegen");
                    Error = 1;
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
                    Error = 1;
                }
            }
            else
            {
                MessageBox.Show("Bitte Eingabe zum Bohrungsdurchmesser überprüfen");
                Error = 1;
            }
            //Zahnbreite
            Zahlencheck = Zahnbreite_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.Zahnbreite = Convert.ToDouble(Zahnbreite_txt.Text);
                if (ZR1.Zahnbreite < 0)
                {
                    MessageBox.Show("Zahnbreite muss über 0 liegen");
                    Error = 1;
                }
            }
            else
            {
                MessageBox.Show("Bitte Eingabe zur Zahnbreite überprüfen");
                Error = 1;
            }
            //Zähnezahl
            Zahlencheck = z_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.z = Convert.ToDouble(z_txt.Text);
                if (ZR1.z <= 4)
                {
                    if (RB_MZ.IsChecked == true)
                    {
                        MessageBox.Show("Zähnezahl muss über 0 liegen");
                        Error = 1;
                    }
                }
            }
            //Überprüfung beendet

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
            //Ausgabe
<<<<<<< Updated upstream
            if (rb_AV.IsChecked == true)                                                    //Berechnung Außenverzahnung
=======
            if (Error == 0)
>>>>>>> Stashed changes
            {
                if (rb_AV.IsChecked == true)                                                    //Berechnung Außenverzahnung
                {
                    if (CB_SV.IsChecked == false)                                               //Berechnung geradverzahnt Außenverzahnung
                    {
<<<<<<< Updated upstream
                        ZR1.Berechnung_geradverzahnt_Außenverzahnung_m_und_d();
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
                        V_aus.Content = ZR1.V + " mm^3";
                        Masse_aus.Content = ZR1.Masse + " Kg";
                    }
                    if (RB_MZ.IsChecked == true)                                            //Berechnung geradverzahnt Außenverzahnung m und z
                    {
                        ZR1.Berechnung_geradverzahnt_Außenverzahnung_m_und_z();
                        c_aus.Content = ZR1.c + " mm";
                        z_aus.Content = ZR1.z + " mm";
                        h_aus.Content = ZR1.h + " mm";
                        hf_aus.Content = ZR1.hf + " mm";
                        ha_aus.Content = ZR1.ha + " mm";
                        p_aus.Content = ZR1.p + " mm";
                        db_aus.Content = ZR1.db + " mm";
                        df_aus.Content = ZR1.df + " mm";
                        da_aus.Content = ZR1.da + " mm";
                        drz_aus.Content = ZR1.drz + " mm";
                        m_aus.Content = ZR1.m + " mm";
                        V_aus.Content = ZR1.V + " mm^3";
                        Masse_aus.Content = ZR1.Masse + " Kg";
                    }
                }
                if (CB_SV.IsChecked == true)                                                //Berechnung schrägverzahnt Außenverzahnung
                {
                    if (RB_MT.IsChecked == true)                                            //Berechnung schrägverzahnt Außenverzahnung m und d
                        if (RB_MT.IsChecked == true)                                            //Berechnung geradverzahnt Außenverzahnung m und d
                        {
                            ZR1.Berechnung_geradverzahnt_Außenverzahnung_m_und_d();
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
                            V_aus.Content = ZR1.V + " mm^3";
                            Masse_aus.Content = ZR1.Masse + " Kg";
                        }

                        if (RB_MZ.IsChecked == true)        //Berechnung geradverzahnt Außenverzahnung m und z
                        {
                            ZR1.Berechnung_geradverzahnt_Außenverzahnung_m_und_z();
                            c_aus.Content = ZR1.c + " mm";
                            z_aus.Content = ZR1.z + " mm";
                            h_aus.Content = ZR1.h + " mm";
                            hf_aus.Content = ZR1.hf + " mm";
                            ha_aus.Content = ZR1.ha + " mm";
                            p_aus.Content = ZR1.p + " mm";
                            db_aus.Content = ZR1.db + " mm";
                            df_aus.Content = ZR1.df + " mm";
                            da_aus.Content = ZR1.da + " mm";
                            drz_aus.Content = ZR1.drz + " mm";
                            m_aus.Content = ZR1.m + " mm";
                            V_aus.Content = ZR1.V + " mm^3";
                            Masse_aus.Content = ZR1.Masse + " Kg";
                        }

                    }

                    if (CB_SV.IsChecked == true)                                                   //Berechnung schrägverzahnt Außenverzahnung
>>>>>>> Stashed changes
                    {
                        if (RB_MT.IsChecked == true)            //Berechnung schrägverzahnt Außenverzahnung m und d
                        {
                            ZR1.Berechnung_schrägverzahnt_Außenverzahnung_m_und_d();
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
                            V_aus.Content = ZR1.V + " mm^3";
                            Masse_aus.Content = ZR1.Masse + " Kg";
                        }
                        else

                        if (RB_MZ.IsChecked == true)             //Berechnung schrägverzahnt Außenverzahnung m und z
                        {
                            ZR1.Berechnung_schrägverzahnt_Außenverzahnung_m_und_z();
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
                            V_aus.Content = ZR1.V + " mm^3";
                            Masse_aus.Content = ZR1.Masse + " Kg";
                        }
                    }
<<<<<<< Updated upstream
                    else
                    {
                        if (RB_MZ.IsChecked == true)                                            //Berechnung schrägverzahnt Außenverzahnung m und z
                        {
                            ZR1.Berechnung_schrägverzahnt_Außenverzahnung_m_und_z();
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
                            V_aus.Content = ZR1.V + " mm^3";
                            Masse_aus.Content = ZR1.Masse + " Kg";
                        }
                    }   
                }
            }
            else
            {                                                                               //Berechnung Innenverzahnung
                if (CB_SV.IsChecked == false)                                               //Berechnung geradverzahnt Innenverzahnung
                {
                    if (RB_MT.IsChecked == true)                                            //Berechnung geradverzahnt Innenverzahnung m und d
=======

                }
                else
                {
                    if (CB_SV.IsChecked == false)                                                  //Berechnung geradverzahnt Innenverzahnung
>>>>>>> Stashed changes
                    {
                        if (RB_MT.IsChecked == true)        //Berechnung geradverzahnt Innenverzahnung m und d
                        {
                            ZR1.Berechnung_geradverzahnt_Innenverzahnung_m_und_d();
                            c_aus_Innen.Content = ZR1.c + " mm";
                            h_aus_Innen.Content = ZR1.h + " mm";
                            hf_aus_Innen.Content = ZR1.hf + " mm";
                            ha_aus_Innen.Content = ZR1.ha + " mm";
                            p_aus_Innen.Content = ZR1.p + " mm";
                            db_aus_Innen.Content = ZR1.db + " mm";
                            z_aus_Innen.Content = ZR1.z;
                            df_aus_Innen.Content = ZR1.df + " mm";
                            da_aus_Innen.Content = ZR1.da + " mm";
                            dm_aus_Innen.Content = ZR1.dm + " mm";
                            drz_aus_Innen.Content = ZR1.drz + " mm";
                            m_aus_Innen.Content = ZR1.m + " mm";
                            V_aus_Innen.Content = ZR1.V + " mm^3";
                            Masse_aus_Innen.Content = ZR1.Masse + " Kg";
                        }


                        if (RB_MZ.IsChecked == true)            //Berechnung geradverzahnt Innenverzahnung m und z
                        {
                            ZR1.Berechnung_geradverzahnt_Innenverzahnung_m_und_z();
                            c_aus_Innen.Content = ZR1.c + " mm";
                            h_aus_Innen.Content = ZR1.h + " mm";
                            hf_aus_Innen.Content = ZR1.hf + " mm";
                            ha_aus_Innen.Content = ZR1.ha + " mm";
                            p_aus_Innen.Content = ZR1.p + " mm";
                            db_aus_Innen.Content = ZR1.db + " mm";
                            z_aus_Innen.Content = ZR1.z;
                            df_aus_Innen.Content = ZR1.df + " mm";
                            da_aus_Innen.Content = ZR1.da + " mm";
                            dm_aus_Innen.Content = ZR1.dm + " mm";
                            drz_aus_Innen.Content = ZR1.drz + " mm";
                            m_aus_Innen.Content = ZR1.m + " mm";
                            V_aus_Innen.Content = ZR1.V + " mm^3";
                            Masse_aus_Innen.Content = ZR1.Masse + " Kg";

                        }
                    }
<<<<<<< Updated upstream
                    if (RB_MZ.IsChecked == true)                                            //Berechnung geradverzahnt Innenverzahnung m und z
                    {
                        ZR1.Berechnung_geradverzahnt_Innenverzahnung_m_und_z();
                        c_aus_Innen.Content = ZR1.c + " mm";
                        h_aus_Innen.Content = ZR1.h + " mm";
                        hf_aus_Innen.Content = ZR1.hf + " mm";
                        ha_aus_Innen.Content = ZR1.ha + " mm";
                        p_aus_Innen.Content = ZR1.p + " mm";
                        db_aus_Innen.Content = ZR1.db + " mm";
                        z_aus_Innen.Content = ZR1.z;
                        df_aus_Innen.Content = ZR1.df + " mm";
                        da_aus_Innen.Content = ZR1.da + " mm";
                        dm_aus_Innen.Content = ZR1.dm + " mm";
                        drz_aus_Innen.Content = ZR1.drz + " mm";
                        m_aus_Innen.Content = ZR1.m + " mm";
                        V_aus_Innen.Content = ZR1.V + " mm^3";
                        Masse_aus_Innen.Content = ZR1.Masse + " Kg";

                    }
                }
                if (CB_SV.IsChecked == true)                                                //Berechnung schrägverzahnt Innenverzahnung
                {
                    if (RB_MT.IsChecked == true)                                            //Berechnung schrägverzahnt Innenverzahnung m und d
                    {
                        ZR1.Berechnung_schrägverzahnt_Innenverzahnung_m_und_d();
                        c_aus_Innen.Content = ZR1.c + " mm";
                        h_aus_Innen.Content = ZR1.h + " mm";
                        hf_aus_Innen.Content = ZR1.hf + " mm";
                        ha_aus_Innen.Content = ZR1.ha + " mm";
                        p_aus_Innen.Content = ZR1.p + " mm";
                        db_aus_Innen.Content = ZR1.db + " mm";
                        z_aus_Innen.Content = ZR1.z;
                        df_aus_Innen.Content = ZR1.df + " mm";
                        da_aus_Innen.Content = ZR1.da + " mm";
                        dm_aus_Innen.Content = ZR1.dm + " mm";
                        drz_aus_Innen.Content = ZR1.drz + " mm";
                        m_aus_Innen.Content = ZR1.m + " mm";
                        V_aus_Innen.Content = ZR1.V + " mm^3";
                        Masse_aus_Innen.Content = ZR1.Masse + " Kg";
                    }
                    if (RB_MZ.IsChecked == true)                                            //Berechnung schrägverzahnt Innenverzahnung m und z
                    {
                        ZR1.Berechnung_schrägverzahnt_Innenverzahnung_m_und_z();
                        c_aus_Innen.Content = ZR1.c + " mm";
                        h_aus_Innen.Content = ZR1.h + " mm";
                        hf_aus_Innen.Content = ZR1.hf + " mm";
                        ha_aus_Innen.Content = ZR1.ha + " mm";
                        p_aus_Innen.Content = ZR1.p + " mm";
                        db_aus_Innen.Content = ZR1.db + " mm";
                        z_aus_Innen.Content = ZR1.z;
                        df_aus_Innen.Content = ZR1.df + " mm";
                        da_aus_Innen.Content = ZR1.da + " mm";
                        dm_aus_Innen.Content = ZR1.dm + " mm";
                        drz_aus_Innen.Content = ZR1.drz + " mm";
                        m_aus_Innen.Content = ZR1.m + " mm";
                        V_aus_Innen.Content = ZR1.V + " mm^3";
                        Masse_aus_Innen.Content = ZR1.Masse + " Kg";
=======


                    if (CB_SV.IsChecked == true)                                                     //Berechnung schrägverzahnt Innenverzahnung
                    {
                        if (RB_MT.IsChecked == true)            //Berechnung schrägverzahnt Innenverzahnung m und d
                        {
                            ZR1.Berechnung_schrägverzahnt_Innenverzahnung_m_und_d();
                            c_aus_Innen.Content = ZR1.c + " mm";
                            h_aus_Innen.Content = ZR1.h + " mm";
                            hf_aus_Innen.Content = ZR1.hf + " mm";
                            ha_aus_Innen.Content = ZR1.ha + " mm";
                            p_aus_Innen.Content = ZR1.p + " mm";
                            db_aus_Innen.Content = ZR1.db + " mm";
                            z_aus_Innen.Content = ZR1.z;
                            df_aus_Innen.Content = ZR1.df + " mm";
                            da_aus_Innen.Content = ZR1.da + " mm";
                            dm_aus_Innen.Content = ZR1.dm + " mm";
                            drz_aus_Innen.Content = ZR1.drz + " mm";
                            m_aus_Innen.Content = ZR1.m + " mm";
                            V_aus_Innen.Content = ZR1.V + " mm^3";
                            Masse_aus_Innen.Content = ZR1.Masse + " Kg";
                        }


                        if (RB_MZ.IsChecked == true)             //Berechnung schrägverzahnt Innenverzahnung m und z
                        {
                            ZR1.Berechnung_schrägverzahnt_Innenverzahnung_m_und_z();
                            c_aus_Innen.Content = ZR1.c + " mm";
                            h_aus_Innen.Content = ZR1.h + " mm";
                            hf_aus_Innen.Content = ZR1.hf + " mm";
                            ha_aus_Innen.Content = ZR1.ha + " mm";
                            p_aus_Innen.Content = ZR1.p + " mm";
                            db_aus_Innen.Content = ZR1.db + " mm";
                            z_aus_Innen.Content = ZR1.z;
                            df_aus_Innen.Content = ZR1.df + " mm";
                            da_aus_Innen.Content = ZR1.da + " mm";
                            dm_aus_Innen.Content = ZR1.dm + " mm";
                            drz_aus_Innen.Content = ZR1.drz + " mm";
                            m_aus_Innen.Content = ZR1.m + " mm";
                            V_aus_Innen.Content = ZR1.V + " mm^3";
                            Masse_aus_Innen.Content = ZR1.Masse + " Kg";

                        }
>>>>>>> Stashed changes
                    }
                }
            }
        }
        //Zahlüberprüfung
        private bool Zahlprüfung(string Zahlencheck)
        {
            try
            {
                double doublezahl = double.Parse(Zahlencheck);
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
        }
        private void CB_SV_Checked(object sender, RoutedEventArgs e)
        {
            sw_txt.Visibility = Visibility.Visible;
            sw_lbl.Visibility = Visibility.Visible;
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
        //Radiobutton 
        private void RB_MT_Checked(object sender, RoutedEventArgs e)
        {
            d_txt.IsEnabled = true;
            z_txt.IsEnabled = false;
        }
        private void RB_MZ_Checked(object sender, RoutedEventArgs e)
        {
            d_txt.IsEnabled = false;
            z_txt.IsEnabled = true;
        }
        private void RB_MT_Unchecked(object sender, RoutedEventArgs e)
        {
            d_txt.IsEnabled = false;
            z_txt.IsEnabled = true;
        }
        private void RB_MZ_Unchecked(object sender, RoutedEventArgs e)
        {
            d_txt.IsEnabled = true;
            z_txt.IsEnabled = false;
        }
        private void rb_AV_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void rb_IV_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Modulrechner_Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 Modulrechner = new Window2();
            Modulrechner.Show();
        }
        private void Beenden_BTN_Click(object sender, EventArgs e)
        {
            Close();

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 Passfederrechner = new Window3();
            Passfederrechner.Show();
        }
        private void Clear_BTN_Click(object sender, EventArgs e)
        {
            d_txt.Clear();
            z_txt.Clear();
            BD_txt.Clear();
            Zahnbreite_txt.Clear();
            c_aus.Content = "";
            h_aus.Content = "";
            hf_aus.Content = "";
            ha_aus.Content = "";
            p_aus.Content = "";
            db_aus.Content = "";
            z_aus.Content = "";
            df_aus.Content = "";
            da_aus.Content = "";
            drz_aus.Content = "";
            m_aus.Content = "";
            V_aus.Content = "";
            Masse_aus.Content = "";
            c_aus_Innen.Content = "";
            h_aus_Innen.Content = "";
            hf_aus_Innen.Content = "";
            ha_aus_Innen.Content = "";
            p_aus_Innen.Content = "";
            db_aus_Innen.Content = "";
            z_aus_Innen.Content = "";
            df_aus_Innen.Content = "";
            da_aus_Innen.Content = "";
            dm_aus_Innen.Content = "";
            drz_aus_Innen.Content = "";
            m_aus_Innen.Content = "";
            V_aus_Innen.Content = "";
            Masse_aus_Innen.Content = "";
            cf_txt.Text = "0,167";
            ew_txt.Text = "20";
            Modul_Dropbox.SelectedItem =CB2;
            Kopfspielfaktor_CB.IsChecked = false;
            Eingriffswinkel_CB.IsChecked = false;
            CB_SV.IsChecked = false;
            RB_MT.IsChecked = true;
        }
    }
}
