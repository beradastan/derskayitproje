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

namespace derskayıt
{
    public partial class FormOgretimGorevlisi : Form
    {
        public FormOgretimGorevlisi()
        {
            InitializeComponent();
        }

        string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=derskayit";
        //tablodan seçilen dersin sınıf listesini oluşturan fonksiyon
        void OgrencileriListele()
        {
            // DataGridView'deki seçili dersin dersKodu'nu alıyoruz.
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki dersKodu'nu alıyoruz.
                int dersKodu = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Ders Kodu"].Value);

                // Öğrencileri listeleyecek SQL sorgusu
                string sql = @"SELECT o.kimlikno AS ""Kimlik No"", 
                      CONCAT(o.ad, ' ', o.soyad) AS ""Ad Soyad""
                    FROM ogrenci o 
                    INNER JOIN ogrenci_ders od ON o.kimlikno = od.kimlikno 
                    WHERE od.dersKodu = @dersKodu";


                // Veritabanı bağlantısı oluşturuluyor
                using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
                using (NpgsqlCommand komut = new NpgsqlCommand(sql, con))
                {
                    komut.Parameters.AddWithValue("@dersKodu", dersKodu);

                    try
                    {
                        con.Open();
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt; // Öğrencileri başka bir DataGridView'e dolduruyoruz.
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir ders seçin.");
            }
        }
        //bilgileri güncelleme kısmındaki label ve textboxları gizleyen fonksiyon
        void Gizle()
        {
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            txtAd.Hide();
            txtAdres.Hide();
            txtdtarih.Hide();
            txtEmail.Hide();
            txtSifre.Hide();
            txtSoyad.Hide();
            txtTelefon.Hide();
            button4.Hide();
        }
        //bilgileri güncelleme kısmındaki label ve textboxları gösteren fonksiyon
        void Göster()
        {
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            label6.Show();
            label7.Show();
            txtAd.Show();
            txtAdres.Show();
            txtdtarih.Show();
            txtEmail.Show();
            txtSifre.Show();
            txtSoyad.Show();
            txtTelefon.Show();
            button4.Show();
        }
        //giriş yapan kullanıcının bilgilerini güncelleyen fonksiyon
        private void BilgileriGuncelle()
        {
            string kimlikNo = Giris.GirisYapanKimlikNo; // Giriş yapan öğretim görevlisinin kimlik numarası.
            string yeniAd = txtAd.Text;
            string yeniSoyad = txtSoyad.Text;
            string yeniEmail = txtEmail.Text;
            string yeniTelefon = txtTelefon.Text;

            // Tarih formatını doğruluyoruz. Kullanıcıdan gelen tarih, DateTime türüne dönüştürülür.
            DateTime yeniDogumTarihi;
            if (!DateTime.TryParse(txtdtarih.Text, out yeniDogumTarihi))
            {
                MessageBox.Show("Geçerli bir tarih giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Geçersiz tarih durumunda işlemi sonlandırıyoruz.
            }

            string yeniAdres = txtAdres.Text;
            string yeniSifre = txtSifre.Text;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Ogretimgorevlisi tablosunu güncelleyen sorgu
                    string query1 = "UPDATE ogretimgorevlisi " +
                                    "SET ad = @ad, soyad = @soyad, email = @email, telefon = @telefon, dtarih = @dogumTarihi, adres = @adres " +
                                    "WHERE kimlikno = @kimlikNo";

                    using (var cmd1 = new NpgsqlCommand(query1, conn))
                    {
                        cmd1.Parameters.AddWithValue("@ad", yeniAd);
                        cmd1.Parameters.AddWithValue("@soyad", yeniSoyad);
                        cmd1.Parameters.AddWithValue("@email", yeniEmail);
                        cmd1.Parameters.AddWithValue("@telefon", yeniTelefon);
                        cmd1.Parameters.AddWithValue("@dogumTarihi", yeniDogumTarihi);  // DateTime parametre olarak gönderildi
                        cmd1.Parameters.AddWithValue("@adres", yeniAdres);
                        cmd1.Parameters.AddWithValue("@kimlikno", kimlikNo);

                        int rowsAffected1 = cmd1.ExecuteNonQuery();
                        if (rowsAffected1 > 0)
                        {
                            MessageBox.Show("Kişisel bilgiler başarıyla güncellendi.");
                        }
                        else
                        {
                            MessageBox.Show("Kişisel bilgi güncelleme işlemi başarısız.");
                        }
                    }

                    // Giris tablosunu güncelleyen sorgu (sadece şifre)
                    string query2 = "UPDATE giris " +
                                    "SET sifre = @sifre " +
                                    "WHERE kullaniciadi = @kimlikNo";

                    using (var cmd2 = new NpgsqlCommand(query2, conn))
                    {
                        cmd2.Parameters.AddWithValue("@sifre", yeniSifre);
                        cmd2.Parameters.AddWithValue("@kimlikNo", kimlikNo);

                        int rowsAffected2 = cmd2.ExecuteNonQuery();
                        if (rowsAffected2 > 0)
                        {
                            MessageBox.Show("Şifre başarıyla güncellendi.");
                        }
                        else
                        {
                            MessageBox.Show("Şifre güncelleme işlemi başarısız.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }
        //gorevlinin sorumlu olduğu dersleri listeleme fonksiyonu
        private void VerilenDersleriListele()
        {
            string kimlikNo = Giris.GirisYapanKimlikNo; // Giriş yapanın kullanıcı adı öğretim görevlisinin kimlik numarasıdır.

            if (string.IsNullOrEmpty(kimlikNo))
            {
                MessageBox.Show("Kimlik numarası geçersiz.");
                return;
            }

            string sql = @"SELECT d.""dersAdi"" AS ""Ders Adı"", d.""dersKodu"" AS ""Ders Kodu"", d.""dersDonemi"" AS ""Ders Dönemi"", d.ogrencisayisi AS ""Öğrenci Sayısı""
               FROM ders d
               INNER JOIN gorevli_ders gd ON d.""dersKodu"" = gd.dersKodu
               WHERE gd.""kimlikno"" = @kimlikNo";


            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            using (NpgsqlCommand komut = new NpgsqlCommand(sql, con))
            {
                komut.Parameters.AddWithValue("@kimlikNo", kimlikNo);

                try
                {
                    con.Open();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt; // Dersleri bir DataGridView'e dolduruyoruz.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
        //butona tıklandığında verilen dersleri listeleme fonksiyonunu çağırır
        private void button1_Click(object sender, EventArgs e)
        {
            Gizle();
            dataGridView1.Show();
            VerilenDersleriListele();
        }
        //form ilk yüklenirken gizlenmesi gereken label , textbox ve tabloyu gizler
        private void FormOgretimGorevlisi_Load(object sender, EventArgs e)
        {
            Gizle();
            dataGridView1.Hide();
        }
        //butona tıklandığında öğrencileri listeleme fonksiyonunu çağırır
        private void button2_Click(object sender, EventArgs e)
        {
            Gizle();
            OgrencileriListele();
        }
        //butona tıklandığında bilgileri güncelleme kısmındaki label ve textboxları gösterir
        private void button3_Click(object sender, EventArgs e)
        {
            Göster();
            dataGridView1.Hide();

        }
        //butona tıklandığında bilgileri güncelleme fonksiyonunu çağırır
        private void button4_Click(object sender, EventArgs e)
        {
            BilgileriGuncelle();
        }
    }
}
