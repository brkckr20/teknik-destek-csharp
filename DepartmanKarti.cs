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
    public partial class DepartmanKarti : Form
    {
        public DepartmanKarti()
        {
            InitializeComponent();
        }
        public int id = 0;
        private void DepartmanKarti_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DbOperations.DepartmanListele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (this.id == 0)
            {
                DbOperations.KullaniciVeyaDepartmanKaydet("D", txtKullanici);
                txtKullanici.Text = "";
            }
            else
            {
                DbOperations.KullaniciVeyaDepartmanGuncelle("D", txtKullanici, this.id);
            }
            dataGridView1.DataSource = DbOperations.DepartmanListele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                id = int.Parse(row.Cells["id"].Value.ToString());
                txtKullanici.Text = row.Cells["Departman Adı"].Value?.ToString();
            }
        }
    }
}
