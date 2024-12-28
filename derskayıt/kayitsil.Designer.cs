namespace derskayıt
{
    partial class kayitsil
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
            dataGridView1 = new DataGridView();
            kimlikno = new TextBox();
            ders = new ComboBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.Silver;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(675, 454);
            dataGridView1.TabIndex = 0;
            // 
            // kimlikno
            // 
            kimlikno.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            kimlikno.Location = new Point(778, 94);
            kimlikno.Margin = new Padding(3, 4, 3, 4);
            kimlikno.Name = "kimlikno";
            kimlikno.Size = new Size(147, 31);
            kimlikno.TabIndex = 1;
            // 
            // ders
            // 
            ders.Font = new Font("Segoe UI", 10.2F);
            ders.FormattingEnabled = true;
            ders.Location = new Point(778, 186);
            ders.Margin = new Padding(3, 4, 3, 4);
            ders.Name = "ders";
            ders.Size = new Size(147, 31);
            ders.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Location = new Point(741, 303);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(184, 77);
            button1.TabIndex = 3;
            button1.Text = "Sil";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(680, 97);
            label1.Name = "label1";
            label1.Size = new Size(92, 23);
            label1.TabIndex = 4;
            label1.Text = "Kimlik No :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(719, 189);
            label2.Name = "label2";
            label2.Size = new Size(53, 23);
            label2.TabIndex = 6;
            label2.Text = "Ders :";
            // 
            // kayitsil
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(958, 454);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(ders);
            Controls.Add(kimlikno);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "kayitsil";
            Text = "kayitsil";
            Load += kayitsil_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox kimlikno;
        private ComboBox ders;
        private Button button1;
        private Label label1;
        private Label label2;
    }
}