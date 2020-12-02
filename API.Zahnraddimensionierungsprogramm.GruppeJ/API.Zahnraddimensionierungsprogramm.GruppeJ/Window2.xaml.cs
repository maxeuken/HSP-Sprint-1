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

namespace API.Zahnraddimensionierungsprogramm.GruppeJ
{
    /// <summary>
    /// Interaktionslogik für Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
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

        private double d;
        private double z;

        private void m_calc_btn_Click(object sender, RoutedEventArgs e)
        {
            string Zahlencheck = d_calc.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                d = Convert.ToDouble(d_calc.Text);
                if (d < 0)
                {
                    MessageBox.Show("Fehler: Der Teilkreisdurchmesser darf nicht unter 0 liegen. Bitte Eingabe korrigieren");
                }
            }
            else
            {
                MessageBox.Show("Bitte Eingabe zum Teilkreisdurchmesser überprüfen");
            }

            Zahlencheck = z_calc.Text;
            if (Zahlprüfung(Zahlencheck) == true)
            {
                z = Convert.ToDouble(z_calc.Text);
                if (z < 0)
                {
                    MessageBox.Show("Fehler: Die Zähnezahl darf nicht unter 0 liegen. Bitte Eingabe korrigieren");
                }
            }
            else
            {
                MessageBox.Show("Fehler: Bitte Eingabe zur Zähnezahl überprüfen");
            }

            m_calc.Content = d / z;
        }

    }
}
