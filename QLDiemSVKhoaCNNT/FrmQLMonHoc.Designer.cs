namespace QLDiemSVKhoaCNNT
{
    partial class FrmQLMonHoc
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
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button5
            // 
            button5.Location = new Point(1087, 542);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 69;
            button5.Text = "Tai lai";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(110, 322);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 67;
            label5.Text = "So tin chi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(110, 236);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 66;
            label4.Text = "Ten mon hoc";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(110, 156);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 65;
            label3.Text = "Ma mon hoc";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(595, 51);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 64;
            label1.Text = "Quan Ly Mon Hoc";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(505, 196);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(698, 272);
            dataGridView1.TabIndex = 63;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(212, 304);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 61;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(212, 229);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 60;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(203, 149);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 59;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(551, 103);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(489, 27);
            textBox1.TabIndex = 58;
            // 
            // button4
            // 
            button4.Location = new Point(766, 542);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 57;
            button4.Text = "Sua";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(460, 542);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 56;
            button3.Text = "Xoa";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(212, 542);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 55;
            button2.Text = "Them";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1121, 101);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 54;
            button1.Text = "Tim kiem";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(426, 105);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 70;
            label2.Text = "Ma Mon Hoc";
            // 
            // FrmQLMonHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1325, 623);
            Controls.Add(label2);
            Controls.Add(button5);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FrmQLMonHoc";
            Text = "FrmQLMonHoc";
            Load += FrmQLMonHoc_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button5;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private DataGridView dataGridView1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label2;
    }
}