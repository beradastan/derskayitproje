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
    public partial class Gorevlisil : Form
    {
        public Gorevlisil()
        {
            InitializeComponent();
        }

        string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=derskayit";

        //form ilk yüklendiğing tüm görevlileri listele
        public void Listele()
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // PostgreSQL'e uygun SQL sorgusu
                    string sql = "SELECT kimlikNo AS \"kimlikno\", ad AS \"Ad\", soyad AS \"Soyad\", " +
                                 "dtarih AS \"Doğum Tarihi\", adres AS \"Adres\", telefon AS \"Telefon\", " +
                                 "email AS \"email\"  FROM ogretimgorevlisi";

                    // PostgreSQL komutu
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
        //butona basıldığında texboxa girilen kimlik numarasına göre öğretim görevlisi silme
        private void button1_Click(object sender, EventArgs e)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // PostgreSQL sorgusunu oluştur (silme işlemi)
                    string sql = "DELETE FROM ogretimgorevlisi WHERE kimlikno = @p1";

                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        // Parametreyi ekle
                        cmd.Parameters.AddWithValue("@p1", textBox1.Text);

                        // Sorguyu çalıştır
                        int sonuc = cmd.ExecuteNonQuery();

                        // Sonuç kontrolü
                        if (sonuc > 0)
                        {
                            MessageBox.Show("Kayıt Silindi", "Kayıt Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Kayıt Silinemedi", "Kayıt Silme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Listeyi yeniden yükle
            Listele();
        }
        //form yüklendiğinde listele fonksiyonunu çağır
        private void Gorevlisil_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
