using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zahnraddimensionierungsprogramm.GruppeJ
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "zahnradWerteTabelleDataSet.Zahnradwerte". Sie können sie bei Bedarf verschieben oder entfernen.
            this.zahnradwerteTableAdapter.Fill(this.zahnradWerteTabelleDataSet.Zahnradwerte);

        }

        private void zahnradwerteDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
