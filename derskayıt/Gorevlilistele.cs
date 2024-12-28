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
    public partial class Gorevlilistele : Form
    {
        public Gorevlilistele()
        {
            InitializeComponent();
        }

        string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=derskayit";

        public void OgretimGorevlisi(string kimlikno)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Öğretim görevlisi ve ders bilgilerini çeken sorgu
                    string sql = "SELECT " +
                    "og.kimlikno AS \"Kimlik No\"," +
                    "og.ad AS \"Ad\", " +
                    "og.soyad AS \"Soyad\" ," +
                    "og.dtarih AS \"Doğum Tarihi\"," +
                    "og.adres AS \"Adres\", " +
                    "og.telefon AS \"Telefon\"," +
                    "d.\"dersKodu\" AS \"Ders Kodu\"," +
                    "d.\"dersAdi\" AS \"Ders Adı\"," +
                    "d.\"dersDonemi\" AS \"Ders Dönemi\" " +
                    "FROM ogretimgorevlisi og " +
                    "LEFT JOIN gorevli_ders ogd ON og.kimlikno = ogd.kimlikno " + // kimlikno ile eşleştir
                    "LEFT JOIN ders d ON ogd.dersKodu = d.\"dersKodu\" " +
                    "WHERE og.kimlikno = @kimlikno"; // Öğretim görevlisinin kimlik numarasına göre filtreleme

                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@kimlikno", kimlikno); // Parametreyi ekliyoruz

                        // Veriyi DataTable'a doldur
                        DataTable dt = new DataTable();
                        using (var da = new NpgsqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        // Boş kalan öğretim görevlisi sütunlarını temizle
                        string prevKimlikNo = "";
                        foreach (DataRow row in dt.Rows)
                        {
                            // Kimlik numarası tekrar ediyorsa, diğer sütunları boş bırak
                            if (row["Kimlik No"].ToString() == prevKimlikNo)
                            {
                                row["Kimlik No"] = DBNull.Value;
                                row["Ad"] = DBNull.Value;
                                row["Soyad"] = DBNull.Value;
                                row["Doğum Tarihi"] = DBNull.Value;
                                row["Adres"] = DBNull.Value;
                                row["Telefon"] = DBNull.Value;
                            }
                            else
                            {
                                prevKimlikNo = row["Kimlik No"].ToString(); // İlk kimlik numarasını kaydet
                            }
                        }

                        // DataGridView'e veri kaynağını bağla
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //butona tıklandığında kimlik numarasına göre öğretim görevlisi arama
        private void button1_Click(object sender, EventArgs e)
        {
            // TextBox'tan kimlik numarasını al
            string kimlikNo = textBox1.Text.Trim();

            // Kimlik numarası boş değilse, listeyi filtreleyerek göster
            if (!string.IsNullOrEmpty(kimlikNo))
            {

                OgretimGorevlisi(kimlikNo); // Listele fonksiyonunu kimlik numarasına göre çağır
            }
            else
            {
                MessageBox.Show("Kimlik numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //form ilk yüklendiğinde tüm öğretim görevlilerini listeleye fonksiyon
        public void Listele()
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Öğrenci bilgilerini çeken sorgu
                    string sql = "SELECT kimlikNo AS \"Kimlik No\", ad AS \"Ad\", soyad AS \"Soyad\", " +
                                 "dtarih AS \"Doğum Tarihi\", adres AS \"Adres\", telefon AS \"Telefon\" " +
                                 "FROM ogretimgorevlisi";

                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        // Veriyi alacak DataTable oluştur
                        DataTable dt = new DataTable();

                        // Veriyi DataTable'a doldur
                        using (var da = new NpgsqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        // DataGridView'e veri kaynağını bağla
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void Gorevlilistele_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
