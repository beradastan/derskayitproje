using Npgsql;
using System.Data;
using System.Text.RegularExpressions;

using Npgsql;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace derskayıt
{
    public partial class Gorevliekle : Form
    {
        public Gorevliekle()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            // Veritabanı bağlantı dizesi
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=derskayit";

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    // Bağlantıyı aç
                    con.Open();

                    // Basit e-posta doğrulama deseni
                    string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                    // E-posta doğrulaması
                    if (!Regex.IsMatch(txtEmail.Text, emailPattern))
                    {
                        Temizle();
                        MessageBox.Show("Geçerli bir e-posta adresi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Eğer e-posta geçersizse işlemi durdur
                    }

                    // Mevcut görevlisi kontrolü
                    string checkSql = "SELECT COUNT(*) FROM ogretimgorevlisi WHERE kimlikNo = @p1";
                    using (var checkCmd = new NpgsqlCommand(checkSql, con))
                    {
                        checkCmd.Parameters.AddWithValue("@p1", txtKimlikNo.Text);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            // Görevli mevcutsa güncelleme yap
                            string updateSql = "UPDATE ogretimgorevlisi SET ad = @p1, soyad = @p2, dtarih = @p3, adres = @p4, telefon = @p5, email = @p6 WHERE kimlikNo = @p7";
                            using (var updateCmd = new NpgsqlCommand(updateSql, con))
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
                            // Görevli mevcut değilse ekleme yap
                            string insertSql = "INSERT INTO ogretimgorevlisi (ad, soyad, kimlikNo, dtarih, adres, telefon, email) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)";
                            using (var insertCmd = new NpgsqlCommand(insertSql, con))
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

        private void Gorevliekle_Load(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=derskayit";

            // Bağlantıyı aç
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();

                // SQL komutunu oluştur
                string sql = "SELECT * FROM ders";

                // PostgreSQL komutunu oluştur
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    // Veri adaptörünü oluştur
                    using (var da = new NpgsqlDataAdapter(cmd))
                    {
                        // Veriyi alacak DataTable oluştur
                        DataTable tablo = new DataTable();

                        // Veriyi DataTable'a doldur
                        da.Fill(tablo);

                        // ComboBox'ı doldur
                        // Buraya doldurma işlemi eklenebilir, eğer ComboBox ile ders listesi seçilmek isteniyorsa
                    }
                }
            }
        }
    }
}
