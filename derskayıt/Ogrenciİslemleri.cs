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
    public partial class Ogrenciİslemleri : Form
    {
        public Ogrenciİslemleri()
        {
            InitializeComponent();
        }
        //panele ögrenci ekleme formunu ekler
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Ogrenciekle ogrenciekle = new Ogrenciekle();
            ogrenciekle.TopLevel = false;
            ogrenciekle.FormBorderStyle = FormBorderStyle.None;
            //ogrenciekle.Size = this.panel1.ClientSize;
            //ogrenciekle.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(ogrenciekle);
            ogrenciekle.Show();
        }
        //panele ögrenci silme formunu ekler
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Ogrencisil ogrencisil = new Ogrencisil();
            ogrencisil.TopLevel = false;
            ogrencisil.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add((ogrencisil));
            ogrencisil.Show();
        }
        //panele ögrenci listeleme formunu ekler
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Ogrencilistele ogrencilistele = new Ogrencilistele();
            ogrencilistele.TopLevel = false;
            ogrencilistele.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add((ogrencilistele));
            ogrencilistele.Show();
        }
    }
}
