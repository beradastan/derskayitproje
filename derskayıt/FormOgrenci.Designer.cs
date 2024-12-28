namespace derskayıt
{
    partial class FormOgrenci
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
            txtSifre = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            button4 = new Button();
            txtTelefon = new MaskedTextBox();
            txtdtarih = new MaskedTextBox();
            txtAdres = new TextBox();
            txtSoyad = new TextBox();
            txtAd = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(204, 454);
            txtSifre.Margin = new Padding(3, 4, 3, 4);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(180, 27);
            txtSifre.TabIndex = 50;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(111, 454);
            label3.Name = "label3";
            label3.Size = new Size(60, 28);
            label3.TabIndex = 49;
            label3.Text = "Şifre :";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(204, 349);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(180, 27);
            txtEmail.TabIndex = 48;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(115, 348);
            label7.Name = "label7";
            label7.Size = new Size(73, 28);
            label7.TabIndex = 47;
            label7.Text = "Email : ";
            // 
            // button4
            // 
            button4.BackColor = Color.Silver;
            button4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button4.ForeColor = SystemColors.ControlText;
            button4.Location = new Point(678, 417);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(223, 77);
            button4.TabIndex = 46;
            button4.Text = "Güncelle";
            button4.UseCompatibleTextRendering = true;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(721, 348);
            txtTelefon.Margin = new Padding(3, 4, 3, 4);
            txtTelefon.Mask = "(999) 000-0000";
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(180, 27);
            txtTelefon.TabIndex = 45;
            // 
            // txtdtarih
            // 
            txtdtarih.Location = new Point(721, 236);
            txtdtarih.Margin = new Padding(3, 4, 3, 4);
            txtdtarih.Mask = "00/00/0000";
            txtdtarih.Name = "txtdtarih";
            txtdtarih.Size = new Size(180, 27);
            txtdtarih.TabIndex = 41;
            txtdtarih.ValidatingType = typeof(DateTime);
            // 
            // txtAdres
            // 
            txtAdres.Location = new Point(204, 236);
            txtAdres.Margin = new Padding(3, 4, 3, 4);
            txtAdres.Name = "txtAdres";
            txtAdres.Size = new Size(180, 27);
            txtAdres.TabIndex = 43;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(721, 124);
            txtSoyad.Margin = new Padding(3, 4, 3, 4);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(180, 27);
            txtSoyad.TabIndex = 39;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(204, 125);
            txtAd.Margin = new Padding(3, 4, 3, 4);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(180, 27);
            txtAd.TabIndex = 37;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(622, 348);
            label6.Name = "label6";
            label6.Size = new Size(83, 28);
            label6.TabIndex = 44;
            label6.Text = "Telefon :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(115, 236);
            label5.Name = "label5";
            label5.Size = new Size(71, 28);
            label5.TabIndex = 42;
            label5.Text = "Adres :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(567, 236);
            label4.Name = "label4";
            label4.Size = new Size(138, 28);
            label4.TabIndex = 40;
            label4.Text = "Doğum Tarihi :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(629, 124);
            label2.Name = "label2";
            label2.Size = new Size(76, 28);
            label2.TabIndex = 38;
            label2.Text = "Soyad :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(138, 124);
            label1.Name = "label1";
            label1.Size = new Size(46, 28);
            label1.TabIndex = 36;
            label1.Text = "Ad :";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.Silver;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 93);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(958, 445);
            dataGridView1.TabIndex = 35;
            dataGridView1.Visible = false;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderColor = Color.White;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button3.ForeColor = Color.White;
            button3.Location = new Point(665, 15);
            button3.Name = "button3";
            button3.Size = new Size(305, 59);
            button3.TabIndex = 34;
            button3.Text = "Bilgilerimi Güncelle";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button2.ForeColor = Color.White;
            button2.Location = new Point(339, 15);
            button2.Name = "button2";
            button2.Size = new Size(304, 59);
            button2.TabIndex = 33;
            button2.Text = "Öğretmen Bilgilerini Listele";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 15);
            button1.Name = "button1";
            button1.Size = new Size(305, 59);
            button1.TabIndex = 32;
            button1.Text = "Aldığım Dersleri Listele";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormOgrenci
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(982, 553);
            Controls.Add(txtSifre);
            Controls.Add(label3);
            Controls.Add(txtEmail);
            Controls.Add(label7);
            Controls.Add(button4);
            Controls.Add(txtTelefon);
            Controls.Add(txtdtarih);
            Controls.Add(txtAdres);
            Controls.Add(txtSoyad);
            Controls.Add(txtAd);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FormOgrenci";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Öğrenci Menü";
            Load += FormOgrenci_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSifre;
        private Label label3;
        private TextBox txtEmail;
        private Label label7;
        private Button button4;
        private MaskedTextBox txtTelefon;
        private MaskedTextBox txtdtarih;
        private TextBox txtAdres;
        private TextBox txtSoyad;
        private TextBox txtAd;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}