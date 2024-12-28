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
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }

        string connString = "Server=localhost;Port=5432;Database=derskayit;User Id=postgres;Password=1234;";
        //öğrencilerin bilgilerini tabloya listeleme
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
                    "FROM ogrenci " + // Buradaki boşluk eksikti, eklendi
                    "ORDER BY \"kimlikno\" ASC";


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
        //textbox ve comboboxa göre öğrenci ders kayıt işlemi
        private void button1_Click(object sender, EventArgs e)
        {
            // TextBox ve ComboBox'taki verileri al
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

                    // 1. Adım: Ders adına karşılık gelen dersKodu'nu al
                    string dersKoduQuery = "SELECT \"dersKodu\" FROM ders WHERE \"dersAdi\" = @dersAdi";
                    int dersKodu = 0;

                    using (var cmd = new NpgsqlCommand(dersKoduQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@dersAdi", dersAdi);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                            dersKodu = Convert.ToInt32(result);
                        else
                        {
                            MessageBox.Show("Girilen ders adı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // 2. Adım: ogrenci_ders tablosuna yeni kayıt ekle
                    string insertQuery = "INSERT INTO ogrenci_ders (kimlikno, derskodu) VALUES (@kimlikNo, @dersKodu)";

                    using (var cmd = new NpgsqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@kimlikNo", kimlikNo);
                        cmd.Parameters.AddWithValue("@dersKodu", dersKodu);

                        cmd.ExecuteNonQuery(); // Sorguyu çalıştır

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
        //form yüklendiğinde ders adlarını comboboxa yükleme ve öğrenci bilgilerini listeleme
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
    }
}