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
    public partial class DetayGuncelle : Form
    {
        public DetayGuncelle()
        {
            InitializeComponent();
        }
        public int _detayId = 0;
        public string _gorusmeNotu,_not1,_not2,_not3;

        private void button1_Click(object sender, EventArgs e)
        {
            DbOperations.NotGuncelle(txtGorusmeNot.Text, txtNot1.Text, txtNot2.Text, txtNot3.Text, _detayId);
            MessageBox.Show("Not güncelleme işlemi başarılı!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void DetayGuncelle_Load(object sender, EventArgs e)
        {
            txtGorusmeNot.Text = this._gorusmeNotu;
            txtNot1.Text = this._not1;
            txtNot2.Text = this._not2;
            txtNot3.Text = this._not3;
        }
    }
}
