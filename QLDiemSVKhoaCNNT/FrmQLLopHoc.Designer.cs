namespace QLDiemSVKhoaCNNT
{
    partial class FrmQLLopHoc
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
            dgvLopHoc = new DataGridView();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            btnSuaLopHoc = new Button();
            btnXoaLopHoc = new Button();
            btnThemLopHoc = new Button();
            btnTimKiem = new Button();
            label2 = new Label();
            label7 = new Label();
            label8 = new Label();
            cbxTietBatDau = new ComboBox();
            cbxTietKetThuc = new ComboBox();
            cbxMaPhongHoc = new ComboBox();
            cbxMaGiangVien = new ComboBox();
            cbxMaMonHoc = new ComboBox();
            cbxThu = new ComboBox();
            label9 = new Label();
            btnLopPhuTrach = new Button();
            btnXemLopTrong = new Button();
            btnDangKySVvaoLop = new Button();
            btnXemBangDiemCuaLop = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLopHoc).BeginInit();
            SuspendLayout();
            // 
            // btnTaiLai
            // 
            btnTaiLai.Location = new Point(980, 69);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(94, 29);
            btnTaiLai.TabIndex = 69;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 217);
            label6.Name = "label6";
            label6.Size = new Size(93, 20);
            label6.TabIndex = 68;
            label6.Text = "Tiết kết thúc:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 180);
            label5.Name = "label5";
            label5.Size = new Size(92, 20);
            label5.TabIndex = 67;
            label5.Text = "Tiết bắt đầu:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(93, 140);
            label4.Name = "label4";
            label4.Size = new Size(37, 20);
            label4.TabIndex = 66;
            label4.Text = "Thứ:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 104);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 65;
            label3.Text = "Mã lớp học:";
            // 
            // dgvLopHoc
            // 
            dgvLopHoc.AllowUserToAddRows = false;
            dgvLopHoc.AllowUserToDeleteRows = false;
            dgvLopHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLopHoc.Location = new Point(319, 104);
            dgvLopHoc.Name = "dgvLopHoc";
            dgvLopHoc.ReadOnly = true;
            dgvLopHoc.RowHeadersVisible = false;
            dgvLopHoc.RowHeadersWidth = 51;
            dgvLopHoc.Size = new Size(903, 312);
            dgvLopHoc.TabIndex = 63;
            dgvLopHoc.CellClick += dataGridView1_CellClick;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(151, 104);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(151, 27);
            textBox2.TabIndex = 59;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(151, 57);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(489, 27);
            textBox1.TabIndex = 58;
            // 
            // btnSuaLopHoc
            // 
            btnSuaLopHoc.Location = new Point(240, 443);
            btnSuaLopHoc.Name = "btnSuaLopHoc";
            btnSuaLopHoc.Size = new Size(94, 29);
            btnSuaLopHoc.TabIndex = 57;
            btnSuaLopHoc.Text = "Sửa";
            btnSuaLopHoc.UseVisualStyleBackColor = true;
            btnSuaLopHoc.Click += btnSuaLopHoc_Click;
            // 
            // btnXoaLopHoc
            // 
            btnXoaLopHoc.Location = new Point(140, 443);
            btnXoaLopHoc.Name = "btnXoaLopHoc";
            btnXoaLopHoc.Size = new Size(94, 29);
            btnXoaLopHoc.TabIndex = 56;
            btnXoaLopHoc.Text = "Xóa";
            btnXoaLopHoc.UseVisualStyleBackColor = true;
            btnXoaLopHoc.Click += btnXoaLopHoc_Click;
            // 
            // btnThemLopHoc
            // 
            btnThemLopHoc.Location = new Point(40, 443);
            btnThemLopHoc.Name = "btnThemLopHoc";
            btnThemLopHoc.Size = new Size(94, 29);
            btnThemLopHoc.TabIndex = 55;
            btnThemLopHoc.Text = "Thêm";
            btnThemLopHoc.UseVisualStyleBackColor = true;
            btnThemLopHoc.Click += btnThemLopHoc_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(658, 55);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 54;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 251);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 70;
            label2.Text = "Mã phòng học:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 288);
            label7.Name = "label7";
            label7.Size = new Size(106, 20);
            label7.TabIndex = 72;
            label7.Text = "Mã giảng viên:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(31, 325);
            label8.Name = "label8";
            label8.Size = new Size(95, 20);
            label8.TabIndex = 74;
            label8.Text = "Mã môn học:";
            label8.Click += label8_Click;
            // 
            // cbxTietBatDau
            // 
            cbxTietBatDau.FormattingEnabled = true;
            cbxTietBatDau.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            cbxTietBatDau.Location = new Point(151, 177);
            cbxTietBatDau.Name = "cbxTietBatDau";
            cbxTietBatDau.Size = new Size(151, 28);
            cbxTietBatDau.TabIndex = 76;
            // 
            // cbxTietKetThuc
            // 
            cbxTietKetThuc.FormattingEnabled = true;
            cbxTietKetThuc.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            cbxTietKetThuc.Location = new Point(151, 214);
            cbxTietKetThuc.Name = "cbxTietKetThuc";
            cbxTietKetThuc.Size = new Size(151, 28);
            cbxTietKetThuc.TabIndex = 77;
            // 
            // cbxMaPhongHoc
            // 
            cbxMaPhongHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMaPhongHoc.FormattingEnabled = true;
            cbxMaPhongHoc.Location = new Point(151, 251);
            cbxMaPhongHoc.Name = "cbxMaPhongHoc";
            cbxMaPhongHoc.Size = new Size(151, 28);
            cbxMaPhongHoc.TabIndex = 78;
            // 
            // cbxMaGiangVien
            // 
            cbxMaGiangVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMaGiangVien.FormattingEnabled = true;
            cbxMaGiangVien.Location = new Point(151, 285);
            cbxMaGiangVien.Name = "cbxMaGiangVien";
            cbxMaGiangVien.Size = new Size(151, 28);
            cbxMaGiangVien.TabIndex = 79;
            // 
            // cbxMaMonHoc
            // 
            cbxMaMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMaMonHoc.FormattingEnabled = true;
            cbxMaMonHoc.Location = new Point(151, 322);
            cbxMaMonHoc.Name = "cbxMaMonHoc";
            cbxMaMonHoc.Size = new Size(151, 28);
            cbxMaMonHoc.TabIndex = 80;
            // 
            // cbxThu
            // 
            cbxThu.FormattingEnabled = true;
            cbxThu.Items.AddRange(new object[] { "2", "3", "4", "5", "6", "7" });
            cbxThu.Location = new Point(151, 140);
            cbxThu.Name = "cbxThu";
            cbxThu.Size = new Size(151, 28);
            cbxThu.TabIndex = 81;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(45, 60);
            label9.Name = "label9";
            label9.Size = new Size(87, 20);
            label9.TabIndex = 82;
            label9.Text = "Mã lớp học:";
            // 
            // btnLopPhuTrach
            // 
            btnLopPhuTrach.Location = new Point(340, 443);
            btnLopPhuTrach.Name = "btnLopPhuTrach";
            btnLopPhuTrach.Size = new Size(141, 29);
            btnLopPhuTrach.TabIndex = 83;
            btnLopPhuTrach.Text = "Lớp phụ trách";
            btnLopPhuTrach.UseVisualStyleBackColor = true;
            btnLopPhuTrach.Click += btnLopPhuTrach_Click;
            // 
            // btnXemLopTrong
            // 
            btnXemLopTrong.Location = new Point(487, 443);
            btnXemLopTrong.Name = "btnXemLopTrong";
            btnXemLopTrong.Size = new Size(141, 29);
            btnXemLopTrong.TabIndex = 84;
            btnXemLopTrong.Text = "Xem lớp trống";
            btnXemLopTrong.UseVisualStyleBackColor = true;
            btnXemLopTrong.Click += btnXemLopTrong_Click;
            // 
            // btnDangKySVvaoLop
            // 
            btnDangKySVvaoLop.Location = new Point(40, 478);
            btnDangKySVvaoLop.Name = "btnDangKySVvaoLop";
            btnDangKySVvaoLop.Size = new Size(191, 29);
            btnDangKySVvaoLop.TabIndex = 85;
            btnDangKySVvaoLop.Text = "Thêm sinh viên vào lớp";
            btnDangKySVvaoLop.UseVisualStyleBackColor = true;
            btnDangKySVvaoLop.Click += btnDangKySVvaoLop_Click;
            // 
            // btnXemBangDiemCuaLop
            // 
            btnXemBangDiemCuaLop.Location = new Point(240, 478);
            btnXemBangDiemCuaLop.Name = "btnXemBangDiemCuaLop";
            btnXemBangDiemCuaLop.Size = new Size(163, 29);
            btnXemBangDiemCuaLop.TabIndex = 86;
            btnXemBangDiemCuaLop.Text = "Bảng điểm của lớp";
            btnXemBangDiemCuaLop.UseVisualStyleBackColor = true;
            btnXemBangDiemCuaLop.Click += btnXemBangDiemCuaLop_Click;
            // 
            // FrmQLLopHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 551);
            Controls.Add(btnXemBangDiemCuaLop);
            Controls.Add(btnDangKySVvaoLop);
            Controls.Add(btnXemLopTrong);
            Controls.Add(btnLopPhuTrach);
            Controls.Add(label9);
            Controls.Add(cbxThu);
            Controls.Add(cbxMaMonHoc);
            Controls.Add(cbxMaGiangVien);
            Controls.Add(cbxMaPhongHoc);
            Controls.Add(cbxTietKetThuc);
            Controls.Add(cbxTietBatDau);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(btnTaiLai);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dgvLopHoc);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(btnSuaLopHoc);
            Controls.Add(btnXoaLopHoc);
            Controls.Add(btnThemLopHoc);
            Controls.Add(btnTimKiem);
            Name = "FrmQLLopHoc";
            Text = "Quản lý lớp học";
            Load += FrmQLLopHoc_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLopHoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTaiLai;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private DataGridView dgvLopHoc;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button btnSuaLopHoc;
        private Button btnXoaLopHoc;
        private Button btnThemLopHoc;
        private Button btnTimKiem;
        private Label label2;
        private Label label7;
        private Label label8;
        private ComboBox cbxTietBatDau;
        private ComboBox cbxTietKetThuc;
        private ComboBox cbxMaPhongHoc;
        private ComboBox cbxMaGiangVien;
        private ComboBox cbxMaMonHoc;
        private ComboBox cbxThu;
        private Label label9;
        private Button btnLopPhuTrach;
        private Button btnXemLopTrong;
        private Button btnDangKySVvaoLop;
        private Button btnXemBangDiemCuaLop;
    }
}