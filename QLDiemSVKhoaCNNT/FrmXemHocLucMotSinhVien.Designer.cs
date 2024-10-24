namespace QLDiemSVKhoaCNNT
{
    partial class FrmXemHocLucMotSinhVien
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
            btnXemHocLuc = new Button();
            label1 = new Label();
            txtMaSinhVien = new TextBox();
            lblHocLucSinhVien = new Label();
            SuspendLayout();
            // 
            // btnXemHocLuc
            // 
            btnXemHocLuc.Location = new Point(230, 127);
            btnXemHocLuc.Name = "btnXemHocLuc";
            btnXemHocLuc.Size = new Size(145, 29);
            btnXemHocLuc.TabIndex = 4;
            btnXemHocLuc.Text = "Xem học lực";
            btnXemHocLuc.UseVisualStyleBackColor = true;
            btnXemHocLuc.Click += btnXemHocLuc_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(230, 41);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 6;
            label1.Text = "Mã sinh viên";
            // 
            // txtMaSinhVien
            // 
            txtMaSinhVien.Location = new Point(230, 70);
            txtMaSinhVien.Name = "txtMaSinhVien";
            txtMaSinhVien.Size = new Size(125, 27);
            txtMaSinhVien.TabIndex = 5;
            // 
            // lblHocLucSinhVien
            // 
            lblHocLucSinhVien.AutoSize = true;
            lblHocLucSinhVien.Location = new Point(389, 73);
            lblHocLucSinhVien.Name = "lblHocLucSinhVien";
            lblHocLucSinhVien.Size = new Size(172, 20);
            lblHocLucSinhVien.TabIndex = 7;
            lblHocLucSinhVien.Text = "Học lực sẽ hiển thị ở đây";
            // 
            // FrmXemHocLucMotSinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblHocLucSinhVien);
            Controls.Add(label1);
            Controls.Add(txtMaSinhVien);
            Controls.Add(btnXemHocLuc);
            Name = "FrmXemHocLucMotSinhVien";
            Text = "Xem học lực một sinh viên";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnXemHocLuc;
        private Label label1;
        private TextBox txtMaSinhVien;
        private Label lblHocLucSinhVien;
    }
}