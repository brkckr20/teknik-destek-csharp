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

namespace Talepler.Forms
{
    public partial class Detaylar : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public int _id,_notId;
        public string _name,_department,_date,_description;
        public string _gorusmeNotu,_not1,_not2,_not3;
        //public DateTime _gorusmeTarihi;
        public Detaylar()
        {
            InitializeComponent();            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listeyiYenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DbOperations.DetaylariGetir(this._id);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                _notId = int.Parse(row.Cells["Id"].Value.ToString());
                _gorusmeNotu = row.Cells["GorusmeNotu"].Value?.ToString();
                _not1 = row.Cells["Not1"].Value?.ToString();
                _not2= row.Cells["Not2"].Value?.ToString();
                _not3 = row.Cells["Not3"].Value?.ToString();
            }
        }

        private void güncellemeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetayGuncelle detayGuncelle = new DetayGuncelle();
            detayGuncelle._detayId = _notId;
            detayGuncelle._gorusmeNotu = this._gorusmeNotu;
            detayGuncelle._not1 = this._not1;
            detayGuncelle._not2= this._not2;
            detayGuncelle._not3 = this._not3;
            detayGuncelle.ShowDialog();
        }

        private void kaydıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Not silinecek! Emin misiniz?\nBu işlem geri alınamaz!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                DbOperations.NotSil(_notId);
                dataGridView1.DataSource = DbOperations.DetaylariGetir(this._id);
            }
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Detaylar_Load(object sender, EventArgs e)
        {
            label2.Text += " " + this._date;
            label4.Text += " " + this._department;
            label3.Text += " " + this._name;
            lblAciklama.Text = this._description;
            dataGridView1.DataSource =  DbOperations.DetaylariGetir(this._id);
        }
    }
}
