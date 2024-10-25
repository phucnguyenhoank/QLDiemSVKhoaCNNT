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

        private void txtThemSinhVien_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = int.Parse(txtMaSinhVien.Text);
                string hoVaTen = txtHoVaTen.Text;
                string email = txtEmail.Text;
                string soDienThoai = txtSoDienThoai.Text;
                string queQuan = txtQueQuan.Text;
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

        private void btnXoaSinhVien_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = int.Parse(txtMaSinhVien.Text);

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
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];

                // Gán giá trị từ các ô của dòng vào các TextBox
                txtMaSinhVien.Text = row.Cells["MaSinhVien"].Value.ToString();
                txtHoVaTen.Text = row.Cells["HoVaTen"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtQueQuan.Text = row.Cells["QueQuan"].Value.ToString();

            }
        }

        private void FrmQLSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                ViewDAL viewDAL = new ViewDAL();
                dgvSinhVien.DataSource = viewDAL.GetViewSinhVien();
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

        private void btnSuaSinhVien_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = int.Parse(txtMaSinhVien.Text);
                string hoVaTen = txtHoVaTen.Text;
                string email = txtEmail.Text;
                string soDienThoai = txtSoDienThoai.Text;
                string queQuan = txtQueQuan.Text;
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

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo lại lớp ViewDAL để lấy dữ liệu mới
                ViewDAL viewDAL = new ViewDAL();

                // Nạp lại dữ liệu vào DataGridView
                dgvSinhVien.DataSource = viewDAL.GetViewSinhVien();
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

        private void btnTimKiemSinhVien_Click(object sender, EventArgs e)
        {
            string maSinhVienTimKiem = txtMaSinhVienTimKiem.Text.Trim(); // Lấy mã sinh viên từ TextBox

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
                        dgvSinhVien.DataSource = dv; // Gán DataView đã lọc vào DataGridView
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

        private void btnXemXepHangDTB_Click(object sender, EventArgs e)
        {
            try
            {
                FrmBangXepHangDiem bang_Xep_Hang_Theo_Diem = new FrmBangXepHangDiem();
                bang_Xep_Hang_Theo_Diem.ShowDialog();
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

        private void btnTongKetDiemSinhVien_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDiemSinhVien form_Diem1Sv = new FrmDiemSinhVien();
                form_Diem1Sv.ShowDialog();
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

        private void btnCapNhatDiem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCapNhatDiemSinhVien frmCapNhatDiemSinhVien = new FrmCapNhatDiemSinhVien();
                frmCapNhatDiemSinhVien.ShowDialog();
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

    }
}
