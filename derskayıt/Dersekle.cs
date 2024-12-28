using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace derskayıt
{
    public partial class Dersekle : Form
    {
        public Dersekle()
        {
            InitializeComponent();
        }


        
        string connectionString = "Server=localhost;Port=5432;Database=derskayit;User Id=postgres;Password=1234;";

        // ComboBox'ı dolduran fonksiyon
        public void ComboBoxDoldur()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT kimlikno FROM ogretimgorevlisi"; // Kimlik numaralarını alacak sorgu

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        // ComboBox'ı temizle
                        comboBox1.Items.Clear();

                        // Veritabanından okunan kimlik numaralarını ComboBox'a ekle
                        while (reader.Read())
                        {
                            // "kimlikno" değeri VARCHAR olduğu için string olarak alınıp eklenir
                            string kimlikNo = reader["kimlikno"].ToString();
                            comboBox1.Items.Add(kimlikNo); // ComboBox'a kimlik numarasını ekleyin
                        }

                        // ComboBox'ta sadece kimlik numarasının gözükmesi için ayar yapalım
                        comboBox1.DisplayMember = "kimlikno"; // Görüntülenecek değer kimlikno
                        comboBox1.ValueMember = "kimlikno"; // Seçilen değer de kimlikno

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kimlik numaraları yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        // DataGridView'i dolduran fonksiyon
        public void DataGridViewDoldur()
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Görevli bilgilerini alacak SQL sorgusu
                    string sql = "SELECT kimlikno AS \"Kimlik No\", ad AS \"Ad\", soyad AS \"Soyad\" " +
                     "FROM ogretimgorevlisi";


                    // PostgreSQL komutunu oluştur
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
                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Görevli bilgisi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        







        // Ekle Butonu
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=derskayit";

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Kullanıcıdan alınan değerler
                    string dersAdi = textBox1.Text;
                    int dersKodu = int.Parse(textBox2.Text);
                    int dersDonemi = int.Parse(textBox3.Text); // Ders dönemi integer olarak alınıyor
                    string kimlikNo = comboBox1.SelectedItem.ToString();

                    // Ders tablosuna ekleme (zaten varsa atla)
                    string dersKontrolSql = "SELECT COUNT(*) FROM ders WHERE \"dersKodu\" = @dersKodu";
                    using (var cmdKontrol = new NpgsqlCommand(dersKontrolSql, con))
                    {
                        cmdKontrol.Parameters.AddWithValue("@dersKodu", dersKodu);
                        int dersVar = Convert.ToInt32(cmdKontrol.ExecuteScalar());

                        if (dersVar == 0)
                        {
                            // Ders yoksa ekle
                            string dersEkleSql = "INSERT INTO ders (\"dersAdi\", \"dersKodu\", \"dersDonemi\") VALUES (@dersAdi, @dersKodu, @dersDonemi)";
                            using (var cmdDers = new NpgsqlCommand(dersEkleSql, con))
                            {
                                cmdDers.Parameters.AddWithValue("@dersAdi", dersAdi);
                                cmdDers.Parameters.AddWithValue("@dersKodu", dersKodu);
                                cmdDers.Parameters.AddWithValue("@dersDonemi", dersDonemi);
                                cmdDers.ExecuteNonQuery();
                            }
                        }
                    }

                    // Görevli-Ders ilişkisinin var olup olmadığını kontrol et
                    string gorevliDersKontrolSql = "SELECT COUNT(*) FROM gorevli_ders WHERE kimlikno = @kimlikno AND derskodu = @derskodu";
                    using (var cmdKontrol = new NpgsqlCommand(gorevliDersKontrolSql, con))
                    {
                        cmdKontrol.Parameters.AddWithValue("@kimlikno", kimlikNo);
                        cmdKontrol.Parameters.AddWithValue("@derskodu", dersKodu);
                        int iliskiVar = Convert.ToInt32(cmdKontrol.ExecuteScalar());

                        if (iliskiVar == 0)
                        {
                            // İlişki yoksa ekle
                            string gorevliDersSql = "INSERT INTO gorevli_ders (kimlikno, derskodu) VALUES (@kimlikno, @derskodu)";
                            using (var cmdGorevliDers = new NpgsqlCommand(gorevliDersSql, con))
                            {
                                cmdGorevliDers.Parameters.AddWithValue("@kimlikno", kimlikNo);
                                cmdGorevliDers.Parameters.AddWithValue("@derskodu", dersKodu);
                                cmdGorevliDers.ExecuteNonQuery();
                            }

                            MessageBox.Show("Görevli başarıyla derse atandı!", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Bu ders için zaten aynı görevli atanmış durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //form yüklenirken combobox ve datagridview doldurulur
        private void Dersekle_Load_1(object sender, EventArgs e)
        {
            ComboBoxDoldur();
            DataGridViewDoldur();
        }
    }
}
