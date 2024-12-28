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
    public partial class Dersİslemleri : Form
    {
        public Dersİslemleri()
        {
            InitializeComponent();
        }
        //panele ders ekleme formunu ekler
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Dersekle dersekle = new Dersekle();
            dersekle.TopLevel = false;
            dersekle.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(dersekle);
            dersekle.Show();
        }
        //panele ders listeleme formunu ekler
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            derslistele derslistele = new derslistele();
            derslistele.TopLevel = false;
            derslistele.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(derslistele);
            derslistele.Show();
        }
        //panele öğrenci kayıt formunu ekler
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            kayit kayityap = new kayit();
            kayityap.TopLevel = false;
            kayityap.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(kayityap);
            kayityap.Show();
        }
        //panele öğrenci silme formunu ekler
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            kayitsil kayitsil = new kayitsil();
            kayitsil.TopLevel = false;
            kayitsil.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(kayitsil);
            kayitsil.Show();
        }
        //panele dersi alan öğrenciler formunu ekler
        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            DersiAlanOgrenciler dersialanogrenciler = new DersiAlanOgrenciler();
            dersialanogrenciler.TopLevel = false;
            dersialanogrenciler.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(dersialanogrenciler);
            dersialanogrenciler.Show();
        }
    }
}
