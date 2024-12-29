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
            txtEmail.Location = new Point(144, 286);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(164, 23);
            txtEmail.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(64, 286);
            label7.Name = "label7";
            label7.Size = new Size(59, 21);
            label7.TabIndex = 30;
            label7.Text = "Email : ";
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button1.Location = new Point(558, 258);
            button1.Name = "button1";
            button1.Size = new Size(195, 58);
            button1.TabIndex = 29;
            button1.Text = "Kaydet";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(596, 197);
            txtTelefon.Mask = "(999) 000-0000";
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(151, 23);
            txtTelefon.TabIndex = 28;
            // 
            // txtdtarih
            // 
            txtdtarih.Location = new Point(596, 113);
            txtdtarih.Mask = "00/00/0000";
            txtdtarih.Name = "txtdtarih";
            txtdtarih.Size = new Size(151, 23);
            txtdtarih.TabIndex = 24;
            txtdtarih.ValidatingType = typeof(DateTime);
            // 
            // txtAdres
            // 
            txtAdres.Location = new Point(144, 201);
            txtAdres.Name = "txtAdres";
            txtAdres.Size = new Size(164, 23);
            txtAdres.TabIndex = 26;
            // 
            // txtKimlikNo
            // 
            txtKimlikNo.Location = new Point(144, 116);
            txtKimlikNo.Name = "txtKimlikNo";
            txtKimlikNo.Size = new Size(164, 23);
            txtKimlikNo.TabIndex = 22;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(596, 29);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(151, 23);
            txtSoyad.TabIndex = 20;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(144, 30);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(164, 23);
            txtAd.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(509, 197);
            label6.Name = "label6";
            label6.Size = new Size(66, 21);
            label6.TabIndex = 27;
            label6.Text = "Telefon :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(66, 200);
            label5.Name = "label5";
            label5.Size = new Size(57, 21);
            label5.TabIndex = 25;
            label5.Text = "Adres :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(466, 113);
            label4.Name = "label4";
            label4.Size = new Size(106, 21);
            label4.TabIndex = 23;
            label4.Text = "Doğum Tarihi:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(34, 115);
            label3.Name = "label3";
            label3.Size = new Size(85, 21);
            label3.TabIndex = 21;
            label3.Text = "Kimlik No :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(515, 29);
            label2.Name = "label2";
            label2.Size = new Size(60, 21);
            label2.TabIndex = 19;
            label2.Text = "Soyad :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(88, 29);
            label1.Name = "label1";
            label1.Size = new Size(36, 21);
            label1.TabIndex = 17;
            label1.Text = "Ad :";
            // 
            // Gorevliekle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(838, 340);
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
            Margin = new Padding(3, 2, 3, 2);
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