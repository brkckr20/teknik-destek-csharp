using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Talepler
{
    public partial class DepartmanKarti : Form
    {
        public DepartmanKarti()
        {
            InitializeComponent();
        }

        private void DepartmanKarti_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DbOperations.DepartmanListele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            DbOperations.KullaniciVeyaDepartmanKaydet("D",txtKullanici);
            txtKullanici.Text = "";
            dataGridView1.DataSource = DbOperations.DepartmanListele();
        }
    }
}
