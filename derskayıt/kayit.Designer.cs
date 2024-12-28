namespace derskayıt
{
    partial class kayit
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
            txtkimlikno = new TextBox();
            dersadi = new ComboBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(680, 97);
            label1.Name = "label1";
            label1.Size = new Size(92, 23);
            label1.TabIndex = 0;
            label1.Text = "Kimlik No :";
            label1.Click += label1_Click;
            // 
            // txtkimlikno
            // 
            txtkimlikno.Font = new Font("Segoe UI", 10.2F);
            txtkimlikno.Location = new Point(778, 94);
            txtkimlikno.Margin = new Padding(3, 4, 3, 4);
            txtkimlikno.Name = "txtkimlikno";
            txtkimlikno.Size = new Size(147, 30);
            txtkimlikno.TabIndex = 1;
            // 
            // dersadi
            // 
            dersadi.Font = new Font("Segoe UI", 10.2F);
            dersadi.FormattingEnabled = true;
            dersadi.Location = new Point(778, 186);
            dersadi.Margin = new Padding(3, 4, 3, 4);
            dersadi.Name = "dersadi";
            dersadi.Size = new Size(147, 31);
            dersadi.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Location = new Point(741, 303);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(184, 77);
            button1.TabIndex = 3;
            button1.Text = "Kayıt Yap";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.Silver;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(675, 454);
            dataGridView1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(719, 189);
            label2.Name = "label2";
            label2.Size = new Size(53, 23);
            label2.TabIndex = 5;
            label2.Text = "Ders :";
            // 
            // kayit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(958, 454);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(dersadi);
            Controls.Add(txtkimlikno);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "kayit";
            Text = "kayit";
            Load += kayit_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtkimlikno;
        private ComboBox dersadi;
        private Button button1;
        private DataGridView dataGridView1;
        private Label label2;

        private void label1_Click(object sender, EventArgs e)
        {
            // Olay gerçekleştiğinde ne yapılacağını buraya yazabilirsiniz
            MessageBox.Show("Label tıklandı!");
        }
    }
}