namespace QLDiemSVKhoaCNNT
{
    partial class FrmCapNhatDiemSinhVien
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
            cbxMaLopHoc = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            dgvSinhVienCuaLop = new DataGridView();
            btnCapNhatDiem = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVienCuaLop).BeginInit();
            SuspendLayout();
            // 
            // cbxMaLopHoc
            // 
            cbxMaLopHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMaLopHoc.FormattingEnabled = true;
            cbxMaLopHoc.Location = new Point(46, 52);
            cbxMaLopHoc.Name = "cbxMaLopHoc";
            cbxMaLopHoc.Size = new Size(224, 28);
            cbxMaLopHoc.TabIndex = 0;
            cbxMaLopHoc.SelectedIndexChanged += cbxMaLopHoc_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 29);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 1;
            label1.Text = "Chọn mã lớp học";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 114);
            label2.Name = "label2";
            label2.Size = new Size(191, 20);
            label2.TabIndex = 2;
            label2.Text = "Danh sách sinh viên của lớp";
            // 
            // dgvSinhVienCuaLop
            // 
            dgvSinhVienCuaLop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVienCuaLop.Location = new Point(46, 137);
            dgvSinhVienCuaLop.Name = "dgvSinhVienCuaLop";
            dgvSinhVienCuaLop.RowHeadersWidth = 51;
            dgvSinhVienCuaLop.Size = new Size(912, 253);
            dgvSinhVienCuaLop.TabIndex = 3;
            dgvSinhVienCuaLop.CellValueChanged += dgvSinhVienCuaLop_CellValueChanged;
            // 
            // btnCapNhatDiem
            // 
            btnCapNhatDiem.Location = new Point(827, 102);
            btnCapNhatDiem.Name = "btnCapNhatDiem";
            btnCapNhatDiem.Size = new Size(131, 29);
            btnCapNhatDiem.TabIndex = 23;
            btnCapNhatDiem.Text = "Cập nhật điểm";
            btnCapNhatDiem.UseVisualStyleBackColor = true;
            btnCapNhatDiem.Click += btnCapNhatDiem_Click;
            // 
            // FrmCapNhatDiemSinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 450);
            Controls.Add(btnCapNhatDiem);
            Controls.Add(dgvSinhVienCuaLop);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbxMaLopHoc);
            Name = "FrmCapNhatDiemSinhVien";
            Text = "Cập nhật điểm sinh viên";
            Load += FrmCapNhatDiemSinhVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSinhVienCuaLop).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbxMaLopHoc;
        private Label label1;
        private Label label2;
        private DataGridView dgvSinhVienCuaLop;
        private Button btnCapNhatDiem;
    }
}