using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Talepler.Forms
{
    public partial class TaleplerDetayliRapor : Form
    {
        public TaleplerDetayliRapor()
        {
            InitializeComponent();
        }
        DataTable dataTable;
        string filtre = "";
        private void TaleplerDetayliRapor_Load(object sender, EventArgs e)
        {
            RaporListele(filtre);
        }
        void RaporListele(string filtre)
        {
            dataTable = DbOperations.TaleplerDetayliListesi(filtre);
            dataGridView1.DataSource = dataTable;
        }

        private void bekleyenlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RaporListele("1");
        }

        private void tamamlananlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RaporListele("2");
        }

        private void iptalEdilenlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RaporListele("0");
        }

        private void excelOlarakAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportOperations.ExportExcel(dataTable);
        }
    }
}
