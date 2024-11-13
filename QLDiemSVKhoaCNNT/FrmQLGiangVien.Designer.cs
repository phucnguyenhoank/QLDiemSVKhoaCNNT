namespace QLDiemSVKhoaCNNT
{
    partial class FrmQLGiangVien
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
            dgvGiangVien = new DataGridView();
            txtSoDienThoai = new TextBox();
            txtEmail = new TextBox();
            txtHoVaTen = new TextBox();
            txtMaGiangVien = new TextBox();
            txtMaGiangVienTimKiem = new TextBox();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            btnTimKiem = new Button();
            label2 = new Label();
            btnKiemTraQuaMon = new Button();
            btnXemHocLucSV = new Button();
            btnGiangVienDayNhieuDKNhat = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGiangVien).BeginInit();
            SuspendLayout();
            // 
            // btnTaiLai
            // 
            btnTaiLai.Location = new Point(614, 424);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(94, 29);
            btnTaiLai.TabIndex = 53;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 293);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 52;
            label6.Text = "Số điện thoại:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(78, 228);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 51;
            label5.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 154);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 50;
            label4.Text = "Họ và tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 85);
            label3.Name = "label3";
            label3.Size = new Size(106, 20);
            label3.TabIndex = 49;
            label3.Text = "Mã giảng viên:";
            // 
            // dgvGiangVien
            // 
            dgvGiangVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGiangVien.Location = new Point(314, 63);
            dgvGiangVien.Name = "dgvGiangVien";
            dgvGiangVien.RowHeadersWidth = 51;
            dgvGiangVien.Size = new Size(836, 338);
            dgvGiangVien.TabIndex = 47;
            dgvGiangVien.CellClick += dgvGiangVien_CellClick;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(149, 290);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(125, 27);
            txtSoDienThoai.TabIndex = 46;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(149, 221);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 45;
            // 
            // txtHoVaTen
            // 
            txtHoVaTen.Location = new Point(149, 147);
            txtHoVaTen.Name = "txtHoVaTen";
            txtHoVaTen.Size = new Size(125, 27);
            txtHoVaTen.TabIndex = 44;
            // 
            // txtMaGiangVien
            // 
            txtMaGiangVien.Location = new Point(149, 85);
            txtMaGiangVien.Name = "txtMaGiangVien";
            txtMaGiangVien.Size = new Size(125, 27);
            txtMaGiangVien.TabIndex = 43;
            // 
            // txtMaGiangVienTimKiem
            // 
            txtMaGiangVienTimKiem.Location = new Point(431, 30);
            txtMaGiangVienTimKiem.Name = "txtMaGiangVienTimKiem";
            txtMaGiangVienTimKiem.Size = new Size(489, 27);
            txtMaGiangVienTimKiem.TabIndex = 42;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(514, 424);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 41;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(414, 424);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 40;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(314, 424);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 39;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(1001, 28);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 38;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(300, 29);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 54;
            label2.Text = "Mã giảng viên:";
            // 
            // btnKiemTraQuaMon
            // 
            btnKiemTraQuaMon.Location = new Point(714, 424);
            btnKiemTraQuaMon.Name = "btnKiemTraQuaMon";
            btnKiemTraQuaMon.Size = new Size(165, 29);
            btnKiemTraQuaMon.TabIndex = 55;
            btnKiemTraQuaMon.Text = "Kiểm tra qua môn";
            btnKiemTraQuaMon.UseVisualStyleBackColor = true;
            btnKiemTraQuaMon.Click += btnKiemTraSV_Click;
            // 
            // btnXemHocLucSV
            // 
            btnXemHocLucSV.Location = new Point(885, 424);
            btnXemHocLucSV.Name = "btnXemHocLucSV";
            btnXemHocLucSV.Size = new Size(211, 29);
            btnXemHocLucSV.TabIndex = 56;
            btnXemHocLucSV.Text = "Xem học lực sinh viên";
            btnXemHocLucSV.UseVisualStyleBackColor = true;
            btnXemHocLucSV.Click += btnXemHocLucSV_Click;
            // 
            // btnGiangVienDayNhieuDKNhat
            // 
            btnGiangVienDayNhieuDKNhat.Location = new Point(314, 459);
            btnGiangVienDayNhieuDKNhat.Name = "btnGiangVienDayNhieuDKNhat";
            btnGiangVienDayNhieuDKNhat.Size = new Size(294, 29);
            btnGiangVienDayNhieuDKNhat.TabIndex = 57;
            btnGiangVienDayNhieuDKNhat.Text = "Giảng viên dạy lớp nhiều đăng ký nhất";
            btnGiangVienDayNhieuDKNhat.UseVisualStyleBackColor = true;
            btnGiangVienDayNhieuDKNhat.Click += btnGiangVienDayNhieuDKNhat_Click;
            // 
            // FrmQLGiangVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1261, 595);
            Controls.Add(btnGiangVienDayNhieuDKNhat);
            Controls.Add(btnXemHocLucSV);
            Controls.Add(btnKiemTraQuaMon);
            Controls.Add(label2);
            Controls.Add(btnTaiLai);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dgvGiangVien);
            Controls.Add(txtSoDienThoai);
            Controls.Add(txtEmail);
            Controls.Add(txtHoVaTen);
            Controls.Add(txtMaGiangVien);
            Controls.Add(txtMaGiangVienTimKiem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(btnTimKiem);
            Name = "FrmQLGiangVien";
            Text = "FrmQLGiaoVien";
            Load += FrmQLGiaoVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGiangVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnTaiLai;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private DataGridView dgvGiangVien;
        private TextBox txtSoDienThoai;
        private TextBox txtEmail;
        private TextBox txtHoVaTen;
        private TextBox txtMaGiangVien;
        private TextBox txtMaGiangVienTimKiem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private Button btnTimKiem;
        private Label label2;
        private Button btnKiemTraQuaMon;
        private Button btnXemHocLucSV;
        private Button btnGiangVienDayNhieuDKNhat;
    }
}