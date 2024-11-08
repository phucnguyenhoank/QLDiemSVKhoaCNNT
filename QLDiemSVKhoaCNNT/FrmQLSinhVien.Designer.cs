namespace QLDiemSVKhoaCNNT
{
    partial class FrmQLSinhVien
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
            btnTaiLai = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            dgvSinhVien = new DataGridView();
            txtSoDienThoai = new TextBox();
            txtEmail = new TextBox();
            txtHoVaTen = new TextBox();
            txtMaSinhVien = new TextBox();
            txtMaSinhVienTimKiem = new TextBox();
            btnSuaSinhVien = new Button();
            btnXoaSinhVien = new Button();
            txtThemSinhVien = new Button();
            btnTimKiemSinhVien = new Button();
            label7 = new Label();
            txtQueQuan = new TextBox();
            label2 = new Label();
            btnXemXepHangDTB = new Button();
            btnTongKetDiemSinhVien = new Button();
            btnCapNhatDiem = new Button();
            btnXemTKB = new Button();
            txtSoLuongLop = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // btnTaiLai
            // 
            btnTaiLai.Location = new Point(870, 64);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(94, 29);
            btnTaiLai.TabIndex = 35;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 245);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 34;
            label6.Text = "Số điện thoại:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(71, 194);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 33;
            label5.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 149);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 32;
            label4.Text = "Họ và tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 103);
            label3.Name = "label3";
            label3.Size = new Size(94, 20);
            label3.TabIndex = 31;
            label3.Text = "Mã sinh viên:";
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(308, 100);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.Size = new Size(656, 392);
            dgvSinhVien.TabIndex = 28;
            dgvSinhVien.CellClick += dataGridView1_CellContentClick;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(146, 241);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(125, 27);
            txtSoDienThoai.TabIndex = 27;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(146, 194);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 26;
            // 
            // txtHoVaTen
            // 
            txtHoVaTen.Location = new Point(146, 147);
            txtHoVaTen.Name = "txtHoVaTen";
            txtHoVaTen.Size = new Size(125, 27);
            txtHoVaTen.TabIndex = 25;
            // 
            // txtMaSinhVien
            // 
            txtMaSinhVien.Location = new Point(146, 100);
            txtMaSinhVien.Name = "txtMaSinhVien";
            txtMaSinhVien.Size = new Size(125, 27);
            txtMaSinhVien.TabIndex = 24;
            // 
            // txtMaSinhVienTimKiem
            // 
            txtMaSinhVienTimKiem.Location = new Point(482, 66);
            txtMaSinhVienTimKiem.Name = "txtMaSinhVienTimKiem";
            txtMaSinhVienTimKiem.Size = new Size(125, 27);
            txtMaSinhVienTimKiem.TabIndex = 23;
            // 
            // btnSuaSinhVien
            // 
            btnSuaSinhVien.Location = new Point(1187, 97);
            btnSuaSinhVien.Name = "btnSuaSinhVien";
            btnSuaSinhVien.Size = new Size(94, 29);
            btnSuaSinhVien.TabIndex = 22;
            btnSuaSinhVien.Text = "Sửa";
            btnSuaSinhVien.UseVisualStyleBackColor = true;
            btnSuaSinhVien.Click += btnSuaSinhVien_Click;
            // 
            // btnXoaSinhVien
            // 
            btnXoaSinhVien.Location = new Point(1087, 97);
            btnXoaSinhVien.Name = "btnXoaSinhVien";
            btnXoaSinhVien.Size = new Size(94, 29);
            btnXoaSinhVien.TabIndex = 21;
            btnXoaSinhVien.Text = "Xóa";
            btnXoaSinhVien.UseVisualStyleBackColor = true;
            btnXoaSinhVien.Click += btnXoaSinhVien_Click;
            // 
            // txtThemSinhVien
            // 
            txtThemSinhVien.Location = new Point(987, 97);
            txtThemSinhVien.Name = "txtThemSinhVien";
            txtThemSinhVien.Size = new Size(94, 29);
            txtThemSinhVien.TabIndex = 20;
            txtThemSinhVien.Text = "Thêm";
            txtThemSinhVien.UseVisualStyleBackColor = true;
            txtThemSinhVien.Click += txtThemSinhVien_Click;
            // 
            // btnTimKiemSinhVien
            // 
            btnTimKiemSinhVien.Location = new Point(613, 65);
            btnTimKiemSinhVien.Name = "btnTimKiemSinhVien";
            btnTimKiemSinhVien.Size = new Size(94, 29);
            btnTimKiemSinhVien.TabIndex = 19;
            btnTimKiemSinhVien.Text = "Tìm kiếm";
            btnTimKiemSinhVien.UseVisualStyleBackColor = true;
            btnTimKiemSinhVien.Click += btnTimKiemSinhVien_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(44, 290);
            label7.Name = "label7";
            label7.Size = new Size(76, 20);
            label7.TabIndex = 36;
            label7.Text = "Quê quán:";
            // 
            // txtQueQuan
            // 
            txtQueQuan.Location = new Point(146, 288);
            txtQueQuan.Name = "txtQueQuan";
            txtQueQuan.Size = new Size(125, 27);
            txtQueQuan.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(382, 69);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 38;
            label2.Text = "Mã sinh viên:";
            // 
            // btnXemXepHangDTB
            // 
            btnXemXepHangDTB.Location = new Point(986, 132);
            btnXemXepHangDTB.Name = "btnXemXepHangDTB";
            btnXemXepHangDTB.Size = new Size(265, 29);
            btnXemXepHangDTB.TabIndex = 39;
            btnXemXepHangDTB.Text = "Xếp hạng điểm trung bình tích lũy";
            btnXemXepHangDTB.UseVisualStyleBackColor = true;
            btnXemXepHangDTB.Click += btnXemXepHangDTB_Click;
            // 
            // btnTongKetDiemSinhVien
            // 
            btnTongKetDiemSinhVien.Location = new Point(986, 202);
            btnTongKetDiemSinhVien.Name = "btnTongKetDiemSinhVien";
            btnTongKetDiemSinhVien.Size = new Size(221, 29);
            btnTongKetDiemSinhVien.TabIndex = 40;
            btnTongKetDiemSinhVien.Text = "Tổng kết điểm sinh viên";
            btnTongKetDiemSinhVien.UseVisualStyleBackColor = true;
            btnTongKetDiemSinhVien.Click += btnTongKetDiemSinhVien_Click;
            // 
            // btnCapNhatDiem
            // 
            btnCapNhatDiem.Location = new Point(987, 167);
            btnCapNhatDiem.Name = "btnCapNhatDiem";
            btnCapNhatDiem.Size = new Size(221, 29);
            btnCapNhatDiem.TabIndex = 41;
            btnCapNhatDiem.Text = "Cập nhật điểm sinh viên";
            btnCapNhatDiem.UseVisualStyleBackColor = true;
            btnCapNhatDiem.Click += btnCapNhatDiem_Click;
            // 
            // btnXemTKB
            // 
            btnXemTKB.Location = new Point(987, 245);
            btnXemTKB.Name = "btnXemTKB";
            btnXemTKB.Size = new Size(221, 29);
            btnXemTKB.TabIndex = 42;
            btnXemTKB.Text = "Xem thời khóa biểu";
            btnXemTKB.UseVisualStyleBackColor = true;
            btnXemTKB.Click += btnXemTKB_Click;
            // 
            // txtSoLuongLop
            // 
            txtSoLuongLop.AutoSize = true;
            txtSoLuongLop.Location = new Point(44, 371);
            txtSoLuongLop.Name = "txtSoLuongLop";
            txtSoLuongLop.Size = new Size(126, 20);
            txtSoLuongLop.TabIndex = 43;
            txtSoLuongLop.Text = "Đã đăng ký .... lớp";
            // 
            // FrmQLSinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1349, 617);
            Controls.Add(txtSoLuongLop);
            Controls.Add(btnXemTKB);
            Controls.Add(btnCapNhatDiem);
            Controls.Add(btnTongKetDiemSinhVien);
            Controls.Add(btnXemXepHangDTB);
            Controls.Add(label2);
            Controls.Add(txtQueQuan);
            Controls.Add(label7);
            Controls.Add(btnTaiLai);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dgvSinhVien);
            Controls.Add(txtSoDienThoai);
            Controls.Add(txtEmail);
            Controls.Add(txtHoVaTen);
            Controls.Add(txtMaSinhVien);
            Controls.Add(txtMaSinhVienTimKiem);
            Controls.Add(btnSuaSinhVien);
            Controls.Add(btnXoaSinhVien);
            Controls.Add(txtThemSinhVien);
            Controls.Add(btnTimKiemSinhVien);
            Name = "FrmQLSinhVien";
            Text = "Quản lý sinh viên";
            Load += FrmQLSinhVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTaiLai;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private DataGridView dgvSinhVien;
        private TextBox txtSoDienThoai;
        private TextBox txtEmail;
        private TextBox txtHoVaTen;
        private TextBox txtMaSinhVien;
        private TextBox txtMaSinhVienTimKiem;
        private Button btnSuaSinhVien;
        private Button btnXoaSinhVien;
        private Button txtThemSinhVien;
        private Button btnTimKiemSinhVien;
        private Label label7;
        private TextBox txtQueQuan;
        private Label label2;
        private Button btnXemXepHangDTB;
        private Button btnTongKetDiemSinhVien;
        private Button btnCapNhatDiem;
        private Button btnXemTKB;
        private Label txtSoLuongLop;
    }
}