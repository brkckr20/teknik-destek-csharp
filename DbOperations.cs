using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace Talepler
{
    public static class DbOperations
    {
        private static string connectionString = @"Server=localhost;Database=ExtremeTalepler;Trusted_Connection=True;";

        public static bool TalepKaydet(string departman, string kullanici, string baslik, string aciklama, string durum, DateTime tarih, int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql;

                    if (id == 0)
                    {
                        sql = @"INSERT INTO TechnicalSupport (Departman, Kullanici, Baslik, Aciklama, Durumu, Tarih,Durum) 
                               VALUES (@departman, @kullanici, @baslik, @aciklama, @durum, @kayitTarihi,0)";
                    }
                    else
                    {
                        sql = @"UPDATE TechnicalSupport 
                               SET Departman = @departman,
                                   Kullanici = @kullanici, 
                                   Baslik = @baslik,
                                   Aciklama = @aciklama,
                                   Durumu = @durum,
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
                                    TS.Id,
                                    Departman, 
                                    Kullanici, 
                                    Baslik, 
                                    Aciklama, 
                                    CASE Durumu 
                                        WHEN '0' THEN 'İptal'
                                        WHEN '1' THEN 'Beklemede'
                                        WHEN '2' THEN 'Tamamlandı'
                                        ELSE 'Belirsiz'
                                    END as Durumu, 
                                    Tarih,
                                    CASE 
                                        WHEN MAX(N.RefNo) IS NOT NULL THEN 'Güncelleme var' 
                                        ELSE '' 
                                    END AS Güncelleme
                                FROM 
                                    TechnicalSupport TS
                                LEFT JOIN 
                                    Notes N ON TS.Id = N.RefNo
	                                WHERE (@durumFiltre IS NULL OR Durumu = @durumFiltre)
                                GROUP BY
                                    TS.Id, Departman, Kullanici, Baslik, Aciklama, Durumu, Tarih
                                ORDER BY 
                                    Tarih DESC;
                                ";

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

        public static DataTable DepartmanListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "select id,DepartmanAdi [Departman Adı] from Departments";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                throw;
            }
        }
        public static DataTable KullaniciListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "select id,adSoyad [Ad Soyad] from Users";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                throw;
            }
        }

        public static bool TalepSil(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "delete from TechnicalSupport where Id=@Id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static DataTable DetaylariGetir(int RefNo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"select * from Notes where RefNo = @RefNo";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@RefNo", RefNo);

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
        public static void KullaniciVeyaDepartmanKaydet(string Type, TextBox veri)
        {
            string islem = null;
            if (Type == "K")
            {
                islem = "Kullanıcı";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"INSERT INTO Users (adSoyad) VALUES (@adSoyad)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@adSoyad", veri.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"{islem} kayıt işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{islem} ekleme hatası :" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
            else if (Type == "D")
            {
                islem = "Departman";
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"INSERT INTO Departments (DepartmanAdi) VALUES (@DepartmanAdi)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@DepartmanAdi", veri.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"{islem} kayıt işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{islem} ekleme hatası :" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        public static void KullaniciVeyaDepartmanGuncelle(string Type, TextBox veri,int id)
        {
            if (Type == "K")
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"update Users set adSoyad = @adSoyad where id = @id";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@adSoyad", veri.Text);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Kullanıcı kayıt güncelleme başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kullanıcı ekleme hatası :" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
            else if (Type == "D")
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = @"update Departments set DepartmanAdi = @departmanAdi where id=@id";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@departmanAdi", veri.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Departman güncelleme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Departman ekleme hatası :" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        public static bool NotSil(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "delete from Notes where Id=@Id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool NotGuncelle(string GorusmeNotu, string Not1, string Not2, string Not3, int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql;

                    sql = @"UPDATE Notes 
                               SET GorusmeNotu = @gorusmenotu,
                                   Not1= @not1, 
                                   Not2= @not2,
                                   Not3= @not3
                               WHERE Id = @id";


                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@gorusmenotu", GorusmeNotu);
                        cmd.Parameters.AddWithValue("@not1", Not1);
                        cmd.Parameters.AddWithValue("@not2", Not2);
                        cmd.Parameters.AddWithValue("@not3", Not2);
                        cmd.Parameters.AddWithValue("@id", id);

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

        public static void KullaniciVeyaDepartmanSil(int id,string tip)
        {
            if (id == 0)
            {
                MessageBox.Show("Kayıt silebilmek için bir kayıt seçmeniz gerekmektedir!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "";
                if (tip == "K")
                {
                    sql = "delete from Users where id=@id";
                }
                else if (tip == "D")
                {
                    sql = "delete from Departments where id=@id";
                }
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}