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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgvLopHocConTrong = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLopHocConTrong).BeginInit();
            SuspendLayout();
            // 
            // dgvLopHocConTrong
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvLopHocConTrong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvLopHocConTrong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvLopHocConTrong.DefaultCellStyle = dataGridViewCellStyle5;
            dgvLopHocConTrong.Location = new Point(52, 69);
            dgvLopHocConTrong.Name = "dgvLopHocConTrong";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvLopHocConTrong.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvLopHocConTrong.RowHeadersWidth = 51;
            dgvLopHocConTrong.Size = new Size(701, 387);
            dgvLopHocConTrong.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 32);
            label1.Name = "label1";
            label1.Size = new Size(225, 20);
            label1.TabIndex = 2;
            label1.Text = "CÁC LỚP HỌC CÒN CHỖ TRỐNG";
            // 
            // FrmLopHocTrong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 496);
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