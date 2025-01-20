using DocumentFormat.OpenXml.Office2010.Excel;
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
        private int id;
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
            if (this.id == 0)
            {
                DbOperations.KullaniciVeyaDepartmanKaydet("K", txtKullanici);
                VerileriYukle();
                txtKullanici.Text = "";
            }
            else
            {
                DbOperations.KullaniciVeyaDepartmanGuncelle("K", txtKullanici, this.id);
                VerileriYukle();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                id = int.Parse(row.Cells["id"].Value.ToString());
                txtKullanici.Text = row.Cells["Ad Soyad"].Value?.ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DbOperations.KullaniciVeyaDepartmanSil(this.id, "K");
            VerileriYukle();
        }
    }
}
