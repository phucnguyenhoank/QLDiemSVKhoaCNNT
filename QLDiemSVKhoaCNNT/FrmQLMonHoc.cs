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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLDiemSVKhoaCNNT
{
    public partial class FrmQLMonHoc : Form
    {
        public FrmQLMonHoc()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo lại lớp ViewDAL để lấy dữ liệu mới
                ViewDAL viewDAL = new ViewDAL();

                // Nạp lại dữ liệu vào DataGridView
                dataGridView1.DataSource = viewDAL.GetViewMonHoc();
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int maMonHoc = int.Parse(textBox2.Text);
                string tenMonHoc = textBox3.Text;
                byte soTinChi = byte.Parse(textBox4.Text);
                MonHocDAL monHocDAL = new MonHocDAL();
                monHocDAL.ThemMonHoc(maMonHoc, tenMonHoc, soTinChi);
                MessageBox.Show($"Them mon hoc {maMonHoc} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int maMonHoc = int.Parse(textBox2.Text);

                MonHocDAL monHocDAL = new MonHocDAL();
                monHocDAL.XoaMonHoc(maMonHoc);
                MessageBox.Show($"Xoa mon hoc {maMonHoc} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int maMonHoc = int.Parse(textBox2.Text);
                string tenMonHoc = textBox3.Text;
                byte soTinChi = byte.Parse(textBox4.Text);
                MonHocDAL sinhVienDAL = new MonHocDAL();
                sinhVienDAL.SuaMonHoc(maMonHoc, tenMonHoc, soTinChi);

                MessageBox.Show($"Sua mon hoc {maMonHoc} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FrmQLMonHoc_Load(object sender, EventArgs e)
        {
            try
            {
                ViewDAL viewDAL = new ViewDAL();
                dataGridView1.DataSource = viewDAL.GetViewMonHoc();
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
                    DataTable dtGiangVien = viewDAL.GetViewMonHoc();

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