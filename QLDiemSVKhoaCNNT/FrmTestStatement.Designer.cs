namespace QLDiemSVKhoaCNNT
{
    partial class frmTest
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvReadData = new DataGridView();
            btnGet = new Button();
            btnTestConnection = new Button();
            btnThemGV = new Button();
            btnXoaSinhVien = new Button();
            btnDKSinhVienVaoLop = new Button();
            lblScalarReturnedValue = new Label();
            button1 = new Button();
            btnSuaGiangVien = new Button();
            btnGiangVienToLop = new Button();
            btnThemMonHoc = new Button();
            btnSuaSinhVien = new Button();
            btnCapNhatDiem = new Button();
            btnSoTCHoanThanh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReadData).BeginInit();
            SuspendLayout();
            // 
            // dgvReadData
            // 
            dgvReadData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReadData.Location = new Point(306, 43);
            dgvReadData.Name = "dgvReadData";
            dgvReadData.RowHeadersWidth = 51;
            dgvReadData.Size = new Size(671, 319);
            dgvReadData.TabIndex = 0;
            // 
            // btnGet
            // 
            btnGet.Location = new Point(197, 43);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(94, 29);
            btnGet.TabIndex = 1;
            btnGet.Text = "get";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // btnTestConnection
            // 
            btnTestConnection.Location = new Point(12, 26);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(145, 29);
            btnTestConnection.TabIndex = 2;
            btnTestConnection.Text = "Test Connection";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // btnThemGV
            // 
            btnThemGV.Location = new Point(36, 191);
            btnThemGV.Name = "btnThemGV";
            btnThemGV.Size = new Size(170, 29);
            btnThemGV.TabIndex = 3;
            btnThemGV.Text = "Thêm giảng viên";
            btnThemGV.UseVisualStyleBackColor = true;
            btnThemGV.Click += btnThemGV_Click;
            // 
            // btnXoaSinhVien
            // 
            btnXoaSinhVien.Location = new Point(21, 353);
            btnXoaSinhVien.Name = "btnXoaSinhVien";
            btnXoaSinhVien.Size = new Size(158, 29);
            btnXoaSinhVien.TabIndex = 4;
            btnXoaSinhVien.Text = "Xóa sinh viên";
            btnXoaSinhVien.UseVisualStyleBackColor = true;
            btnXoaSinhVien.Click += btnXoaSinhVien_Click;
            // 
            // btnDKSinhVienVaoLop
            // 
            btnDKSinhVienVaoLop.Location = new Point(36, 401);
            btnDKSinhVienVaoLop.Name = "btnDKSinhVienVaoLop";
            btnDKSinhVienVaoLop.Size = new Size(230, 29);
            btnDKSinhVienVaoLop.TabIndex = 5;
            btnDKSinhVienVaoLop.Text = "Đăng ký sinh viên vào lớp";
            btnDKSinhVienVaoLop.UseVisualStyleBackColor = true;
            btnDKSinhVienVaoLop.Click += btnDKSinhVienVaoLop_Click;
            // 
            // lblScalarReturnedValue
            // 
            lblScalarReturnedValue.AutoSize = true;
            lblScalarReturnedValue.Location = new Point(333, 374);
            lblScalarReturnedValue.Name = "lblScalarReturnedValue";
            lblScalarReturnedValue.Size = new Size(86, 20);
            lblScalarReturnedValue.TabIndex = 6;
            lblScalarReturnedValue.Text = "scalar value";
            // 
            // button1
            // 
            button1.Location = new Point(21, 295);
            button1.Name = "button1";
            button1.Size = new Size(158, 29);
            button1.TabIndex = 7;
            button1.Text = "Xóa môn học";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnSuaGiangVien
            // 
            btnSuaGiangVien.Location = new Point(36, 448);
            btnSuaGiangVien.Name = "btnSuaGiangVien";
            btnSuaGiangVien.Size = new Size(143, 29);
            btnSuaGiangVien.TabIndex = 8;
            btnSuaGiangVien.Text = "Sửa giảng viên";
            btnSuaGiangVien.UseVisualStyleBackColor = true;
            btnSuaGiangVien.Click += btnSuaGiangVien_Click;
            // 
            // btnGiangVienToLop
            // 
            btnGiangVienToLop.Location = new Point(296, 411);
            btnGiangVienToLop.Name = "btnGiangVienToLop";
            btnGiangVienToLop.Size = new Size(143, 29);
            btnGiangVienToLop.TabIndex = 9;
            btnGiangVienToLop.Text = "Cập nhật giảng viên vào lớp";
            btnGiangVienToLop.UseVisualStyleBackColor = true;
            btnGiangVienToLop.Click += btnGiangVienToLop_Click;
            // 
            // btnThemMonHoc
            // 
            btnThemMonHoc.Location = new Point(487, 411);
            btnThemMonHoc.Name = "btnThemMonHoc";
            btnThemMonHoc.Size = new Size(158, 29);
            btnThemMonHoc.TabIndex = 10;
            btnThemMonHoc.Text = "Thêm môn học";
            btnThemMonHoc.UseVisualStyleBackColor = true;
            btnThemMonHoc.Click += btnThemMonHoc_Click;
            // 
            // btnSuaSinhVien
            // 
            btnSuaSinhVien.Location = new Point(163, 488);
            btnSuaSinhVien.Name = "btnSuaSinhVien";
            btnSuaSinhVien.Size = new Size(167, 29);
            btnSuaSinhVien.TabIndex = 11;
            btnSuaSinhVien.Text = "Sửa sinh viên";
            btnSuaSinhVien.UseVisualStyleBackColor = true;
            btnSuaSinhVien.Click += btnSuaSinhVien_Click;
            // 
            // btnCapNhatDiem
            // 
            btnCapNhatDiem.Location = new Point(428, 488);
            btnCapNhatDiem.Name = "btnCapNhatDiem";
            btnCapNhatDiem.Size = new Size(205, 29);
            btnCapNhatDiem.TabIndex = 12;
            btnCapNhatDiem.Text = "Cập nhật điểm sinh viên";
            btnCapNhatDiem.UseVisualStyleBackColor = true;
            btnCapNhatDiem.Click += btnCapNhatDiem_Click;
            // 
            // btnSoTCHoanThanh
            // 
            btnSoTCHoanThanh.Location = new Point(755, 448);
            btnSoTCHoanThanh.Name = "btnSoTCHoanThanh";
            btnSoTCHoanThanh.Size = new Size(205, 29);
            btnSoTCHoanThanh.TabIndex = 13;
            btnSoTCHoanThanh.Text = "Số tín chỉ hoàn thành";
            btnSoTCHoanThanh.UseVisualStyleBackColor = true;
            btnSoTCHoanThanh.Click += btnSoTCHoanThanh_Click;
            // 
            // frmTest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 635);
            Controls.Add(btnSoTCHoanThanh);
            Controls.Add(btnCapNhatDiem);
            Controls.Add(btnSuaSinhVien);
            Controls.Add(btnThemMonHoc);
            Controls.Add(btnGiangVienToLop);
            Controls.Add(btnSuaGiangVien);
            Controls.Add(button1);
            Controls.Add(lblScalarReturnedValue);
            Controls.Add(btnDKSinhVienVaoLop);
            Controls.Add(btnXoaSinhVien);
            Controls.Add(btnThemGV);
            Controls.Add(btnTestConnection);
            Controls.Add(btnGet);
            Controls.Add(dgvReadData);
            Name = "frmTest";
            Text = "Test Statement";
            ((System.ComponentModel.ISupportInitialize)dgvReadData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvReadData;
        private Button btnGet;
        private Button btnTestConnection;
        private Button btnThemGV;
        private Button btnXoaSinhVien;
        private Button btnDKSinhVienVaoLop;
        private Label lblScalarReturnedValue;
        private Button button1;
        private Button btnSuaGiangVien;
        private Button btnGiangVienToLop;
        private Button btnThemMonHoc;
        private Button btnSuaSinhVien;
        private Button btnCapNhatDiem;
        private Button btnSoTCHoanThanh;
    }
}
