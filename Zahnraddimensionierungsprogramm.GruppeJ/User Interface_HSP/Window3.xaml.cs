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
using System.Windows.Shapes;

namespace User_Interface_HSP
{
    /// <summary>
    /// Interaktionslogik für Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

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

        public double bd;


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Zahlencheck = Eingabefeld.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                bd = Convert.ToDouble(Eingabefeld.Text);
                    if (bd < 6)
                    {
                    MessageBox.Show("Fehler: Eingangswellendurchmesser darf nicht unter 6mm liegen. Bitte Eingabe überprüfen");

                    }
                    if (bd >= 6 && bd < 8)
                    {
                    b.Content = 2;
                    h.Content = 2;
                    t1.Content = 1.2;
                    t2.Content = 1;
                    }
                    if (bd >= 8 && bd < 10)
                    {
                        b.Content = 3;
                        h.Content = 3;
                        t1.Content = 1.8;
                        t2.Content = 1.4;
                    }
                    if (bd >= 10 && bd < 12)
                    {
                        b.Content = 4;
                        h.Content = 4;
                        t1.Content = 2.5;
                        t2.Content = 1.8;
                    }
                    if (bd >= 12 && bd < 17)
                    {
                        b.Content = 5;
                        h.Content = 5;
                        t1.Content = 3;
                        t2.Content = 2.3;
                    }
                    if (bd >= 17 && bd < 22)
                    {
                        b.Content = 6;
                        h.Content = 6;
                        t1.Content = 3.5;
                        t2.Content = 2.8;
                    }
                    if (bd >= 22 && bd < 30)
                    {
                        b.Content = 8;
                        h.Content = 7;
                        t1.Content = 4;
                        t2.Content = 3.3;
                    }
                    if (bd >= 30 && bd < 38)
                    {
                        b.Content = 10;
                        h.Content = 8;
                        t1.Content = 5;
                        t2.Content = 3.3;
                    }
                    if (bd >= 38 && bd < 44)
                    {
                        b.Content = 12;
                        h.Content = 8;
                        t1.Content = 5;
                        t2.Content = 3.3;
                    }
                    if (bd >= 44 && bd < 50)
                    {
                        b.Content = 14;
                        h.Content = 9;
                        t1.Content = 5.5;
                        t2.Content = 3.8;
                    }
                    if (bd >= 50 && bd < 58)
                    {
                        b.Content = 16;
                        h.Content = 10;
                        t1.Content = 6;
                        t2.Content = 4.3;
                    }
                    if (bd >= 58 && bd < 65)
                    {
                        b.Content = 18;
                        h.Content = 11;
                        t1.Content = 7;
                        t2.Content = 4.4;
                    }
                    if (bd >= 68 && bd < 75)
                    {
                        b.Content = 20;
                        h.Content = 12;
                        t1.Content = 7.5;
                        t2.Content = 4.9;
                    }
            }
            else
            {
                MessageBox.Show("Bitte Eingabe zum Eingangswellendurchmesser überprüfen");
            }


        }
    }
}
