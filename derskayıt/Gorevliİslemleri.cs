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
    public partial class Gorevliİslemleri : Form
    {
        public Gorevliİslemleri()
        {
            InitializeComponent();
        }
        //panele gorevli ekleme formunu ekler
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Gorevliekle gorevliekle = new Gorevliekle();
            gorevliekle.TopLevel = false;
            gorevliekle.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(gorevliekle);
            gorevliekle.Show();
        }
        //panele gorevli silme formunu ekler
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Gorevlisil gorevlisil = new Gorevlisil();
            gorevlisil.TopLevel = false;
            gorevlisil.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(gorevlisil);
            gorevlisil.Show();
        }
        //panele gorevli listeleme formunu ekler
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Gorevlilistele gorevlilistele = new Gorevlilistele();
            gorevlilistele.TopLevel = false;
            gorevlilistele.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(gorevlilistele);
            gorevlilistele.Show();
        }
    }
}
