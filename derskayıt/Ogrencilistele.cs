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
    public partial class Ogrencilistele : Form
    {
        public Ogrencilistele()
        {
            InitializeComponent();
        }

        string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=derskayit";

        public void Ogrenci(string kimlikNo)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Öğrenci ve ders bilgilerini çeken sorgu
                    string sql = "SELECT " +
                    "o.kimlikno AS \"Kimlik No\"," +
                    "o.ad AS \"Ad\", " +
                    "o.soyad AS \"Soyad\" ," +
                    "o.dtarih AS \"Doğum Tarihi\"," +
                    "o.adres AS \"Adres\", " +
                    "o.telefon AS \"Telefon\"," +
                    "d.\"dersKodu\" AS \"Ders Kodu\"," +
                    "d.\"dersAdi\" AS \"Ders Adı\"," +
                    "d.\"dersDonemi\" AS \"Ders Dönemi\" " +
                    "FROM ogrenci o " +
                    "LEFT JOIN ogrenci_ders od ON o.kimlikno = od.kimlikno " +
                    "LEFT JOIN ders d ON od.derskodu = d.\"dersKodu\" " +
                    "WHERE o.kimlikno = @kimlikNo";

                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@kimlikNo", kimlikNo);

                        // Veriyi DataTable'a doldur
                        DataTable dt = new DataTable();
                        using (var da = new NpgsqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        // Boş kalan öğrenci sütunlarını temizle
                        string prevKimlikNo = "";
                        foreach (DataRow row in dt.Rows)
                        {
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
                                prevKimlikNo = row["Kimlik No"].ToString();
                            }
                        }

                        // DataGridView'e bağla
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


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
                                 "FROM ogrenci";

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

        private void listele_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //textboxa girilen kimlik numarasına göre öğrenci bilgilerini getirir
        private void button1_Click(object sender, EventArgs e)
        {
            // TextBox'tan kimlik numarasını al
            string kimlikNo = textBox1.Text.Trim();

            // Kimlik numarası boş değilse, listeyi filtreleyerek göster
            if (!string.IsNullOrEmpty(kimlikNo))
            {

                Ogrenci(kimlikNo); // Listele fonksiyonunu kimlik numarasına göre çağır
            }
            else
            {
                MessageBox.Show("Kimlik numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
