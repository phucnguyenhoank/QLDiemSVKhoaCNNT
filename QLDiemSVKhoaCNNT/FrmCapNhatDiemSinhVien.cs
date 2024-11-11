using QLDiemSVKhoaCNNT.DAL;
using QLDiemSVKhoaCNNT.DTO;
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
    public partial class FrmCapNhatDiemSinhVien : Form
    {
        public FrmCapNhatDiemSinhVien()
        {
            InitializeComponent();

        }

        private void LoadLopHoc()
        {
            try
            {
                ViewDAL viewDAL = new ViewDAL();
                cbxMaLopHoc.DataSource = viewDAL.GetViewLopHoc();
                cbxMaLopHoc.DisplayMember = "MaLopHoc";
                cbxMaLopHoc.ValueMember = "MaLopHoc";
                cbxMaLopHoc.SelectedIndex = 0;
                FunctionDAL functionDAL = new FunctionDAL();
                dgvSinhVienCuaLop.DataSource = functionDAL.LayDanhSachSinhVienTrongLop(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load danh sách lớp học: {ex.Message}");
            }
        }

        private void cbxMaLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maLH;
            if (Int32.TryParse(cbxMaLopHoc.SelectedValue.ToString(), out maLH))
            {
                // Gọi phương thức lấy danh sách sinh viên trong lớp
                FunctionDAL functionDAL = new FunctionDAL();
                dgvSinhVienCuaLop.DataSource = functionDAL.LayDanhSachSinhVienTrongLop(maLH);
            }

        }

        private void dgvSinhVienCuaLop_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FrmCapNhatDiemSinhVien_Load(object sender, EventArgs e)
        {
            LoadLopHoc();
        }

        private void btnCapNhatDiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu có dòng nào được chọn
                if (dgvSinhVienCuaLop.CurrentRow != null)
                {
                    // Lấy mã sinh viên và mã lớp học từ DataGridView
                    int maSinhVien = Convert.ToInt32(dgvSinhVienCuaLop.CurrentRow.Cells["MaSinhVien"].Value);
                    int maLopHoc = Convert.ToInt32(cbxMaLopHoc.SelectedValue.ToString());

                    // Lấy giá trị điểm đã được chỉnh sửa
                    decimal diemQuaTrinh = Convert.ToDecimal(dgvSinhVienCuaLop.CurrentRow.Cells["DiemQuaTrinh"].Value);
                    decimal diemCuoiKy = Convert.ToDecimal(dgvSinhVienCuaLop.CurrentRow.Cells["DiemCuoiKy"].Value);

                    // Gọi hàm cập nhật điểm
                    ProcedureDAL procedureDAL = new ProcedureDAL();
                    int result = procedureDAL.CapNhatDiem(maSinhVien, maLopHoc, diemQuaTrinh, diemCuoiKy);

                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật điểm thành công!", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Không có thay đổi nào được cập nhật.", "Thông báo");
                    }

                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server btnCapNhatDiem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi khi cập nhật điểm btnCapNhatDiem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
