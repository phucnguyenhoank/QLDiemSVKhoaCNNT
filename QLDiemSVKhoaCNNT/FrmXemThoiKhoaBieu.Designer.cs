namespace QLDiemSVKhoaCNNT
{
    partial class FrmXemThoiKhoaBieu
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
            dgvTKBCuaSV = new DataGridView();
            label2 = new Label();
            label1 = new Label();
            cbxMaSV = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvTKBCuaSV).BeginInit();
            SuspendLayout();
            // 
            // dgvTKBCuaSV
            // 
            dgvTKBCuaSV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTKBCuaSV.Location = new Point(52, 153);
            dgvTKBCuaSV.Name = "dgvTKBCuaSV";
            dgvTKBCuaSV.RowHeadersWidth = 51;
            dgvTKBCuaSV.Size = new Size(717, 253);
            dgvTKBCuaSV.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 130);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 10;
            label2.Text = "Thời khóa biểu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 45);
            label1.Name = "label1";
            label1.Size = new Size(150, 20);
            label1.TabIndex = 9;
            label1.Text = "Mã sinh viên cần xem";
            // 
            // cbxMaSV
            // 
            cbxMaSV.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMaSV.FormattingEnabled = true;
            cbxMaSV.Location = new Point(52, 68);
            cbxMaSV.Name = "cbxMaSV";
            cbxMaSV.Size = new Size(224, 28);
            cbxMaSV.TabIndex = 8;
            cbxMaSV.SelectedIndexChanged += cbxMaSV_SelectedIndexChanged;
            // 
            // FrmXemThoiKhoaBieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 450);
            Controls.Add(dgvTKBCuaSV);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbxMaSV);
            Name = "FrmXemThoiKhoaBieu";
            Text = "FrmXemThoiKhoaBieu";
            Load += FrmXemThoiKhoaBieu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTKBCuaSV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTKBCuaSV;
        private Label label2;
        private Label label1;
        private ComboBox cbxMaSV;
    }
}