﻿using QLDiemSVKhoaCNNT.DAL;
using QLDiemSVKhoaCNNT.DBConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLDiemSVKhoaCNNT
{
    public partial class FrmQLLopHoc : Form
    {
        public FrmQLLopHoc()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maGiangVienTimKiem = textBox1.Text.Trim(); // Lấy mã sinh viên từ TextBox

            if (!string.IsNullOrEmpty(maGiangVienTimKiem)) // Kiểm tra mã sinh viên không rỗng
            {
                try
                {
                    // Khởi tạo ViewDAL để lấy dữ liệu
                    LopHocDAL lopHocDAL = new LopHocDAL();

                    // Lấy danh sách sinh viên
                    DataTable dtLopHoc = lopHocDAL.GetViewLopHoc();

                    // Sử dụng DataView để lọc dữ liệu theo Mã sinh viên
                    DataView dv = new DataView(dtLopHoc);
                    dv.RowFilter = string.Format("MaLopHoc = '{0}'", maGiangVienTimKiem);

                    // Kiểm tra nếu có kết quả tìm kiếm
                    if (dv.Count > 0)
                    {
                        dataGridView1.DataSource = dv; // Gán DataView đã lọc vào DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Lop hoc với mã này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException sqlEx)
                {
                    // Bắt lỗi SQL Server nếu có
                    MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server btnTimKiem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Bắt lỗi tổng quát
                    MessageBox.Show(ex.Message, "Lỗi btnTimKiem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải dòng hợp lệ hay không (dòng tiêu đề không hợp lệ)
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán giá trị từ các ô của dòng vào các TextBox
                textBox2.Text = row.Cells["MaMonHoc"].Value.ToString();
                textBox3.Text = row.Cells["TenMonHoc"].Value.ToString();
                textBox4.Text = row.Cells["SoTinChi"].Value.ToString();
            }
        }

        private void FrmQLLopHoc_Load(object sender, EventArgs e)
        {
            try
            {
                ViewDAL monHocDAL = new ViewDAL();
                comboBox5.DataSource = monHocDAL.GetViewMonHoc();
                comboBox5.DisplayMember = "MaMonHoc";
                comboBox5.ValueMember = "MaMonHoc";
                comboBox5.SelectedIndex = 0;
                ViewDAL giangVienDAl = new ViewDAL();
                comboBox4.DataSource = giangVienDAl.GetViewGiangVien();
                comboBox4.DisplayMember = "MaGiangVien";
                comboBox4.ValueMember = "MaGiangVien";
                comboBox4.SelectedIndex = 0;

            }
            catch(SqlException sqlEx) {
            
                MessageBox.Show(sqlEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                LopHocDAL viewDAL = new LopHocDAL();
                dataGridView1.DataSource = viewDAL.GetViewLopHoc();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
