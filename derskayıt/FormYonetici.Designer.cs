namespace derskayıt
{
    partial class FormYonetici
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
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button11
            // 
            button11.BackgroundImage = Properties.Resources.ogrenci;
            button11.BackgroundImageLayout = ImageLayout.Zoom;
            button11.FlatAppearance.BorderColor = Color.White;
            button11.FlatAppearance.BorderSize = 7;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button11.ForeColor = Color.White;
            button11.ImageAlign = ContentAlignment.TopCenter;
            button11.Location = new Point(22, 87);
            button11.Name = "button11";
            button11.Size = new Size(300, 441);
            button11.TabIndex = 10;
            button11.Text = "Öğrenci İşlemleri";
            button11.TextAlign = ContentAlignment.TopCenter;
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.BackgroundImage = Properties.Resources.gorevli;
            button12.BackgroundImageLayout = ImageLayout.Zoom;
            button12.FlatAppearance.BorderColor = Color.White;
            button12.FlatAppearance.BorderSize = 7;
            button12.FlatStyle = FlatStyle.Flat;
            button12.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button12.ForeColor = Color.White;
            button12.ImageAlign = ContentAlignment.TopCenter;
            button12.Location = new Point(347, 87);
            button12.Name = "button12";
            button12.Size = new Size(300, 441);
            button12.TabIndex = 11;
            button12.Text = "Görevli İşlemleri";
            button12.TextAlign = ContentAlignment.TopCenter;
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.BackgroundImage = Properties.Resources.ders;
            button13.BackgroundImageLayout = ImageLayout.Zoom;
            button13.FlatAppearance.BorderColor = Color.White;
            button13.FlatAppearance.BorderSize = 7;
            button13.FlatStyle = FlatStyle.Flat;
            button13.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button13.ForeColor = Color.White;
            button13.Location = new Point(670, 87);
            button13.Name = "button13";
            button13.Size = new Size(300, 441);
            button13.TabIndex = 12;
            button13.Text = "Ders İşlemleri";
            button13.TextAlign = ContentAlignment.TopCenter;
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(204, 9);
            label1.Name = "label1";
            label1.Size = new Size(608, 62);
            label1.TabIndex = 13;
            label1.Text = "Yönetici Ders Kayıt İşlemleri ";
            // 
            // FormYonetici
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(982, 553);
            Controls.Add(label1);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(button11);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormYonetici";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yönetici İşlemleri";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button11;
        private Button button12;
        private Button button13;
        private Label label1;
    }
}