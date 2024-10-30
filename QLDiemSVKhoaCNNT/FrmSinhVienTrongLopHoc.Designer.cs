namespace QLDiemSVKhoaCNNT
{
    partial class FrmSinhVienTrongLopHoc
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
            dgvDanhSachSV = new DataGridView();
            lblSoLuongSV = new Label();
            lblPhanTramQuaMon = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSV).BeginInit();
            SuspendLayout();
            // 
            // dgvDanhSachSV
            // 
            dgvDanhSachSV.AllowUserToAddRows = false;
            dgvDanhSachSV.AllowUserToDeleteRows = false;
            dgvDanhSachSV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachSV.Location = new Point(0, 97);
            dgvDanhSachSV.Name = "dgvDanhSachSV";
            dgvDanhSachSV.ReadOnly = true;
            dgvDanhSachSV.RowHeadersWidth = 51;
            dgvDanhSachSV.Size = new Size(800, 356);
            dgvDanhSachSV.TabIndex = 0;
            // 
            // lblSoLuongSV
            // 
            lblSoLuongSV.AutoSize = true;
            lblSoLuongSV.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblSoLuongSV.Location = new Point(5, 25);
            lblSoLuongSV.Name = "lblSoLuongSV";
            lblSoLuongSV.Size = new Size(135, 28);
            lblSoLuongSV.TabIndex = 1;
            lblSoLuongSV.Text = "lblSoLuongSV";
            // 
            // lblPhanTramQuaMon
            // 
            lblPhanTramQuaMon.AutoSize = true;
            lblPhanTramQuaMon.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblPhanTramQuaMon.Location = new Point(418, 25);
            lblPhanTramQuaMon.Name = "lblPhanTramQuaMon";
            lblPhanTramQuaMon.Size = new Size(196, 28);
            lblPhanTramQuaMon.TabIndex = 2;
            lblPhanTramQuaMon.Text = "lblPhanTramQuaMon";
            // 
            // FrmSinhVienTrongLopHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPhanTramQuaMon);
            Controls.Add(lblSoLuongSV);
            Controls.Add(dgvDanhSachSV);
            Name = "FrmSinhVienTrongLopHoc";
            Text = "Danh sách sinh viên trong lớp học";
            Load += FrmSinhVienTrongLopHoc_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachSV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dgvDanhSachSV;
        public Label lblSoLuongSV;
        public Label lblPhanTramQuaMon;
    }
}