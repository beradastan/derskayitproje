using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace derskayıt
{
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }

        string connString = "Server=localhost;Port=5432;Database=derskayit;User Id=postgres;Password=1234;";

        // Form yüklenirken ders adlarını combobox'a yükleme ve öğrenci bilgilerini listeleme
        private void kayit_Load(object sender, EventArgs e)
        {
            Listele();
            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT \"dersAdi\" FROM ders";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dersadi.Items.Add(reader["dersAdi"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dersler yüklenirken hata oluştu: " + ex.Message);
                }
            }
        }

        // Öğrencilerin bilgilerini tabloya listeleme
        public void Listele()
        {
            using (var con = new NpgsqlConnection(connString))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT " +
                    "kimlikNo AS \"Kimlik No\", " +
                    "ad AS \"Ad\", " +
                    "soyad AS \"Soyad\", " +
                    "dtarih AS \"Doğum Tarihi\", " +
                    "adres AS \"Adres\", " +
                    "telefon AS \"Telefon\" " +
                    "FROM ogrenci " ;

                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        DataTable dt = new DataTable();
                        using (var da = new NpgsqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // TextBox ve ComboBox'a göre Stored Procedure çağırarak öğrenci ders kaydı işlemi
        private void button1_Click(object sender, EventArgs e)
        {
            string kimlikNo = txtkimlikno.Text;
            string dersAdi = dersadi.SelectedItem?.ToString();

            // Kimlik numarası ve ders adı boş kontrolü
            if (string.IsNullOrEmpty(kimlikNo) || string.IsNullOrEmpty(dersAdi))
            {
                MessageBox.Show("Kimlik No ve Ders Adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // PostgreSQL bağlantısı
            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    // Stored Procedure çağrısı
                    using (var cmd = new NpgsqlCommand("CALL ogrencidersekle(@kimlikNo, @dersAdi)", conn))
                    {
                        cmd.Parameters.AddWithValue("@kimlikNo", kimlikNo);
                        cmd.Parameters.AddWithValue("@dersAdi", dersAdi);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Listeyi güncelle
                        Listele();
                        txtkimlikno.Clear();
                        dersadi.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
