using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace derskayıt
{
    public partial class Ogrenciekle : Form
    {
        public Ogrenciekle()
        {
            InitializeComponent();
        }

        private void Temizle()
        {
            // Tüm TextBox'ları temizler
            txtAd.Clear();
            txtSoyad.Clear();
            txtKimlikNo.Clear();
            txtdtarih.Clear();
            txtAdres.Clear();
            txtTelefon.Clear();
            txtEmail.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Veritabanı bağlantı dizesi
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=derskayit";

            using (var con = new Npgsql.NpgsqlConnection(connectionString))
            {
                try
                {
                    // Bağlantıyı aç
                    con.Open();

                    // Basit e-posta doğrulama deseni
                    string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                    // E-posta doğrulaması
                    if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, emailPattern))
                    {
                        MessageBox.Show("Geçerli bir e-posta adresi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Temizle();
                        return; // Eğer e-posta geçersizse işlemi durdur
                    }
                    
                    // Mevcut öğrenci kontrolü
                    string checkSql = "SELECT COUNT(*) FROM ogrenci WHERE kimlikNo = @p1";
                    using (var checkCmd = new Npgsql.NpgsqlCommand(checkSql, con))
                    {
                        checkCmd.Parameters.AddWithValue("@p1", txtKimlikNo.Text);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            // Öğrenci mevcutsa güncelleme yap
                            string updateSql = "UPDATE ogrenci SET ad = @p1, soyad = @p2, dtarih = @p3, adres = @p4, telefon = @p5, email = @p6 WHERE kimlikNo = @p7";
                            using (var updateCmd = new Npgsql.NpgsqlCommand(updateSql, con))
                            {
                                updateCmd.Parameters.AddWithValue("@p1", txtAd.Text);
                                updateCmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
                                updateCmd.Parameters.AddWithValue("@p3", DateTime.Parse(txtdtarih.Text));
                                updateCmd.Parameters.AddWithValue("@p4", txtAdres.Text);
                                updateCmd.Parameters.AddWithValue("@p5", txtTelefon.Text);
                                updateCmd.Parameters.AddWithValue("@p6", txtEmail.Text);
                                updateCmd.Parameters.AddWithValue("@p7", txtKimlikNo.Text);

                                updateCmd.ExecuteNonQuery();
                                MessageBox.Show("Kayıt başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Temizle();
                            }
                        }
                        else
                        {
                            // Öğrenci mevcut değilse ekleme yap
                            string insertSql = "INSERT INTO ogrenci (ad, soyad, kimlikNo, dtarih, adres, telefon, email) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)";
                            using (var insertCmd = new Npgsql.NpgsqlCommand(insertSql, con))
                            {
                                insertCmd.Parameters.AddWithValue("@p1", txtAd.Text);
                                insertCmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
                                insertCmd.Parameters.AddWithValue("@p3", txtKimlikNo.Text);
                                insertCmd.Parameters.AddWithValue("@p4", DateTime.Parse(txtdtarih.Text));
                                insertCmd.Parameters.AddWithValue("@p5", txtAdres.Text);
                                insertCmd.Parameters.AddWithValue("@p6", txtTelefon.Text);
                                insertCmd.Parameters.AddWithValue("@p7", txtEmail.Text);

                                insertCmd.ExecuteNonQuery();
                                MessageBox.Show("Kayıt başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Temizle();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata mesajı
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }


        private void kayityap_Load(object sender, EventArgs e)
        {

        }
    }
}
