namespace QLDiemSVKhoaCNNT
{
    partial class FrmXemLop
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
            btnDangKySVvaoLop = new Button();
            btnXemLopTrong = new Button();
            dgvLopHoc = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLopHoc).BeginInit();
            SuspendLayout();
            // 
            // btnDangKySVvaoLop
            // 
            btnDangKySVvaoLop.Location = new Point(32, 451);
            btnDangKySVvaoLop.Name = "btnDangKySVvaoLop";
            btnDangKySVvaoLop.Size = new Size(191, 29);
            btnDangKySVvaoLop.TabIndex = 88;
            btnDangKySVvaoLop.Text = "Thêm sinh viên vào lớp";
            btnDangKySVvaoLop.UseVisualStyleBackColor = true;
            // 
            // btnXemLopTrong
            // 
            btnXemLopTrong.Location = new Point(32, 416);
            btnXemLopTrong.Name = "btnXemLopTrong";
            btnXemLopTrong.Size = new Size(141, 29);
            btnXemLopTrong.TabIndex = 87;
            btnXemLopTrong.Text = "Xem lớp trống";
            btnXemLopTrong.UseVisualStyleBackColor = true;
            btnXemLopTrong.Click += btnXemLopTrong_Click;
            // 
            // dgvLopHoc
            // 
            dgvLopHoc.AllowUserToAddRows = false;
            dgvLopHoc.AllowUserToDeleteRows = false;
            dgvLopHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLopHoc.Location = new Point(32, 57);
            dgvLopHoc.Name = "dgvLopHoc";
            dgvLopHoc.ReadOnly = true;
            dgvLopHoc.RowHeadersVisible = false;
            dgvLopHoc.RowHeadersWidth = 51;
            dgvLopHoc.Size = new Size(903, 312);
            dgvLopHoc.TabIndex = 86;
            // 
            // FrmXemLop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1146, 633);
            Controls.Add(btnDangKySVvaoLop);
            Controls.Add(btnXemLopTrong);
            Controls.Add(dgvLopHoc);
            Name = "FrmXemLop";
            Text = "Xem lớp";
            Load += FrmXemLop_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLopHoc).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDangKySVvaoLop;
        private Button btnXemLopTrong;
        private DataGridView dgvLopHoc;
    }
}