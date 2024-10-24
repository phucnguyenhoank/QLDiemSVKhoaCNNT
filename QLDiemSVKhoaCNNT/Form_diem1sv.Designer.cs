namespace QLDiemSVKhoaCNNT
{
    partial class Form_diem1sv
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
            textBox1 = new TextBox();
            labelmssv = new Label();
            button1 = new Button();
            label1 = new Label();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(139, 53);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(135, 27);
            textBox1.TabIndex = 0;
            // 
            // labelmssv
            // 
            labelmssv.AutoSize = true;
            labelmssv.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelmssv.ForeColor = SystemColors.ControlLightLight;
            labelmssv.Location = new Point(35, 49);
            labelmssv.Name = "labelmssv";
            labelmssv.Size = new Size(77, 28);
            labelmssv.TabIndex = 1;
            labelmssv.Text = "MSSV: ";
            // 
            // button1
            // 
            button1.Location = new Point(294, 51);
            button1.Name = "button1";
            button1.Size = new Size(81, 28);
            button1.TabIndex = 2;
            button1.Text = "Show";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(34, 108);
            label1.Name = "label1";
            label1.Size = new Size(78, 28);
            label1.TabIndex = 3;
            label1.Text = "Họ Tên";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(139, 112);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(135, 27);
            textBox2.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(392, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(396, 388);
            dataGridView1.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Location = new Point(28, 176);
            panel1.Name = "panel1";
            panel1.Size = new Size(305, 234);
            panel1.TabIndex = 7;
            // 
            // Form_diem1sv
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(labelmssv);
            Controls.Add(textBox1);
            Name = "Form_diem1sv";
            Text = "Form_diem1sv";
            Load += Form_diem1sv_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label labelmssv;
        private Button button1;
        private Label label1;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private Panel panel1;
    }
}