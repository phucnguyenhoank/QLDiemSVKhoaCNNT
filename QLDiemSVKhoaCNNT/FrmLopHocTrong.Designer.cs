namespace QLDiemSVKhoaCNNT
{
    partial class FrmLopHocTrong
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvLopHocConTrong = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLopHocConTrong).BeginInit();
            SuspendLayout();
            // 
            // dgvLopHocConTrong
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvLopHocConTrong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLopHocConTrong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvLopHocConTrong.DefaultCellStyle = dataGridViewCellStyle2;
            dgvLopHocConTrong.Location = new Point(52, 69);
            dgvLopHocConTrong.Name = "dgvLopHocConTrong";
            dgvLopHocConTrong.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvLopHocConTrong.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvLopHocConTrong.RowHeadersWidth = 51;
            dgvLopHocConTrong.Size = new Size(701, 387);
            dgvLopHocConTrong.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(272, 36);
            label1.Name = "label1";
            label1.Size = new Size(225, 20);
            label1.TabIndex = 2;
            label1.Text = "CÁC LỚP HỌC CÒN CHỖ TRỐNG";
            // 
            // FrmLopHocTrong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 496);
            Controls.Add(label1);
            Controls.Add(dgvLopHocConTrong);
            Name = "FrmLopHocTrong";
            Text = "Xem lớp học còn trống";
            Load += FrmLopHocTrong_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLopHocConTrong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLopHocConTrong;
        private Label label1;
    }
}