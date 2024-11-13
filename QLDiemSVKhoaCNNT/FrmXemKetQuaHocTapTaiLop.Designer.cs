namespace QLDiemSVKhoaCNNT
{
    partial class FrmXemKetQuaHocTapTaiLop
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
            dgvDiemSinhVienCuaLop = new DataGridView();
            label2 = new Label();
            label1 = new Label();
            cbxMaLopHoc = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvDiemSinhVienCuaLop).BeginInit();
            SuspendLayout();
            // 
            // dgvDiemSinhVienCuaLop
            // 
            dgvDiemSinhVienCuaLop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiemSinhVienCuaLop.Location = new Point(42, 153);
            dgvDiemSinhVienCuaLop.Name = "dgvDiemSinhVienCuaLop";
            dgvDiemSinhVienCuaLop.RowHeadersWidth = 51;
            dgvDiemSinhVienCuaLop.Size = new Size(940, 253);
            dgvDiemSinhVienCuaLop.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 130);
            label2.Name = "label2";
            label2.Size = new Size(203, 20);
            label2.TabIndex = 6;
            label2.Text = "Danh sách điểm của sinh viên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 45);
            label1.Name = "label1";
            label1.Size = new Size(143, 20);
            label1.TabIndex = 5;
            label1.Text = "Mã lớp học cần xem";
            // 
            // cbxMaLopHoc
            // 
            cbxMaLopHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMaLopHoc.FormattingEnabled = true;
            cbxMaLopHoc.Location = new Point(42, 68);
            cbxMaLopHoc.Name = "cbxMaLopHoc";
            cbxMaLopHoc.Size = new Size(224, 28);
            cbxMaLopHoc.TabIndex = 4;
            cbxMaLopHoc.SelectedIndexChanged += cbxMaLopHoc_SelectedIndexChanged;
            // 
            // FrmXemKetQuaHocTapTaiLop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 450);
            Controls.Add(dgvDiemSinhVienCuaLop);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbxMaLopHoc);
            Name = "FrmXemKetQuaHocTapTaiLop";
            Text = "Xem kết quả học tập tại lớp";
            Load += FrmXemKetQuaHocTapTaiLop_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDiemSinhVienCuaLop).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDiemSinhVienCuaLop;
        private Label label2;
        private Label label1;
        private ComboBox cbxMaLopHoc;
    }
}