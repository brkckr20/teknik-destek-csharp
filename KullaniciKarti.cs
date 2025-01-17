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
    public partial class KullaniciKarti : Form
    {
        public KullaniciKarti()
        {
            InitializeComponent();
        }

        private void KullaniciKarti_Load(object sender, EventArgs e)
        {
            VerileriYukle();
        }
        void VerileriYukle()
        {
            dataGridView1.DataSource = DbOperations.KullaniciListele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            DbOperations.KullaniciVeyaDepartmanKaydet("K", txtKullanici);
            VerileriYukle();
            txtKullanici.Text = "";
        }
    }
}
