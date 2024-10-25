namespace QLDiemSVKhoaCNNT
{
    partial class FrmDangKySinhVien
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
            dgvSinhVienDangKy = new DataGridView();
            btnThem = new Button();
            cbxLopHoc = new ComboBox();
            dgvSinhVien = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            lblSoLuongSinhVien = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVienDangKy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // dgvSinhVienDangKy
            // 
            dgvSinhVienDangKy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVienDangKy.Location = new Point(37, 375);
            dgvSinhVienDangKy.Name = "dgvSinhVienDangKy";
            dgvSinhVienDangKy.ReadOnly = true;
            dgvSinhVienDangKy.RowHeadersWidth = 51;
            dgvSinhVienDangKy.Size = new Size(916, 183);
            dgvSinhVienDangKy.TabIndex = 63;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(37, 297);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 55;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // cbxLopHoc
            // 
            cbxLopHoc.FormattingEnabled = true;
            cbxLopHoc.Location = new Point(381, 294);
            cbxLopHoc.Name = "cbxLopHoc";
            cbxLopHoc.Size = new Size(274, 28);
            cbxLopHoc.TabIndex = 70;
            cbxLopHoc.SelectedIndexChanged += cbxMaLopHoc_SelectedIndexChanged;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(37, 46);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.Size = new Size(916, 182);
            dgvSinhVien.TabIndex = 72;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(45, 15);
            label2.Name = "label2";
            label2.Size = new Size(182, 28);
            label2.TabIndex = 73;
            label2.Text = "Danh sách sinh viên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(37, 344);
            label3.Name = "label3";
            label3.Size = new Size(257, 28);
            label3.TabIndex = 74;
            label3.Text = "Danh sách sinh viên đăng ký";
            // 
            // lblSoLuongSinhVien
            // 
            lblSoLuongSinhVien.AutoSize = true;
            lblSoLuongSinhVien.Font = new Font("Segoe UI", 12F);
            lblSoLuongSinhVien.Location = new Point(680, 561);
            lblSoLuongSinhVien.Name = "lblSoLuongSinhVien";
            lblSoLuongSinhVien.Size = new Size(177, 28);
            lblSoLuongSinhVien.TabIndex = 75;
            lblSoLuongSinhVien.Text = "Số lượng sinh viên:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(271, 297);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 76;
            label5.Text = "Mã lớp học:";
            // 
            // FrmDangKySinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 614);
            Controls.Add(label5);
            Controls.Add(lblSoLuongSinhVien);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgvSinhVien);
            Controls.Add(cbxLopHoc);
            Controls.Add(dgvSinhVienDangKy);
            Controls.Add(btnThem);
            Name = "FrmDangKySinhVien";
            Text = "Đăng ký sinh viên vào lớp";
            ((System.ComponentModel.ISupportInitialize)dgvSinhVienDangKy).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvSinhVienDangKy;
        private Button btnThem;
        private ComboBox cbxLopHoc;
        private DataGridView dgvSinhVien;
        private Label label2;
        private Label label3;
        private Label lblSoLuongSinhVien;
        private Label label5;
    }
}