using Npgsql;

namespace derskayıt
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        public static string GirisYapanKimlikNo; // Giriş yapan kullanıcının kimlik numarasını tutar

        NpgsqlConnection con = new NpgsqlConnection("server=localHost; port=5432; Database=derskayit; User Id=postgres; password=1234");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciadi = textBox1.Text;
            string sifre = textBox2.Text;

            //Var olan bir kullanıcı ise rolünü belirlemek için kullanılır
            string sql = "SELECT rol FROM giris WHERE kullaniciadi = @kullaniciadi AND \"sifre\" = @sifre";
            NpgsqlCommand komut = new NpgsqlCommand(sql, con);

            // Parametreleri ekliyoruz
            komut.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
            komut.Parameters.AddWithValue("@sifre", sifre);

            try
            {
                con.Open();
                NpgsqlDataReader dr = komut.ExecuteReader();

                if (dr.Read()) // Eğer kayıt bulunursa
                {
                    GirisYapanKimlikNo = kullaniciadi;
                    //GirisYapanKimlikNo = dr["kullaniciadi"].ToString();
                    string rol = dr["rol"].ToString(); // Kullanıcının rolünü alıyoruz

                    // Kullanıcı rolüne göre farklı form açma işlemi
                    if (rol == "yonetici")
                    {
                        FormYonetici yoneticiForm = new FormYonetici();
                        yoneticiForm.Show();
                    }
                    else if (rol == "ogrenci")
                    {
                        FormOgrenci ogrenciForm = new FormOgrenci();
                        ogrenciForm.Show();
                    }
                    else if (rol == "ogretimgorevlisi")
                    {
                        FormOgretimGorevlisi ogretimForm = new FormOgretimGorevlisi();
                        ogretimForm.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Parola", "Giriş Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Giriş kutularını temizle
                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
