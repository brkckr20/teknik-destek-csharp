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
    public partial class NotEkle : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public int _id;
        public NotEkle(int id)
        {
            InitializeComponent();
            this._id = id;
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
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

        // Kapatma butonu için event handler
        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool sonuc = DbOperations.NotEkle(dateTimePicker1.Value,textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,this._id);
            if (sonuc)
            {
                MessageBox.Show("Not Ekleme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
       
