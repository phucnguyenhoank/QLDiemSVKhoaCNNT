namespace QLDiemSVKhoaCNNT
{
    partial class FrmControl
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
            pnlLeft = new Panel();
            btnXemLop = new Button();
            btnLopHoc = new Button();
            btnMonHoc = new Button();
            btnGiangVien = new Button();
            btnSinhVien = new Button();
            pbxUTELogo = new PictureBox();
            pnlTop = new Panel();
            lblTitle = new Label();
            pnlBody = new Panel();
            btnXemSinhVien = new Button();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxUTELogo).BeginInit();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.Navy;
            pnlLeft.Controls.Add(btnXemSinhVien);
            pnlLeft.Controls.Add(btnXemLop);
            pnlLeft.Controls.Add(btnLopHoc);
            pnlLeft.Controls.Add(btnMonHoc);
            pnlLeft.Controls.Add(btnGiangVien);
            pnlLeft.Controls.Add(btnSinhVien);
            pnlLeft.Controls.Add(pbxUTELogo);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(144, 704);
            pnlLeft.TabIndex = 0;
            // 
            // btnXemLop
            // 
            btnXemLop.BackColor = Color.FromArgb(0, 0, 64);
            btnXemLop.Dock = DockStyle.Top;
            btnXemLop.FlatStyle = FlatStyle.Flat;
            btnXemLop.ForeColor = Color.White;
            btnXemLop.Location = new Point(0, 371);
            btnXemLop.Name = "btnXemLop";
            btnXemLop.Size = new Size(144, 52);
            btnXemLop.TabIndex = 5;
            btnXemLop.Text = "Xem lớp";
            btnXemLop.UseVisualStyleBackColor = false;
            btnXemLop.Click += btnXemLop_Click;
            // 
            // btnLopHoc
            // 
            btnLopHoc.BackColor = Color.FromArgb(0, 0, 64);
            btnLopHoc.Dock = DockStyle.Top;
            btnLopHoc.FlatStyle = FlatStyle.Flat;
            btnLopHoc.ForeColor = Color.White;
            btnLopHoc.Location = new Point(0, 319);
            btnLopHoc.Name = "btnLopHoc";
            btnLopHoc.Size = new Size(144, 52);
            btnLopHoc.TabIndex = 4;
            btnLopHoc.Text = "Lớp học";
            btnLopHoc.UseVisualStyleBackColor = false;
            btnLopHoc.Click += btnLopHoc_Click;
            // 
            // btnMonHoc
            // 
            btnMonHoc.BackColor = Color.FromArgb(0, 0, 64);
            btnMonHoc.Dock = DockStyle.Top;
            btnMonHoc.FlatStyle = FlatStyle.Flat;
            btnMonHoc.ForeColor = Color.White;
            btnMonHoc.Location = new Point(0, 267);
            btnMonHoc.Name = "btnMonHoc";
            btnMonHoc.Size = new Size(144, 52);
            btnMonHoc.TabIndex = 3;
            btnMonHoc.Text = "Môn học";
            btnMonHoc.UseVisualStyleBackColor = false;
            btnMonHoc.Click += btnMonHoc_Click;
            // 
            // btnGiangVien
            // 
            btnGiangVien.BackColor = Color.FromArgb(0, 0, 64);
            btnGiangVien.Dock = DockStyle.Top;
            btnGiangVien.FlatStyle = FlatStyle.Flat;
            btnGiangVien.ForeColor = Color.White;
            btnGiangVien.Location = new Point(0, 215);
            btnGiangVien.Name = "btnGiangVien";
            btnGiangVien.Size = new Size(144, 52);
            btnGiangVien.TabIndex = 2;
            btnGiangVien.Text = "Giảng viên";
            btnGiangVien.UseVisualStyleBackColor = false;
            btnGiangVien.Click += btnGiangVien_Click;
            // 
            // btnSinhVien
            // 
            btnSinhVien.BackColor = Color.FromArgb(0, 0, 64);
            btnSinhVien.Dock = DockStyle.Top;
            btnSinhVien.FlatStyle = FlatStyle.Flat;
            btnSinhVien.ForeColor = Color.White;
            btnSinhVien.Location = new Point(0, 163);
            btnSinhVien.Name = "btnSinhVien";
            btnSinhVien.Size = new Size(144, 52);
            btnSinhVien.TabIndex = 1;
            btnSinhVien.Text = "Sinh viên";
            btnSinhVien.UseVisualStyleBackColor = false;
            btnSinhVien.Click += btnSinhVien_Click;
            // 
            // pbxUTELogo
            // 
            pbxUTELogo.Dock = DockStyle.Top;
            pbxUTELogo.Image = Properties.Resources.UTELogo;
            pbxUTELogo.Location = new Point(0, 0);
            pbxUTELogo.Name = "pbxUTELogo";
            pbxUTELogo.Size = new Size(144, 163);
            pbxUTELogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxUTELogo.TabIndex = 0;
            pbxUTELogo.TabStop = false;
            pbxUTELogo.Click += pbxUTELogo_Click;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.Blue;
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(144, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1334, 84);
            pnlTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(67, 29);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(80, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HOME";
            // 
            // pnlBody
            // 
            pnlBody.BackColor = Color.FromArgb(128, 128, 255);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(144, 84);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(1334, 620);
            pnlBody.TabIndex = 2;
            // 
            // btnXemSinhVien
            // 
            btnXemSinhVien.BackColor = Color.FromArgb(0, 0, 64);
            btnXemSinhVien.Dock = DockStyle.Top;
            btnXemSinhVien.FlatStyle = FlatStyle.Flat;
            btnXemSinhVien.ForeColor = Color.White;
            btnXemSinhVien.Location = new Point(0, 423);
            btnXemSinhVien.Name = "btnXemSinhVien";
            btnXemSinhVien.Size = new Size(144, 52);
            btnXemSinhVien.TabIndex = 6;
            btnXemSinhVien.Text = "Xem sinh viên";
            btnXemSinhVien.UseVisualStyleBackColor = false;
            btnXemSinhVien.Click += btnXemSinhVien_Click;
            // 
            // FrmControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1478, 704);
            Controls.Add(pnlBody);
            Controls.Add(pnlTop);
            Controls.Add(pnlLeft);
            Name = "FrmControl";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang chính";
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxUTELogo).EndInit();
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
        private Panel pnlTop;
        private Panel pnlBody;
        private Button btnSinhVien;
        private PictureBox pbxUTELogo;
        private Button btnLopHoc;
        private Button btnMonHoc;
        private Button btnGiangVien;
        private Label lblTitle;
        private Button btnXemLop;
        private Button btnXemSinhVien;
    }
}