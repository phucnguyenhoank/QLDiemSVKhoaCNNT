using QLDiemSVKhoaCNNT.DAL;
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
                    ViewDAL viewDAL = new ViewDAL();

                    // Lấy danh sách sinh viên
                    DataTable dtGiangVien = viewDAL.G();

                    // Sử dụng DataView để lọc dữ liệu theo Mã sinh viên
                    DataView dv = new DataView(dtGiangVien);
                    dv.RowFilter = string.Format("MaMonHoc = '{0}'", maGiangVienTimKiem);

                    // Kiểm tra nếu có kết quả tìm kiếm
                    if (dv.Count > 0)
                    {
                        dataGridView1.DataSource = dv; // Gán DataView đã lọc vào DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy môn học với mã này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
    }
}
