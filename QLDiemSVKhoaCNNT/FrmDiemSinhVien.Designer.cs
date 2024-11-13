namespace QLDiemSVKhoaCNNT
{
    partial class FrmDiemSinhVien
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
            textBoxmssv = new TextBox();
            labelmssv = new Label();
            buttonshow = new Button();
            label1 = new Label();
            dgvdanhsachdiemsv = new DataGridView();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvdanhsachdiemsv).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxmssv
            // 
            textBoxmssv.Location = new Point(95, 53);
            textBoxmssv.Name = "textBoxmssv";
            textBoxmssv.Size = new Size(135, 27);
            textBoxmssv.TabIndex = 0;
            // 
            // labelmssv
            // 
            labelmssv.AutoSize = true;
            labelmssv.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelmssv.ForeColor = SystemColors.ControlLightLight;
            labelmssv.Location = new Point(12, 52);
            labelmssv.Name = "labelmssv";
            labelmssv.Size = new Size(77, 28);
            labelmssv.TabIndex = 1;
            labelmssv.Text = "MSSV: ";
            // 
            // buttonshow
            // 
            buttonshow.Location = new Point(252, 52);
            buttonshow.Name = "buttonshow";
            buttonshow.Size = new Size(81, 28);
            buttonshow.TabIndex = 2;
            buttonshow.Text = "Show";
            buttonshow.UseVisualStyleBackColor = true;
            buttonshow.Click += buttonshow_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(21, 27);
            label1.Name = "label1";
            label1.Size = new Size(151, 23);
            label1.TabIndex = 3;
            label1.Text = "Điểm Trung Bình:";
            // 
            // dgvdanhsachdiemsv
            // 
            dgvdanhsachdiemsv.AllowUserToAddRows = false;
            dgvdanhsachdiemsv.AllowUserToDeleteRows = false;
            dgvdanhsachdiemsv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdanhsachdiemsv.Location = new Point(339, 12);
            dgvdanhsachdiemsv.Name = "dgvdanhsachdiemsv";
            dgvdanhsachdiemsv.ReadOnly = true;
            dgvdanhsachdiemsv.RowHeadersWidth = 51;
            dgvdanhsachdiemsv.Size = new Size(814, 388);
            dgvdanhsachdiemsv.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(28, 98);
            panel1.Name = "panel1";
            panel1.Size = new Size(305, 234);
            panel1.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 127);
            label3.Name = "label3";
            label3.Size = new Size(202, 23);
            label3.TabIndex = 1;
            label3.Text = "Số Tín Chỉ Hoàn Thành: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 82);
            label2.Name = "label2";
            label2.Size = new Size(227, 23);
            label2.TabIndex = 0;
            label2.Text = "Điểm Trung Bình Tích Lũy: ";
            // 
            // FrmDiemSinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1183, 450);
            Controls.Add(panel1);
            Controls.Add(dgvdanhsachdiemsv);
            Controls.Add(buttonshow);
            Controls.Add(labelmssv);
            Controls.Add(textBoxmssv);
            Name = "FrmDiemSinhVien";
            Text = "Form_diem1sv";
            Load += Form_diem1sv_Load;
            ((System.ComponentModel.ISupportInitialize)dgvdanhsachdiemsv).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxmssv;
        private Label labelmssv;
        private Button buttonshow;
        private Label label1;
        private DataGridView dgvdanhsachdiemsv;
        private Panel panel1;
        private Label label3;
        private Label label2;
    }
}