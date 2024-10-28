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
            btnTaiLai = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            dgvMonHoc = new DataGridView();
            txtSoTinChi = new TextBox();
            txtTenMonHoc = new TextBox();
            txtMaMonHoc = new TextBox();
            txtMaMonHocTimKiem = new TextBox();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            btnTimKiem = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).BeginInit();
            SuspendLayout();
            // 
            // btnTaiLai
            // 
            btnTaiLai.Location = new Point(842, 354);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(94, 29);
            btnTaiLai.TabIndex = 69;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(123, 315);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 67;
            label5.Text = "Số tín chỉ:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(100, 256);
            label4.Name = "label4";
            label4.Size = new Size(97, 20);
            label4.TabIndex = 66;
            label4.Text = "Tên môn học:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(103, 198);
            label3.Name = "label3";
            label3.Size = new Size(95, 20);
            label3.TabIndex = 65;
            label3.Text = "Mã môn học:";
            // 
            // dgvMonHoc
            // 
            dgvMonHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonHoc.Location = new Point(359, 104);
            dgvMonHoc.Name = "dgvMonHoc";
            dgvMonHoc.RowHeadersWidth = 51;
            dgvMonHoc.Size = new Size(451, 411);
            dgvMonHoc.TabIndex = 63;
            dgvMonHoc.CellClick += dgvMonHoc_CellClick;
            // 
            // txtSoTinChi
            // 
            txtSoTinChi.Location = new Point(204, 312);
            txtSoTinChi.Name = "txtSoTinChi";
            txtSoTinChi.Size = new Size(125, 27);
            txtSoTinChi.TabIndex = 61;
            // 
            // txtTenMonHoc
            // 
            txtTenMonHoc.Location = new Point(204, 253);
            txtTenMonHoc.Name = "txtTenMonHoc";
            txtTenMonHoc.Size = new Size(125, 27);
            txtTenMonHoc.TabIndex = 60;
            // 
            // txtMaMonHoc
            // 
            txtMaMonHoc.Location = new Point(204, 198);
            txtMaMonHoc.Name = "txtMaMonHoc";
            txtMaMonHoc.Size = new Size(125, 27);
            txtMaMonHoc.TabIndex = 59;
            // 
            // txtMaMonHocTimKiem
            // 
            txtMaMonHocTimKiem.Location = new Point(359, 45);
            txtMaMonHocTimKiem.Name = "txtMaMonHocTimKiem";
            txtMaMonHocTimKiem.Size = new Size(451, 27);
            txtMaMonHocTimKiem.TabIndex = 58;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(842, 303);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 57;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(842, 252);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 56;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(842, 201);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 55;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(842, 43);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(103, 29);
            btnTimKiem.TabIndex = 54;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(234, 47);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 70;
            label2.Text = "Mã môn học:";
            // 
            // FrmQLMonHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1325, 623);
            Controls.Add(label2);
            Controls.Add(btnTaiLai);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dgvMonHoc);
            Controls.Add(txtSoTinChi);
            Controls.Add(txtTenMonHoc);
            Controls.Add(txtMaMonHoc);
            Controls.Add(txtMaMonHocTimKiem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(btnTimKiem);
            Name = "FrmQLMonHoc";
            Text = "FrmQLMonHoc";
            Load += FrmQLMonHoc_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTaiLai;
        private Label label5;
        private Label label4;
        private Label label3;
        private DataGridView dgvMonHoc;
        private TextBox txtSoTinChi;
        private TextBox txtTenMonHoc;
        private TextBox txtMaMonHoc;
        private TextBox txtMaMonHocTimKiem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private Button btnTimKiem;
        private Label label2;
    }
}