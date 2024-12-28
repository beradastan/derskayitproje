namespace derskayıt
{
    partial class Gorevliekle
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
            txtEmail = new TextBox();
            label7 = new Label();
            button1 = new Button();
            txtTelefon = new MaskedTextBox();
            txtdtarih = new MaskedTextBox();
            txtAdres = new TextBox();
            txtKimlikNo = new TextBox();
            txtSoyad = new TextBox();
            txtAd = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(164, 382);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(187, 27);
            txtEmail.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(73, 381);
            label7.Name = "label7";
            label7.Size = new Size(73, 28);
            label7.TabIndex = 30;
            label7.Text = "Email : ";
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(638, 344);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(223, 77);
            button1.TabIndex = 29;
            button1.Text = "Kaydet";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(681, 263);
            txtTelefon.Margin = new Padding(3, 4, 3, 4);
            txtTelefon.Mask = "(999) 000-0000";
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(172, 27);
            txtTelefon.TabIndex = 28;
            // 
            // txtdtarih
            // 
            txtdtarih.Location = new Point(681, 151);
            txtdtarih.Margin = new Padding(3, 4, 3, 4);
            txtdtarih.Mask = "00/00/0000";
            txtdtarih.Name = "txtdtarih";
            txtdtarih.Size = new Size(172, 27);
            txtdtarih.TabIndex = 24;
            txtdtarih.ValidatingType = typeof(DateTime);
            // 
            // txtAdres
            // 
            txtAdres.Location = new Point(164, 268);
            txtAdres.Margin = new Padding(3, 4, 3, 4);
            txtAdres.Name = "txtAdres";
            txtAdres.Size = new Size(187, 27);
            txtAdres.TabIndex = 26;
            // 
            // txtKimlikNo
            // 
            txtKimlikNo.Location = new Point(164, 154);
            txtKimlikNo.Margin = new Padding(3, 4, 3, 4);
            txtKimlikNo.Name = "txtKimlikNo";
            txtKimlikNo.Size = new Size(187, 27);
            txtKimlikNo.TabIndex = 22;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(681, 39);
            txtSoyad.Margin = new Padding(3, 4, 3, 4);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(172, 27);
            txtSoyad.TabIndex = 20;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(164, 40);
            txtAd.Margin = new Padding(3, 4, 3, 4);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(187, 27);
            txtAd.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(582, 263);
            label6.Name = "label6";
            label6.Size = new Size(83, 28);
            label6.TabIndex = 27;
            label6.Text = "Telefon :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(75, 267);
            label5.Name = "label5";
            label5.Size = new Size(71, 28);
            label5.TabIndex = 25;
            label5.Text = "Adres :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(532, 151);
            label4.Name = "label4";
            label4.Size = new Size(133, 28);
            label4.TabIndex = 23;
            label4.Text = "Doğum Tarihi:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(39, 153);
            label3.Name = "label3";
            label3.Size = new Size(107, 28);
            label3.TabIndex = 21;
            label3.Text = "Kimlik No :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(589, 39);
            label2.Name = "label2";
            label2.Size = new Size(76, 28);
            label2.TabIndex = 19;
            label2.Text = "Soyad :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(100, 39);
            label1.Name = "label1";
            label1.Size = new Size(46, 28);
            label1.TabIndex = 17;
            label1.Text = "Ad :";
            // 
            // Gorevliekle
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
            Name = "Gorevliekle";
            Text = "Gorevliekle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private Label label7;
        private Button button1;
        private MaskedTextBox txtTelefon;
        private MaskedTextBox txtdtarih;
        private TextBox txtAdres;
        private TextBox txtKimlikNo;
        private TextBox txtSoyad;
        private TextBox txtAd;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}