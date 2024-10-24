namespace QLDiemSVKhoaCNNT
{
    partial class DKSinhVien
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
            button5 = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button1 = new Button();
            comboBox1 = new ComboBox();
            dataGridView2 = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // button5
            // 
            button5.Location = new Point(180, 347);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 69;
            button5.Text = "Tai lai";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(472, 31);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 64;
            label1.Text = "Dang Ky ";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(34, 420);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(916, 183);
            dataGridView1.TabIndex = 63;
            // 
            // button2
            // 
            button2.Location = new Point(34, 347);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 55;
            button2.Text = "Them";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(565, 71);
            button1.Name = "button1";
            button1.Size = new Size(189, 29);
            button1.TabIndex = 54;
            button1.Text = "Hien danh sach sinh vien";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(266, 72);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(274, 28);
            comboBox1.TabIndex = 70;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(34, 146);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(916, 182);
            dataGridView2.TabIndex = 72;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(58, 115);
            label2.Name = "label2";
            label2.Size = new Size(91, 28);
            label2.TabIndex = 73;
            label2.Text = "Sinh vien";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(58, 389);
            label3.Name = "label3";
            label3.Size = new Size(166, 28);
            label3.TabIndex = 74;
            label3.Text = "Sinh vien dang ky";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(657, 389);
            label4.Name = "label4";
            label4.Size = new Size(123, 28);
            label4.TabIndex = 75;
            label4.Text = "So luong SV:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(156, 75);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 76;
            label5.Text = "Ma lop hoc";
            // 
            // DKSinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 638);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView2);
            Controls.Add(comboBox1);
            Controls.Add(button5);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "DKSinhVien";
            Text = "DKSinhVien";
            Load += DKSinhVien_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button5;
        private Label label1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button1;
        private ComboBox comboBox1;
        private DataGridView dataGridView2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}