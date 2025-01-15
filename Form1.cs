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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void AcFormuSekmeOlarak<T>() where T : Form, new()
        {
            // Form başlığını al
            string formAdi = typeof(T).Name;

            // Aynı form daha önce açılmış mı kontrol et
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == formAdi)
                {
                    tabControl1.SelectedTab = tp;
                    return;
                }
            }

            // Yeni form oluştur
            T frm = new T();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            // Yeni sekme oluştur
            TabPage yeniSekme = new TabPage(formAdi);
            yeniSekme.Controls.Add(frm);
            
            // Sekmeyi ekle ve seç
            tabControl1.TabPages.Add(yeniSekme);
            tabControl1.SelectedTab = yeniSekme;
            
            frm.Show();
        }

        private void talepGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcFormuSekmeOlarak<Giris>();
        }

        private void departmanVeKullanıcılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Departman formunuz varsa:
            // AcFormuSekmeOlarak<DepartmanForm>();
        }
    }
}
