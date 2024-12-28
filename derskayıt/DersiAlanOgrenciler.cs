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
    public partial class DersiAlanOgrenciler : Form
    {
        public DersiAlanOgrenciler()
        {
            InitializeComponent();
        }

        string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=derskayit";
        //comboBox1'e dersleri dolduran fonksiyon
        public void ComboBoxDoldur()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT \"dersAdi\" FROM ders";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        comboBox1.Items.Clear();

                        while (reader.Read())
                        {
                            string dersAdi = reader["dersAdi"].ToString();
                            comboBox1.Items.Add(dersAdi); // Sadece "dersAdi" ekleniyor
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dersler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //form yüklenirken combobox1 doldurulur ve label gizlenir
        private void DersiAlanOgrenciler_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            ComboBoxDoldur();
        }
        //yukarıdaki labelı sayfanın ortasına alır
        private void OrtalaLabel(Label label)
        {
            // Formun genişliği ve Label'ın genişliğine göre yatay merkez ayarlama
            int formWidth = this.ClientSize.Width; // Formun genişliği
            int labelWidth = label.Width; // Label'ın genişliği
            int labelX = (formWidth - labelWidth) / 2; // Yeni X pozisyonu (ortalanmış)

            label.Location = new Point(labelX, label.Location.Y); // Label'ın yeni konumu
        }

        //listeleme butonu 
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ders seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dersAdi = comboBox1.SelectedItem.ToString(); // Seçilen ders adı alınır
            string bdersAdi = dersAdi.ToUpper();
            label1.Text = $"{bdersAdi} DERSİNE KAYITLI ÖĞRENCİLER";
            OrtalaLabel(label1);
            label1.Visible=true;


            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Dersi alan öğrencileri listeleyen sorgu
                    string query = "SELECT o.kimlikno AS \"Kimlik No\", " +
                                   "o.ad || ' ' || o.soyad AS \"Ad Soyad\" " + // Ad ve Soyadı birleştiriyoruz
                                   "FROM ogrenci o " +
                                   "INNER JOIN ogrenci_ders od ON o.kimlikno = od.kimlikno " +
                                   "INNER JOIN ders d ON od.derskodu = d.\"dersKodu\" " +
                                   "WHERE d.\"dersAdi\" = @dersAdi"; // Ders adına göre filtreleme

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@dersAdi", dersAdi);

                        DataTable dt = new DataTable();
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        dataGridView1.DataSource = dt; // DataGridView’e verileri bağla
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Öğrenciler listelenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
