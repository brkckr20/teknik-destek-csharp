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
    public partial class KullaniciSec : Form
    {
        public KullaniciSec()
        {
            InitializeComponent();
        }
        public string selectedUser;
        private void KullaniciSec_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DbOperations.KullaniciListele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedUser = dataGridView1.Rows[e.RowIndex].Cells["adSoyad"].Value.ToString();
                this.Close();
            }
        }
    }
}
