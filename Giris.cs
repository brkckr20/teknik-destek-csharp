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
    public partial class Giris : Form
    {
        private int id = 0;
        DataTable dataTable;

        public Giris()
        {
            InitializeComponent();

            cmbDurum.Items.AddRange(new string[] { "İptal", "Beklemede", "Tamamlandı" });
            cmbDurum.SelectedIndex = 1;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);

            radioButton1.Checked = true;

            VerileriYukle();

        }

        private void VerileriYukle()
        {
            string durumFiltre = null;

            if (radioButton2.Checked)
            {
                durumFiltre = "1";
            }
            else if (radioButton3.Checked)
            {
                durumFiltre = "2";
            }
            else if (radioButton4.Checked)
            {
                durumFiltre = "0";
            }
            dataTable = DbOperations.TalepListesi(durumFiltre);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                VerileriYukle();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDepartman.Text) ||
                string.IsNullOrWhiteSpace(txtKullanici.Text) ||
                string.IsNullOrWhiteSpace(txtBaslik.Text))
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurunuz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sonuc = DbOperations.TalepKaydet(
                txtDepartman.Text,
                txtKullanici.Text,
                txtBaslik.Text,
                txtAciklama.Text,
                cmbDurum.SelectedIndex.ToString(),
                dateTarih.Value,
                this.id
            );

            if (sonuc)
            {
                MessageBox.Show("Talep başarıyla kaydedildi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ((TextBox)ctrl).Clear();
                    }
                }

                VerileriYukle();
            }
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                id = int.Parse(row.Cells["Id"].Value.ToString());
                txtDepartman.Text = row.Cells["Departman"].Value?.ToString();
                txtKullanici.Text = row.Cells["Kullanici"].Value?.ToString();
                txtBaslik.Text = row.Cells["Baslik"].Value?.ToString();
                txtAciklama.Text = row.Cells["Aciklama"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["Tarih"].Value?.ToString(), out DateTime tarih))
                {
                    dateTarih.Value = tarih;
                }

                string durum = row.Cells["Durumu"].Value?.ToString();
                switch (durum)
                {
                    case "İptal":
                        cmbDurum.SelectedIndex = 0;
                        break;
                    case "Beklemede":
                        cmbDurum.SelectedIndex = 1;
                        break;
                    case "Tamamlandı":
                        cmbDurum.SelectedIndex = 2;
                        break;
                }
            }
        }

        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.NotEkle notEkle = new Forms.NotEkle(this.id);
            notEkle.ShowDialog();
        }

        private void detayGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Detaylar detaylar = new Forms.Detaylar();
            detaylar._id = this.id;
            detaylar._date = dateTarih.Value.ToString();
            detaylar._department = txtDepartman.Text;
            detaylar._name = txtKullanici.Text;
            detaylar._description = txtAciklama.Text;
            detaylar.ShowDialog();
        }

        private void btnDepartmanSec_Click(object sender, EventArgs e)
        {
            Forms.DepartmanSec departmanSec = new Forms.DepartmanSec();
            departmanSec.ShowDialog();
            txtDepartman.Text = departmanSec.selectedDepartment;
        }

        private void btnKullaniciSec_Click(object sender, EventArgs e)
        {
            Forms.KullaniciSec frm = new Forms.KullaniciSec();
            frm.ShowDialog();
            txtKullanici.Text = frm.selectedUser;
        }

        private void excelxlsxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                dt.Columns.Add(item.HeaderText);
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dataRow = dt.NewRow();
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value ?? DBNull.Value;
                }
                dt.Rows.Add(dataRow);
            }
            ExportOperations.ExportExcel(dt);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kayıt silinecek!\nBu işlem geri alınamaz!!!", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (DbOperations.TalepSil(this.id))
                {
                    VerileriYukle();
                    FormTemizle();
                }
            }
        }

        private void txtBaslikFiltre_TextChanged(object sender, EventArgs e)
        {
            SetGridViewWithFilter("Baslik",txtBaslikFiltre);
        }
        void SetGridViewWithFilter(string FieldName, TextBox textBox)
        {
            string filter = textBox.Text.ToLower();
            if (string.IsNullOrEmpty(filter))
            {
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                var filteredRows = dataTable.AsEnumerable()
                    .Where(row => row.Field<string>(FieldName).ToLower().Contains(filter))
                    .ToList();

                if (filteredRows.Count == 0)
                {
                    filteredRows = new List<DataRow>();
                }

                var filteredDataTable = filteredRows.Any() ? filteredRows.CopyToDataTable() : dataTable.Clone();

                dataGridView1.DataSource = filteredDataTable;

            }
        }

        private void txtKullaniciFiltre_TextChanged(object sender, EventArgs e)
        {
            SetGridViewWithFilter("Kullanici",txtKullaniciFiltre);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTemizle();
        }
        void FormTemizle()
        {
            txtDepartman.Text = "";
            txtKullanici.Text = "";
            txtBaslik.Text = "";
            txtAciklama.Text = "";
            dateTarih.Value = DateTime.Now;
            cmbDurum.SelectedIndex = 1;
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            VerileriYukle();
        }
    }
}
