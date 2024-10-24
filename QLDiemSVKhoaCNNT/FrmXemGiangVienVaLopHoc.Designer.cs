namespace QLDiemSVKhoaCNNT
{
    partial class FrmXemGiangVienVaLopHoc
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
            label2 = new Label();
            dgvLopHocDcPhuTrach = new DataGridView();
            label1 = new Label();
            cbx_giangvien = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvLopHocDcPhuTrach).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(347, 22);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 7;
            label2.Text = "label2";
            // 
            // dgvLopHocDcPhuTrach
            // 
            dgvLopHocDcPhuTrach.AllowUserToAddRows = false;
            dgvLopHocDcPhuTrach.AllowUserToDeleteRows = false;
            dgvLopHocDcPhuTrach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLopHocDcPhuTrach.Location = new Point(45, 53);
            dgvLopHocDcPhuTrach.Name = "dgvLopHocDcPhuTrach";
            dgvLopHocDcPhuTrach.ReadOnly = true;
            dgvLopHocDcPhuTrach.RowHeadersWidth = 51;
            dgvLopHocDcPhuTrach.Size = new Size(1048, 437);
            dgvLopHocDcPhuTrach.TabIndex = 6;
            dgvLopHocDcPhuTrach.DoubleClick += dgvLopHocDcPhuTrach_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 22);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 5;
            label1.Text = "Giang vien:";
            // 
            // cbx_giangvien
            // 
            cbx_giangvien.FormattingEnabled = true;
            cbx_giangvien.Location = new Point(133, 19);
            cbx_giangvien.Name = "cbx_giangvien";
            cbx_giangvien.Size = new Size(176, 28);
            cbx_giangvien.TabIndex = 4;
            cbx_giangvien.SelectedValueChanged += cbx_giangvien_SelectedValueChanged;
            // 
            // FrmXemGiangVienVaLopHoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1139, 509);
            Controls.Add(label2);
            Controls.Add(dgvLopHocDcPhuTrach);
            Controls.Add(label1);
            Controls.Add(cbx_giangvien);
            Name = "FrmXemGiangVienVaLopHoc";
            Text = "FrmXemGiangVienVaLopHoc";
            Load += FrmXemGiangVienVaLopHoc_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLopHocDcPhuTrach).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private DataGridView dgvLopHocDcPhuTrach;
        private Label label1;
        private ComboBox cbx_giangvien;
    }
}