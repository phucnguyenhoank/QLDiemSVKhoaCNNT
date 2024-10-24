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
    public partial class FrmQLSinhVien : Form
    {
        public FrmQLSinhVien()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = int.Parse(textBox2.Text);
                string hoVaTen = textBox3.Text;
                string email = textBox4.Text;
                string soDienThoai = textBox5.Text;
                string queQuan = textBox6.Text;
                SinhVienDAL sinhVienDAL = new SinhVienDAL();
                sinhVienDAL.ThemSinhVien(maSinhVien, hoVaTen, email, soDienThoai, queQuan);

                MessageBox.Show($"Them sinh vien {maSinhVien} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = int.Parse(textBox2.Text);

                SinhVienDAL sinhVienDAL = new SinhVienDAL();
                sinhVienDAL.XoaSinhVien(maSinhVien);
                MessageBox.Show($"Xoa sinh vien {maSinhVien} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải dòng hợp lệ hay không (dòng tiêu đề không hợp lệ)
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán giá trị từ các ô của dòng vào các TextBox
                textBox2.Text = row.Cells["MaSinhVien"].Value.ToString();
                textBox3.Text = row.Cells["HoVaTen"].Value.ToString();
                textBox4.Text = row.Cells["Email"].Value.ToString();
                textBox5.Text = row.Cells["SoDienThoai"].Value.ToString();
                textBox6.Text = row.Cells["QueQuan"].Value.ToString();

            }
        }

        private void FrmQLSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                ViewDAL viewDAL = new ViewDAL();
                dataGridView1.DataSource = viewDAL.GetViewSinhVien();
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = int.Parse(textBox2.Text);
                string hoVaTen = textBox3.Text;
                string email = textBox4.Text;
                string soDienThoai = textBox5.Text;
                string queQuan = textBox6.Text;
                SinhVienDAL sinhVienDAL = new SinhVienDAL();
                sinhVienDAL.SuaSinhVien(maSinhVien, hoVaTen, email, soDienThoai, queQuan);

                MessageBox.Show($"Sua sinh vien {maSinhVien} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo lại lớp ViewDAL để lấy dữ liệu mới
                ViewDAL viewDAL = new ViewDAL();

                // Nạp lại dữ liệu vào DataGridView
                dataGridView1.DataSource = viewDAL.GetViewSinhVien();
            }
            catch (SqlException sqlEx)
            {
                // Bắt lỗi từ SQL Server nếu có
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Bắt lỗi tổng quát
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maSinhVienTimKiem = textBox1.Text.Trim(); // Lấy mã sinh viên từ TextBox

            if (!string.IsNullOrEmpty(maSinhVienTimKiem)) // Kiểm tra mã sinh viên không rỗng
            {
                try
                {
                    // Khởi tạo ViewDAL để lấy dữ liệu
                    ViewDAL viewDAL = new ViewDAL();

                    // Lấy danh sách sinh viên
                    DataTable dtSinhVien = viewDAL.GetViewSinhVien();

                    // Sử dụng DataView để lọc dữ liệu theo Mã sinh viên
                    DataView dv = new DataView(dtSinhVien);
                    dv.RowFilter = string.Format("MaSinhVien = '{0}'", maSinhVienTimKiem);

                    // Kiểm tra nếu có kết quả tìm kiếm
                    if (dv.Count > 0)
                    {
                        dataGridView1.DataSource = dv; // Gán DataView đã lọc vào DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên với mã này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
