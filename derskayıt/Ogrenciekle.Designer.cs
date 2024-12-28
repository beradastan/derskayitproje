namespace derskayıt
{
    partial class Ogrenciekle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            txtKimlikNo = new TextBox();
            txtAdres = new TextBox();
            txtdtarih = new MaskedTextBox();
            txtTelefon = new MaskedTextBox();
            button1 = new Button();
            label7 = new Label();
            txtEmail = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(98, 39);
            label1.Name = "label1";
            label1.Size = new Size(46, 28);
            label1.TabIndex = 0;
            label1.Text = "Ad :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(589, 39);
            label2.Name = "label2";
            label2.Size = new Size(76, 28);
            label2.TabIndex = 1;
            label2.Text = "Soyad :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(37, 153);
            label3.Name = "label3";
            label3.Size = new Size(107, 28);
            label3.TabIndex = 2;
            label3.Text = "Kimlik No :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(527, 151);
            label4.Name = "label4";
            label4.Size = new Size(138, 28);
            label4.TabIndex = 3;
            label4.Text = "Doğum Tarihi :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(73, 267);
            label5.Name = "label5";
            label5.Size = new Size(71, 28);
            label5.TabIndex = 4;
            label5.Text = "Adres :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(582, 263);
            label6.Name = "label6";
            label6.Size = new Size(83, 28);
            label6.TabIndex = 5;
            label6.Text = "Telefon :";
            // 
            // txtAd
            // 
            txtAd.Location = new Point(164, 40);
            txtAd.Margin = new Padding(3, 4, 3, 4);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(180, 27);
            txtAd.TabIndex = 1;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(681, 39);
            txtSoyad.Margin = new Padding(3, 4, 3, 4);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(180, 27);
            txtSoyad.TabIndex = 2;
            // 
            // txtKimlikNo
            // 
            txtKimlikNo.Location = new Point(164, 154);
            txtKimlikNo.Margin = new Padding(3, 4, 3, 4);
            txtKimlikNo.Name = "txtKimlikNo";
            txtKimlikNo.Size = new Size(180, 27);
            txtKimlikNo.TabIndex = 3;
            // 
            // txtAdres
            // 
            txtAdres.Location = new Point(164, 268);
            txtAdres.Margin = new Padding(3, 4, 3, 4);
            txtAdres.Name = "txtAdres";
            txtAdres.Size = new Size(180, 27);
            txtAdres.TabIndex = 5;
            // 
            // txtdtarih
            // 
            txtdtarih.Location = new Point(681, 151);
            txtdtarih.Margin = new Padding(3, 4, 3, 4);
            txtdtarih.Mask = "00/00/0000";
            txtdtarih.Name = "txtdtarih";
            txtdtarih.Size = new Size(180, 27);
            txtdtarih.TabIndex = 4;
            txtdtarih.ValidatingType = typeof(DateTime);
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(681, 263);
            txtTelefon.Margin = new Padding(3, 4, 3, 4);
            txtTelefon.Mask = "(999) 000-0000";
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(180, 27);
            txtTelefon.TabIndex = 6;
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Location = new Point(638, 344);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(223, 77);
            button1.TabIndex = 14;
            button1.Text = "Ekle";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(73, 381);
            label7.Name = "label7";
            label7.Size = new Size(73, 28);
            label7.TabIndex = 15;
            label7.Text = "Email : ";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(164, 382);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(180, 27);
            txtEmail.TabIndex = 16;
            // 
            // Ogrenciekle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(958, 454);
            Controls.Add(txtEmail);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(txtTelefon);
            Controls.Add(txtdtarih);
            Controls.Add(txtAdres);
            Controls.Add(txtKimlikNo);
            Controls.Add(txtSoyad);
            Controls.Add(txtAd);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Ogrenciekle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "kayityap";
            Load += kayityap_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtAd;
        private TextBox txtSoyad;
        private TextBox txtKimlikNo;
        private TextBox txtAdres;
        private MaskedTextBox txtdtarih;
        private MaskedTextBox txtTelefon;
        private Button button1;
        private Label label7;
        private TextBox txtEmail;
    }
}