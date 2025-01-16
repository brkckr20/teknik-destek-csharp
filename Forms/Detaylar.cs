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
        public int _id;
        public string _name,_department,_date,_description;
        public Detaylar()
        {
            InitializeComponent();            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
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
