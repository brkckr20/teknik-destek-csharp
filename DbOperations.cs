using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Talepler
{
    public static class DbOperations
    {
        private static string connectionString = @"Server=localhost;Database=ExtremeTalepler;Trusted_Connection=True;";

        public static bool TalepKaydet(string departman, string kullanici, string baslik, string aciklama, string durum,DateTime tarih, int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql;
                    
                    if (id == 0)
                    {
                        sql = @"INSERT INTO TechnicalSupport (Departman, Kullanici, Baslik, Aciklama, Durum, Tarih) 
                               VALUES (@departman, @kullanici, @baslik, @aciklama, @durum, @kayitTarihi)";
                    }
                    else
                    {
                        sql = @"UPDATE TechnicalSupport 
                               SET Departman = @departman,
                                   Kullanici = @kullanici, 
                                   Baslik = @baslik,
                                   Aciklama = @aciklama,
                                   Durum = @durum,
                                   Tarih = @kayitTarihi
                               WHERE Id = @id";
                    }

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@departman", departman);
                        cmd.Parameters.AddWithValue("@kullanici", kullanici);
                        cmd.Parameters.AddWithValue("@baslik", baslik);
                        cmd.Parameters.AddWithValue("@aciklama", aciklama);
                        cmd.Parameters.AddWithValue("@durum", durum);
                        cmd.Parameters.AddWithValue("@kayitTarihi", tarih);
                        
                        if (id != 0)
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                        }

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static DataTable TalepListesi(string durumFiltre = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT 
                                    Id,
                                    Departman, 
                                    Kullanici, 
                                    Baslik, 
                                    Aciklama, 
                                    CASE Durum 
                                        WHEN '0' THEN 'İptal'
                                        WHEN '1' THEN 'Beklemede'
                                        WHEN '2' THEN 'Tamamlandı'
                                        ELSE 'Belirsiz'
                                    END as Durum, 
                                    Tarih 
                                FROM TechnicalSupport 
                                WHERE (@durumFiltre IS NULL OR Durum = @durumFiltre)
                                ORDER BY Tarih DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@durumFiltre", 
                            string.IsNullOrEmpty(durumFiltre) ? (object)DBNull.Value : durumFiltre);

                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken hata oluştu: " + ex.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static bool NotEkle(DateTime GorusmeTarihi, string GorusmeNotu, string Not1, string Not2, string Not3, int Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"INSERT INTO Notes (GorusmeTarihi, GorusmeNotu, Not1, Not2, Not3, RefNo) 
                                   VALUES (@GorusmeTarihi, @GorusmeNotu, @Not1, @Not2, @Not3, @RefNo)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@GorusmeTarihi", GorusmeTarihi);
                        cmd.Parameters.AddWithValue("@GorusmeNotu", GorusmeNotu);
                        cmd.Parameters.AddWithValue("@Not1", Not1);
                        cmd.Parameters.AddWithValue("@Not2", Not2);
                        cmd.Parameters.AddWithValue("@Not3", Not3);
                        cmd.Parameters.AddWithValue("@RefNo", Id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not eklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}