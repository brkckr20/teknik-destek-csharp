using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Talepler.Forms
{
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            LoadBackupPath();
        }
        private void LoadBackupPath()
        {
            textBox1.Text = "C:\\Users\\casper\\Desktop\\ExtremeTalepler\\ExtremeTalepler";
            //try
            //{
            //    // path.txt dosyasından yolu oku ve TextBox'a yazdır
            //    if (File.Exists("C:\\Users\\casper\\Desktop\\ExtremeTalepler\\ExtremeTalepler\\Talepler\\BackupPath.txt"))
            //    {
            //        string savedPath = File.ReadAllText("C:\\Users\\casper\\Desktop\\ExtremeTalepler\\ExtremeTalepler\\Talepler\\BackupPath.txt");
            //        string backupFileName = "yedek_" + DateTime.Now.ToString("dd.MM.yyyy") + ".bak";
            //        textBox1.Text = savedPath + "yedek_" + backupFileName;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Yedekleme yolu yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void SaveBackupPath(string path)
        {
            //try
            //{
            //    // Path.txt dosyasına yolu kaydet
            //    File.WriteAllText("path.txt", path);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Yedekleme yolu kaydedilirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //// SaveFileDialog ile dosya yolu seçme
            //using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            //{
            //    saveFileDialog.Filter = "SQL Server Backup Files (*.bak)|*.bak";

            //    // Kullanıcı dosya yolunu seçerse
            //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        string backupFilePath = saveFileDialog.FileName;

            //        // Seçilen yolu TextBox'a yazdır
            //        textBox1.Text = backupFilePath;

            //        // Yolu path.txt dosyasına kaydet
            //        SaveBackupPath(backupFilePath);
            //    }
            //}
        }
        private void BackupDatabase()
        {
            
            string backupFilePath = textBox1.Text + "\\Backup" + DateTime.UtcNow.Ticks +".bak";

            if (string.IsNullOrEmpty(backupFilePath))
            {
                MessageBox.Show("Lütfen yedekleme dosyasını seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Server=192.168.1.127,1433;Database=ExtremeTalepler;User Id=brk;Password=brkckr20;";

            // SQL yedekleme komutunu oluştur
            string query = $"BACKUP DATABASE ExtremeTalepler TO DISK = '{backupFilePath}'";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Yedekleme işlemini gerçekleştir
                        command.ExecuteNonQuery();
                        MessageBox.Show("Veritabanı yedeği başarıyla alındı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yedekleme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYedekle_Click(object sender, EventArgs e)
        {
            BackupDatabase();
        }
    }
}
