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
    public partial class DepartmanSec : Form
    {
        public DepartmanSec()
        {
            InitializeComponent();
        }
        public string selectedDepartment;
        private void DepartmanSec_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DbOperations.DepartmanListele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                selectedDepartment = dataGridView1.Rows[e.RowIndex].Cells["Departman Adı"].Value.ToString();
                this.Close();
            }
        }
    }
}
