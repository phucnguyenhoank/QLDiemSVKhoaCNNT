namespace QLDiemSVKhoaCNNT
{
    partial class FrmMotSinhVienCoQuaMon
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
            txtMaSinhVien = new TextBox();
            txtMaMonHoc = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnKiemTraQuaMon = new Button();
            SuspendLayout();
            // 
            // txtMaSinhVien
            // 
            txtMaSinhVien.Location = new Point(105, 59);
            txtMaSinhVien.Name = "txtMaSinhVien";
            txtMaSinhVien.Size = new Size(125, 27);
            txtMaSinhVien.TabIndex = 0;
            // 
            // txtMaMonHoc
            // 
            txtMaMonHoc.Location = new Point(440, 61);
            txtMaMonHoc.Name = "txtMaMonHoc";
            txtMaMonHoc.Size = new Size(125, 27);
            txtMaMonHoc.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(105, 30);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 2;
            label1.Text = "Mã sinh viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(440, 30);
            label2.Name = "label2";
            label2.Size = new Size(92, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã môn học";
            // 
            // btnKiemTraQuaMon
            // 
            btnKiemTraQuaMon.Location = new Point(277, 161);
            btnKiemTraQuaMon.Name = "btnKiemTraQuaMon";
            btnKiemTraQuaMon.Size = new Size(94, 29);
            btnKiemTraQuaMon.TabIndex = 4;
            btnKiemTraQuaMon.Text = "Kiểm tra";
            btnKiemTraQuaMon.UseVisualStyleBackColor = true;
            btnKiemTraQuaMon.Click += btnKiemTraQuaMon_Click;
            // 
            // FrmMotSinhVienCoQuaMon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnKiemTraQuaMon);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtMaMonHoc);
            Controls.Add(txtMaSinhVien);
            Name = "FrmMotSinhVienCoQuaMon";
            Text = "Kiểm tra một sinh viên có qua môn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMaSinhVien;
        private TextBox txtMaMonHoc;
        private Label label1;
        private Label label2;
        private Button btnKiemTraQuaMon;
    }
}