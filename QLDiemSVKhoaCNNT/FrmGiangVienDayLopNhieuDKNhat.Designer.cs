namespace QLDiemSVKhoaCNNT
{
    partial class FrmGiangVienDayLopNhieuDKNhat
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
            dgvGVDayLopNhieuDKNhat = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvGVDayLopNhieuDKNhat).BeginInit();
            SuspendLayout();
            // 
            // dgvGVDayLopNhieuDKNhat
            // 
            dgvGVDayLopNhieuDKNhat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGVDayLopNhieuDKNhat.Location = new Point(39, 44);
            dgvGVDayLopNhieuDKNhat.Name = "dgvGVDayLopNhieuDKNhat";
            dgvGVDayLopNhieuDKNhat.RowHeadersWidth = 51;
            dgvGVDayLopNhieuDKNhat.Size = new Size(723, 352);
            dgvGVDayLopNhieuDKNhat.TabIndex = 0;
            // 
            // FrmGiangVienDayLopNhieuDKNhat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvGVDayLopNhieuDKNhat);
            Name = "FrmGiangVienDayLopNhieuDKNhat";
            Text = "Danh sách giảng viên dạy lớp có nhiều đăng ký nhất";
            Load += FrmGiangVienDayLopNhieuDKNhat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvGVDayLopNhieuDKNhat).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvGVDayLopNhieuDKNhat;
    }
}