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
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace API.Zahnraddimensionierungsprogramm.GruppeJ
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Zahnrad ZR1 = new Zahnrad();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        //Event Click Bestätigungsbutton
        public void Bestätigen_BTN_Click(object sender, RoutedEventArgs e)
        {
            int Error = 0;

            //Modul
            ZR1.m = Convert.ToDouble(Modul_Dropbox.Text);
            
            //EINGABECHECKS
            //Eingabecheck Kopfspielfaktor
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
            //Eingabecheck Teilkreisdurchmesser
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
            //Eingabecheck Eingriffswinkel
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
            //Eingabecheck Schrägungswinkel   
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
                Error = 1;
            }
            //Eingabecheck Bohrungsdurchmesser
            Zahlencheck = BD_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.BD = Convert.ToDouble(BD_txt.Text);
                if (ZR1.BD < 0)
                {
                    if(RB_AV.IsChecked == true)
                    {
                        MessageBox.Show("Fehler: Bohrungsdurchmesser darf nicht 0 oder mehr als Kopfkreisdurchmesser betragen");
                        Error = 1;
                    }
                }
            }
            else
            {
                if(RB_AV.IsChecked == true)
                {
                    MessageBox.Show("Bitte Eingabe zum Bohrungsdurchmesser überprüfen");
                    Error = 1;
                }
            }
            //Eingabecheck Zahnbreite
            Zahlencheck = Zahnbreite_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.Zahnbreite = Convert.ToDouble(Zahnbreite_txt.Text);
                if (ZR1.Zahnbreite <= 4)
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
            //Eingabecheck Zähnezahl
            Zahlencheck = z_txt.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                ZR1.z = Convert.ToDouble(z_txt.Text);
                if (ZR1.z <= 4)
                {
                    if (RB_MZ.IsChecked == true)
                    {
                        MessageBox.Show("Zähnezahl muss über 4 liegen");
                        Error = 1;
                    }
                }
            }
            else
            {
                if (RB_MZ.IsChecked == true)
                {
                    MessageBox.Show("Error: Eingabe für Zähnezahl überprüfen");
                    Error = 1;
                }
            }
            //Ganzzahlencheck
            string Ganzzahlencheck = z_txt.Text;
            if (Ganzzahlprüfung(Ganzzahlencheck) == true)
            {
                ZR1.z = Convert.ToDouble(z_txt.Text);
                if (ZR1.z % 1 != 0)
                {
                    if (RB_MZ.IsChecked == true)
                    {
                        MessageBox.Show("Die Zähnezahl muss eine ganzzahlige Zahl sein!");
                        Error = 1;
                    }
                }
            }
            else 
            {
                if (RB_MZ.IsChecked == true)
                {
                    MessageBox.Show("Die Zähnezahl muss eine ganzzahlige Zahl sein!");
                    Error = 1;
                }
            }

            //EINGABECHECKS BEENDET

            //Materialauswahl mit entsprechender Dichte für Masseberechnung
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
            //AUSGABE
            if (Error == 0)
            {
                ZR1.Catiakonstruktionserlaubnis = true;
                if (RB_AV.IsChecked == true)                                                    //Berechnung Außenverzahnung
                {
                    if (CB_SV.IsChecked == false)                                               //Berechnung geradverzahnt Außenverzahnung
                    {
                        
                        if (RB_MT.IsChecked == true)                                            //Berechnung geradverzahnt Außenverzahnung m und d
                        {
                            ZR1.Berechnung_geradverzahnt_Außenverzahnung_m_und_d();
                            c_aus.Content = ZR1.c + " mm";                                      //Ausgabe im Tab für Außenverzahnung
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
                            d_txt.Text = Convert.ToString(ZR1.drz);
                        }
                        if (RB_MZ.IsChecked == true)                                            //Berechnung geradverzahnt Außenverzahnung m und z
                        {
                            ZR1.Berechnung_geradverzahnt_Außenverzahnung_m_und_z();
                            c_aus.Content = ZR1.c + " mm";                                      //Ausgabe im Tab für Außenverzahnung
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
                        {
                            ZR1.Berechnung_schrägverzahnt_Außenverzahnung_m_und_d();
                            c_aus.Content = ZR1.c + " mm";                                      //Ausgabe im Tab für Außenverzahnung
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
                            d_txt.Text = Convert.ToString(ZR1.drz);
                        }
                        else
                        {
                            if (RB_MZ.IsChecked == true)                                         //Berechnung schrägverzahnt Außenverzahnung m und z
                            {
                                ZR1.Berechnung_schrägverzahnt_Außenverzahnung_m_und_z();
                                c_aus.Content = ZR1.c + " mm";                                   //Ausgabe im Tab für Außenverzahnung
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
                        {
                            ZR1.Berechnung_geradverzahnt_Innenverzahnung_m_und_d();
                            c_aus_Innen.Content = ZR1.c + " mm";                                //Ausgabe im Tab für Innenverzahnung
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
                            d_txt.Text = Convert.ToString(ZR1.drz);
                        }
                        if (RB_MZ.IsChecked == true)                                            //Berechnung geradverzahnt Innenverzahnung m und z
                        {
                            ZR1.Berechnung_geradverzahnt_Innenverzahnung_m_und_z();
                            c_aus_Innen.Content = ZR1.c + " mm";                                //Ausgabe im Tab für Innenverzahnung
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
                            c_aus_Innen.Content = ZR1.c + " mm";                                //Ausgabe im Tab für Innenverzahnung
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
                            d_txt.Text = Convert.ToString(ZR1.drz);
                        }
                        if (RB_MZ.IsChecked == true)                                            //Berechnung schrägverzahnt Innenverzahnung m und z
                        {
                            ZR1.Berechnung_schrägverzahnt_Innenverzahnung_m_und_z();
                            c_aus_Innen.Content = ZR1.c + " mm";                                //Ausgabe im Tab für Innenverzahnung
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
                }
            }
        } 
        //ZAHLENCHECK
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
        //Zahlencheck ganzzahlige Zahl
        private bool Ganzzahlprüfung(string Ganzzahlencheck)
        {
            try
            {
                int intzahl = int.Parse(Ganzzahlencheck);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        //Event Click Info Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            API.Zahnraddimensionierungsprogramm.GruppeJ.Window1 window1 = new Window1();                     //Neues Fenster wird geöffnet, in dem sich eine Zahnradskizze mit den charakteristischen Parametern befindet
            window1.Show();
        }
        //Checkbox Eingriffswinkel
        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)         //Checkbox für Eingriffswinkel nicht angewählt
        {
            ew_txt.IsEnabled = true;
        }
        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)           //Checkbox für Eingriffswinkel angewählt
        {
            ew_txt.IsEnabled = false;
            ew_txt.Text = Convert.ToString(20);
        }
        //Checkbox Schrägverzahnt Visibility Check
        private void CB_SV_Unchecked(object sender, RoutedEventArgs e)              //Checkbox für Schrägverzahnung nicht angewählt
        {
            sw_txt.Visibility = Visibility.Hidden;                                  //unsichtbar
            sw_lbl.Visibility = Visibility.Hidden;
            sw_txt.Text = "0";
        }
        private void CB_SV_Checked(object sender, RoutedEventArgs e)                //Checkbox für Schrägverzahnung angewählt
        {
            sw_txt.Visibility = Visibility.Visible;                                 //sichtbar
            sw_lbl.Visibility = Visibility.Visible;
        }
        //Checkbox Kopfspielfaktor
        private void CheckBox_Checked(object sender, RoutedEventArgs e)             //Checkbox für Kopfspielfaktor angewählt
        {
            cf_txt.IsEnabled = true;
            cf_txt.Clear();
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)           //Checkbox für Kopfspielfaktor nicht angewählt
        {
            cf_txt.IsEnabled = false;
            cf_txt.Text = Convert.ToString(0.167);
        }
        //Checkbox Eingriffsswinkel
        private void Eingriffswinkel_CB_Checked(object sender, RoutedEventArgs e)   //Checkbox für Eingriffswinkel angewählt
        {
            ew_txt.IsEnabled = true;
        }
        private void Eingriffswinkel_CB_Unchecked(object sender, RoutedEventArgs e) //Checkbox für Eingriffswinkel nicht angewählt
        {
            ew_txt.IsEnabled = false;
            ew_txt.Text = Convert.ToString("20");
        }
        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
        //Radiobutton 
        private void RB_MT_Checked(object sender, RoutedEventArgs e)                //Radiobutton für Berechnungsmodus Modul und Teilkreisdurchmesser angewählt
        {
            d_txt.IsEnabled = true;
            z_txt.IsEnabled = false;
            z_txt.Clear();
        }
        private void RB_MZ_Checked(object sender, RoutedEventArgs e)                //Radiobutton für Berechnungsmodus Modul und Zahnzahl angewählt
        {
            d_txt.IsEnabled = false;
            z_txt.IsEnabled = true;
            d_txt.Clear();
        }
        private void RB_MT_Unchecked(object sender, RoutedEventArgs e)              //Radiobutton für Berechnungsmodus Modul und Teilkreisdurchmesser nicht angewählt
        {
            d_txt.IsEnabled = false;
            z_txt.IsEnabled = true;
        }
        private void RB_MZ_Unchecked(object sender, RoutedEventArgs e)              //Radiobutton für Berechnungsmodus Modul und Zahnzahl nicht angewählt
        {
            d_txt.IsEnabled = true;
            z_txt.IsEnabled = false;
        }
        private void RB_AV_Checked(object sender, RoutedEventArgs e)                //Radiobutton für Außenverzahnung angewählt
        {
            BD_txt.IsEnabled = true;

        }
        private void RB_IV_Checked(object sender, RoutedEventArgs e)                //Radiobutton für Innenverzahnung angewählt          
        {
            BD_txt.Clear();
            BD_txt.IsEnabled = false;
        }
        //Event Click Modulrechner Button
        private void Modulrechner_Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 Modulrechner = new Window2();                                   //Neues Fenster wird geöffnet, in dem sich der Modulrechner befindet
            Modulrechner.Show();
        }
        //Event Click Beenden Button
        private void Beenden_BTN_Click(object sender, EventArgs e)
        {
            Close();                                                                //Zahnraddimensionierungsprogramm wird geschlossen
        }
        //Event Click Passfederrechner Button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 Passfederrechner = new Window3();                               //Neues Fenster wird geöffnet, in dem sich der Passfederrechner befindet
            Passfederrechner.Show();
        }
        //Event Click Clear Button (Reset)
        private void Clear_BTN_Click(object sender, EventArgs e)
        {
            d_txt.Clear();                                                          //Textfeld mit dem Teilkreisdurchmesser wird zurückgesetzt
            z_txt.Clear();                                                          //Textfeld mit der Zahnzahl wird zurückgesetzt
            BD_txt.Clear();                                                         //Textfeld mit dem Bohrungsdurchmesser wird zurückgesetzt
            Zahnbreite_txt.Clear();                                                 //Textfeld mit der Zahnbreite wird zurückgesetzt

            c_aus.Content = "";                                                     //Ausgabeinhalte im Tab für Außenverzahnung werden zurückgesetzt
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

            c_aus_Innen.Content = "";                                               //Ausgabeinhalte im Tab für Innenverzahnung werden zurückgesetzt
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

            cf_txt.Text = "0,167";                                                     //Textfeld mit dem Kopfspielfaktor wird auf Startwert zurückgesetzt
            ew_txt.Text = "20";                                                        //Textfeld mit dem Eingriffswinkel wird auf Normwert zurückgesetzt
            Modul_Dropbox.SelectedItem =CB2;                                           //Modul Dropbox wird auf Startwert 1 zurückgesetzt
            Kopfspielfaktor_CB.IsChecked = false;                                      //Checkbox für Kopfspielfaktor wird abgewählt und das Eingabefeld ausgegraut
            Eingriffswinkel_CB.IsChecked = false;                                      //Checkbox für Eingriffswinkel wird abgewählt und das Eingabefeld ausgegraut
            CB_SV.IsChecked = false;                                                   //Checkbox für Schrägverzahnung wird abgewählt und damit das Eingabefeld für den Schrägungswinkel ausgeblendet
            RB_MT.IsChecked = true;                                                    //Radiobutton für Berechnungsmodus Modul und Teilkreisdurchmesser wird aktiviert
        }

        //Event Click CATIA ÖFFNEN Button
        private void OPENCATIA_BTN_Click(object sender, EventArgs e)
        {
            bool Catia_running = CheckobCatialaeuft("CNEXT");
            if (Catia_running == true)
            {
                MessageBox.Show("CATIA ist schon geöffnet");
            }
            else if (Catia_running == false)
            {
                Process Catia = new Process();
                Catia.StartInfo.FileName = "CNEXT.exe";
                Catia.Start();
            }
        }
        //Überprüfung ob Catia läuft
        private bool CheckobCatialaeuft(string Processname)
        {

            return Process.GetProcessesByName(Processname).Length > 0;
        }


        //Event Click CATIA Button (CAD Modell erzeugen)
        private void CATIA_BTN_Click(object sender, EventArgs e)
        {
            
            if(ZR1.Catiakonstruktionserlaubnis == true)
            {
                CatiaControl();
            }
            else
            {
                MessageBox.Show("Zuerst korrekte Eingaben tätigen und Berechnung durchführen bevor CAD Modell erzeugt werden kann");
            }

            ZR1.Catiakonstruktionserlaubnis = false;
            
            
        }
        //Catia Control
        
        public void CatiaControl()
        {
            try
            {
                CatiaConnection cc = new CatiaConnection();

                // Finde Catia Prozess
                if (cc.CATIALaeuft())
                {
                    cc.ErzeugePart();
                    cc.GanzeZahnrad(ZR1);
                }
                else
                {
                    MessageBox.Show("Laufende Catia Application nicht gefunden");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception aufgetreten");
            }

        }

    }
}
