using QLDiemSVKhoaCNNT.DAL;
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maGiangVienTimKiem = textBox1.Text.Trim(); // Lấy mã sinh viên từ TextBox

            if (!string.IsNullOrEmpty(maGiangVienTimKiem)) // Kiểm tra mã sinh viên không rỗng
            {
                try
                {
                    // Khởi tạo ViewDAL để lấy dữ liệu
                    ViewDAL viewDAL = new ViewDAL();

                    // Lấy danh sách sinh viên
                    DataTable dtLopHoc = viewDAL.GetViewLopHoc();

                    // Sử dụng DataView để lọc dữ liệu theo Mã sinh viên
                    DataView dv = new DataView(dtLopHoc);
                    dv.RowFilter = string.Format("MaLopHoc = '{0}'", maGiangVienTimKiem);

                    // Kiểm tra nếu có kết quả tìm kiếm
                    if (dv.Count > 0)
                    {
                        dgvLopHoc.DataSource = dv; // Gán DataView đã lọc vào DataGridView
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
                DataGridViewRow row = dgvLopHoc.Rows[e.RowIndex];

                // Gán giá trị từ các ô của dòng vào các TextBox
                textBox2.Text = row.Cells["MaLopHoc"].Value.ToString();
                cbxThu.Text = row.Cells["Thu"].Value.ToString();
                cbxTietBatDau.Text = row.Cells["TietBatDau"].Value.ToString();
                cbxTietKetThuc.Text = row.Cells["TietKetThuc"].Value.ToString();
                cbxMaPhongHoc.Text = row.Cells["MaPhongHoc"].Value.ToString();
                cbxMaGiangVien.Text = row.Cells["MaGiangVien"].Value.ToString();
                cbxMaMonHoc.Text = row.Cells["MaMonHoc"].Value.ToString();

            }
        }

        private void FrmQLLopHoc_Load(object sender, EventArgs e)
        {
            try
            {
                ViewDAL viewDAL = new ViewDAL();
                cbxMaMonHoc.DataSource = viewDAL.GetViewMonHoc();
                cbxMaMonHoc.DisplayMember = "MaMonHoc";
                cbxMaMonHoc.ValueMember = "MaMonHoc";
                cbxMaMonHoc.SelectedIndex = 0;

                cbxMaGiangVien.DataSource = viewDAL.GetViewGiangVien();
                cbxMaGiangVien.DisplayMember = "MaGiangVien";
                cbxMaGiangVien.ValueMember = "MaGiangVien";
                cbxMaGiangVien.SelectedIndex = 0;

                cbxThu.SelectedIndex = 0;
                cbxTietBatDau.SelectedIndex = 0;
                cbxTietKetThuc.SelectedIndex = 0;

                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from PhongHoc", connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cbxMaPhongHoc.DataSource = dt;
                        cbxMaPhongHoc.DisplayMember = "MaPhongHoc";
                        cbxMaPhongHoc.ValueMember = "MaPhongHoc";
                        cbxMaPhongHoc.SelectedIndex = 0;
                    }
                }

                dgvLopHoc.DataSource = viewDAL.GetViewLopHoc();

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

        private void btnThemLopHoc_Click(object sender, EventArgs e)
        {
            try
            {
                int MaLopHoc = int.Parse(textBox2.Text); ;
                byte Thu = byte.Parse(cbxThu.Text);
                byte TietBatDau = byte.Parse(cbxTietBatDau.Text);
                byte TietKetThu = byte.Parse(cbxTietKetThuc.Text);
                int MaPhongHoc = int.Parse(cbxMaPhongHoc.Text);
                int MaGiangVien = int.Parse(cbxMaGiangVien.Text);
                int MaMonHoc = int.Parse(cbxMaMonHoc.Text);

                LopHocDAL lopHocDAL = new LopHocDAL();
                int kq = lopHocDAL.ThemLopHoc(MaLopHoc, Thu, TietBatDau, TietKetThu, MaPhongHoc, MaGiangVien, MaMonHoc);
                if (kq > 0)
                {
                    MessageBox.Show($"Thêm lớp học {MaLopHoc} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Thêm lớp học {MaLopHoc} thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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
                dgvLopHoc.DataSource = viewDAL.GetViewLopHoc();
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

        private void btnXoaLopHoc_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = int.Parse(textBox2.Text);

                LopHocDAL sinhVienDAL = new LopHocDAL();
                sinhVienDAL.XoaLopHoc(maSinhVien);
                MessageBox.Show($"Xoa lop hoc {maSinhVien} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSuaLopHoc_Click(object sender, EventArgs e)
        {
            try
            {
                int maLopHoc = int.Parse(textBox2.Text); ;
                byte thu = byte.Parse(cbxThu.Text);
                byte tietBatDau = byte.Parse(cbxTietBatDau.Text);
                byte tietKetThuc = byte.Parse(cbxTietKetThuc.Text);
                int maPhongHoc = int.Parse(cbxMaPhongHoc.Text);
                int maGiangVien = int.Parse(cbxMaGiangVien.Text);
                int maMonHoc = int.Parse(cbxMaMonHoc.Text);

                LopHocDAL lopHocDAL = new LopHocDAL();
                lopHocDAL.SuaLopHoc(maLopHoc, thu, tietBatDau, tietKetThuc, maPhongHoc, maGiangVien, maMonHoc);
                

                MessageBox.Show($"Sua lop hoc {maLopHoc} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnLopPhuTrach_Click(object sender, EventArgs e)
        {
            try
            {
                FrmXemGiangVienVaLopHoc frmXemGiangVienVaLop = new FrmXemGiangVienVaLopHoc();
                frmXemGiangVienVaLop.ShowDialog();
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

        private void btnXemLopTrong_Click(object sender, EventArgs e)
        {
            try
            {
                FrmLopHocTrong frmLopHocTrong = new FrmLopHocTrong();
                frmLopHocTrong.ShowDialog();
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

        private void btnDangKySVvaoLop_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDangKySinhVien dKSinhVien = new FrmDangKySinhVien();
                dKSinhVien.ShowDialog();
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

        private void btnXemBangDiemCuaLop_Click(object sender, EventArgs e)
        {
            try
            {
                FrmXemKetQuaHocTapTaiLop frmXemKetQuaHocTapTaiLop = new FrmXemKetQuaHocTapTaiLop();
                frmXemKetQuaHocTapTaiLop.ShowDialog();
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
