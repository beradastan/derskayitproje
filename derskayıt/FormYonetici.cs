﻿using System;
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
    public partial class FormYonetici : Form
    {
        public FormYonetici()
        {
            InitializeComponent();
        }
        //Ogrenci işlemleri formuna yönlendiren buton
        private void button11_Click(object sender, EventArgs e)
        {
            Ogrenciİslemleri fr = new Ogrenciİslemleri();
            fr.Show();
        }
        //gorevli işlemleri formuna yönlendiren buton
        private void button12_Click(object sender, EventArgs e)
        {
            Gorevliİslemleri fr = new Gorevliİslemleri();
            fr.Show();
        }
        //ders işlemleri formuna yönlendiren buton
        private void button13_Click(object sender, EventArgs e)
        {
            Dersİslemleri fr = new Dersİslemleri();
            fr.Show();
        }
    }
}
