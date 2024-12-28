using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace derskayıt
{
    public partial class kayitsil : Form
    {
        public kayitsil()
        {
            InitializeComponent();
        }

        string connString = "Server=localhost;Port=5432;Database=derskayit;User Id=postgres;Password=1234;";

        private void kayitsil_Load(object sender, EventArgs e)
        {
            OgrenciDersleriListele();
            DersleriYukle();
        }
        //comboboxa dersleri yükleme
        private void DersleriYukle()
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT \"dersKodu\", \"dersAdi\" FROM ders";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dersListesi = new DataTable();
                        dersListesi.Load(reader);

                        // ComboBox'a veri bağla
                        ders.DataSource = dersListesi;
                        ders.DisplayMember = "dersAdi"; // Kullanıcıya gösterilecek olan ders adı
                        ders.ValueMember = "dersKodu"; // Arkada işlem yapılacak ders kodu
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dersler yüklenirken hata oluştu: " + ex.Message);
                }
            }
        }

        private void OgrenciDersleriListele()
        {
            // DataGridView'i temizle
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Sütunları yeniden oluştur
            dataGridView1.Columns.Add("kimlikNo", "Kimlik No");
            dataGridView1.Columns.Add("ad", "Ad");
            dataGridView1.Columns.Add("soyad", "Soyad");
            dataGridView1.Columns.Add("dersBilgi", "Ders (Kod)");

            // Veritabanına bağlantı kur ve öğrenci ve ders bilgilerini al
            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query =
                    "SELECT " +
                    "ogrenci.kimlikno, " +
                    "ogrenci.ad, " +
                    "ogrenci.soyad, " +
                    "ogrenci_ders.derskodu, " +
                    "ders.\"dersAdi\" " +
                    "FROM ogrenci " +
                    "JOIN ogrenci_ders ON ogrenci.kimlikno = ogrenci_ders.kimlikno " +
                    "JOIN ders ON ogrenci_ders.derskodu = ders.\"dersKodu\"";


                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string kimlikNo = reader["kimlikno"] != DBNull.Value ? reader["kimlikno"].ToString() : string.Empty;
                            string ad = reader["ad"] != DBNull.Value ? reader["ad"].ToString() : string.Empty;
                            string soyad = reader["soyad"] != DBNull.Value ? reader["soyad"].ToString() : string.Empty;
                            string dersAdi = reader["dersAdi"] != DBNull.Value ? reader["dersAdi"].ToString() : string.Empty;
                            string dersKodu = reader["derskodu"] != DBNull.Value ? reader["derskodu"].ToString() : string.Empty;

                            // Ders adı ve kodunu birleştirerek tek bir sütunda göster
                            string dersBilgi = $"{dersAdi} ({dersKodu})";

                            // DataGridView'e yeni satır ekle
                            dataGridView1.Rows.Add(kimlikNo, ad, soyad, dersBilgi);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanından veri alınırken hata oluştu: " + ex.Message);
                }
            }
        }
        //girilen kimlik bilgili öğrencinin ders kaydını silme
        private void button1_Click(object sender, EventArgs e)
        {
            string kimlikNo = kimlikno.Text;  // Öğrenci kimlik numarasını TextBox'tan al
            string dersKodu = ders.SelectedValue?.ToString();  // ComboBox'tan seçilen ders kodunu al

            // Eğer her iki değer de doluysa (KimlikNo ve DersKodu), silme işlemini yap
            if (!string.IsNullOrEmpty(kimlikNo) && !string.IsNullOrEmpty(dersKodu))
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    try
                    {
                        conn.Open();

                        // Silme sorgusu
                        string query = @"
                    DELETE FROM ogrenci_ders
                    WHERE kimlikno = @kimlikNo AND derskodu = @dersKodu";

                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            // Parametreleri ekleyin
                            cmd.Parameters.AddWithValue("@kimlikNo", kimlikNo);
                            cmd.Parameters.AddWithValue("@dersKodu", int.Parse(dersKodu)); // Ders kodunu int olarak al

                            // Sorguyu çalıştır ve kayıt silinsin
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Ders kaydı başarıyla silindi.");
                                OgrenciDersleriListele(); // Listeyi güncelle
                            }
                            else
                            {
                                MessageBox.Show("Kayıt bulunamadı.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen kimlik numarasını ve ders kodunu giriniz.");
            }
        }
    }
}
