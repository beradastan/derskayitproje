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
    public partial class derslistele : Form
    {
        public derslistele()
        {
            InitializeComponent();
        }

        string connectionString = "Host=localhost;Username=postgres;Password=1234;Database=derskayit";
        //form yüklendiğinde tüm dersleri gösteren fonksiyon
        private void TumDersleriGoster()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Tüm dersleri getiren sorgu
                    string query = "SELECT * FROM dersler_view";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tüm dersler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //form yüklendiğinde comboboxı dolduran fonksiyon
        private void ComboBoxDoldur()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Benzersiz ders dönemlerini seçmek için sorgu
                    string query = "SELECT DISTINCT \"dersDonemi\" FROM ders ORDER BY \"dersDonemi\"";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["dersDonemi"].ToString());
                        }
                    }

                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0; // Varsayılan olarak ilk değeri seç
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ders dönemleri yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //form yüklenirken fonksiyonları çağırma
        private void derslistele_Load(object sender, EventArgs e)
        {
            TumDersleriGoster();
            ComboBoxDoldur();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //listeleme butonu 
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ders dönemi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int dersDonemi = int.Parse(comboBox1.SelectedItem.ToString());

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Seçilen ders dönemine göre view'dan filtrelenmiş veriler
                    string query = "SELECT * FROM dersler_view WHERE \"Ders Dönemi\" = @dersDonemi";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@dersDonemi", dersDonemi);

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veriler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
