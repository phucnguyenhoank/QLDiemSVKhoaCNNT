namespace QLDiemSVKhoaCNNT
{
    partial class frmTest
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvReadData = new DataGridView();
            btnGet = new Button();
            btnTestConnection = new Button();
            btnThemGV = new Button();
            btnXoaMonHoc = new Button();
            btnDKSinhVienVaoLop = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReadData).BeginInit();
            SuspendLayout();
            // 
            // dgvReadData
            // 
            dgvReadData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReadData.Location = new Point(306, 43);
            dgvReadData.Name = "dgvReadData";
            dgvReadData.RowHeadersWidth = 51;
            dgvReadData.Size = new Size(671, 319);
            dgvReadData.TabIndex = 0;
            // 
            // btnGet
            // 
            btnGet.Location = new Point(197, 43);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(94, 29);
            btnGet.TabIndex = 1;
            btnGet.Text = "get";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // btnTestConnection
            // 
            btnTestConnection.Location = new Point(12, 26);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(145, 29);
            btnTestConnection.TabIndex = 2;
            btnTestConnection.Text = "Test Connection";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // btnThemGV
            // 
            btnThemGV.Location = new Point(36, 191);
            btnThemGV.Name = "btnThemGV";
            btnThemGV.Size = new Size(170, 29);
            btnThemGV.TabIndex = 3;
            btnThemGV.Text = "Thêm giảng viên";
            btnThemGV.UseVisualStyleBackColor = true;
            btnThemGV.Click += btnThemGV_Click;
            // 
            // btnXoaMonHoc
            // 
            btnXoaMonHoc.Location = new Point(21, 353);
            btnXoaMonHoc.Name = "btnXoaMonHoc";
            btnXoaMonHoc.Size = new Size(158, 29);
            btnXoaMonHoc.TabIndex = 4;
            btnXoaMonHoc.Text = "Xóa môn học";
            btnXoaMonHoc.UseVisualStyleBackColor = true;
            btnXoaMonHoc.Click += btnXoaMonHoc_Click;
            // 
            // btnDKSinhVienVaoLop
            // 
            btnDKSinhVienVaoLop.Location = new Point(114, 451);
            btnDKSinhVienVaoLop.Name = "btnDKSinhVienVaoLop";
            btnDKSinhVienVaoLop.Size = new Size(230, 29);
            btnDKSinhVienVaoLop.TabIndex = 5;
            btnDKSinhVienVaoLop.Text = "Đăng ký sinh viên vào lớp";
            btnDKSinhVienVaoLop.UseVisualStyleBackColor = true;
            btnDKSinhVienVaoLop.Click += btnDKSinhVienVaoLop_Click;
            // 
            // frmTest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 635);
            Controls.Add(btnDKSinhVienVaoLop);
            Controls.Add(btnXoaMonHoc);
            Controls.Add(btnThemGV);
            Controls.Add(btnTestConnection);
            Controls.Add(btnGet);
            Controls.Add(dgvReadData);
            Name = "frmTest";
            Text = "Test Statement";
            ((System.ComponentModel.ISupportInitialize)dgvReadData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvReadData;
        private Button btnGet;
        private Button btnTestConnection;
        private Button btnThemGV;
        private Button btnXoaMonHoc;
        private Button btnDKSinhVienVaoLop;
    }
}
