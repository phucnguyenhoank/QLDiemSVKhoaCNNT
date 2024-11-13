namespace QLDiemSVKhoaCNNT
{
    partial class FrmChuyenLop
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
            lblMaLopHT = new Label();
            label3 = new Label();
            cbxMaSV = new ComboBox();
            cbxMaLopMoi = new ComboBox();
            btnChuyenLop = new Button();
            cbxMaLopCu = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 41);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã sinh viên:";
            // 
            // lblMaLopHT
            // 
            lblMaLopHT.AutoSize = true;
            lblMaLopHT.Location = new Point(245, 41);
            lblMaLopHT.Name = "lblMaLopHT";
            lblMaLopHT.Size = new Size(164, 20);
            lblMaLopHT.TabIndex = 1;
            lblMaLopHT.Text = "Mã lớp học đã đăng ký:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(507, 41);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 2;
            label3.Text = "Mã lớp học mới:";
            // 
            // cbxMaSV
            // 
            cbxMaSV.FormattingEnabled = true;
            cbxMaSV.Location = new Point(12, 76);
            cbxMaSV.Name = "cbxMaSV";
            cbxMaSV.Size = new Size(151, 28);
            cbxMaSV.TabIndex = 3;
            cbxMaSV.SelectedIndexChanged += cbxMaSV_SelectedIndexChanged;
            // 
            // cbxMaLopMoi
            // 
            cbxMaLopMoi.FormattingEnabled = true;
            cbxMaLopMoi.Location = new Point(494, 76);
            cbxMaLopMoi.Name = "cbxMaLopMoi";
            cbxMaLopMoi.Size = new Size(151, 28);
            cbxMaLopMoi.TabIndex = 4;
            // 
            // btnChuyenLop
            // 
            btnChuyenLop.Location = new Point(247, 135);
            btnChuyenLop.Name = "btnChuyenLop";
            btnChuyenLop.Size = new Size(138, 41);
            btnChuyenLop.TabIndex = 5;
            btnChuyenLop.Text = "Chuyển lớp";
            btnChuyenLop.UseVisualStyleBackColor = true;
            btnChuyenLop.Click += btnChuyenLop_Click;
            // 
            // cbxMaLopCu
            // 
            cbxMaLopCu.FormattingEnabled = true;
            cbxMaLopCu.Location = new Point(245, 76);
            cbxMaLopCu.Name = "cbxMaLopCu";
            cbxMaLopCu.Size = new Size(151, 28);
            cbxMaLopCu.TabIndex = 6;
            // 
            // FrmChuyenLop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 224);
            Controls.Add(cbxMaLopCu);
            Controls.Add(btnChuyenLop);
            Controls.Add(cbxMaLopMoi);
            Controls.Add(cbxMaSV);
            Controls.Add(label3);
            Controls.Add(lblMaLopHT);
            Controls.Add(label1);
            Name = "FrmChuyenLop";
            Text = "FrmChuyenLop";
            Load += FrmChuyenLop_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblMaLopHT;
        private Label label3;
        private ComboBox cbxMaSV;
        private ComboBox cbxMaLopMoi;
        private Button btnChuyenLop;
        private ComboBox cbxMaLopCu;
    }
}