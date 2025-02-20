using System;
using System.Drawing;
using System.Windows.Forms;

namespace Talepler
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }
        private void AcFormuSekmeOlarak<T>(string FormIsmi) where T : Form, new()
        {
            string formAdi = typeof(T).Name; 
            int sekmeGenislik = FormIsmi.Length * 8;
           // tabControl1.ItemSize = new Size(sekmeGenislik, 30);
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == formAdi)
                {
                    //tabControl1.SelectedTab = tp;
                    return;
                }
            }

            T frm = new T();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            TabPage yeniSekme = new TabPage(FormIsmi);
            yeniSekme.Controls.Add(frm);

            //tabControl1.TabPages.Add(yeniSekme);
            //tabControl1.SelectedTab = yeniSekme;

            frm.Show();
        }
        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            Giris frm = (Giris)Application.OpenForms["Giris"];
            if (frm == null)
            {
                frm = new Giris();
                tabControl1.TabPages.Add(frm);
            }
            else
            {
                tabControl1.TabPages[frm].Select();
            }
            //AcFormuSekmeOlarak<Giris>("Talep Girişi");
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            AcFormuSekmeOlarak<KullaniciKarti>("Kullanıcı Kartı");
        }

        private void ribbonButton3_Click(object sender, EventArgs e)
        {
            AcFormuSekmeOlarak<DepartmanKarti>("Departman Kartı");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            
        }
    }
}
