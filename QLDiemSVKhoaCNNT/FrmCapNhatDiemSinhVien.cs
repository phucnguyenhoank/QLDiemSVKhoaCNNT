using QLDiemSVKhoaCNNT.DAL;
using QLDiemSVKhoaCNNT.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            LoadLopHoc();
        }

        private void LoadLopHoc()
        {
            try
            {
                LopHocDAL lopHocDAL = new LopHocDAL();
                List<LopHoc> lopHocList = lopHocDAL.GetLopHoc();
                cbxMaLopHoc.DataSource = lopHocList;
                cbxMaLopHoc.DisplayMember = "MaLopHoc";
                cbxMaLopHoc.ValueMember = "MaLopHoc";
                cbxMaLopHoc.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load danh sách lớp học: {ex.Message}");
            }
        }

        private void cbxMaLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LopHoc selectedLopHoc = cbxMaLopHoc.SelectedItem as LopHoc;
            if (selectedLopHoc != null)
            {
                int maLopHoc = selectedLopHoc.MaLopHoc;

                // Gọi phương thức lấy danh sách sinh viên trong lớp
                FunctionDAL functionDAL = new FunctionDAL();
                dgvSinhVienCuaLop.DataSource = functionDAL.LayDanhSachSinhVienTrongLop(maLopHoc);
            }

        }

        private void dgvSinhVienCuaLop_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Chỉ xử lý khi cột DiemQuaTrinh hoặc DiemCuoiKy thay đổi
            if (e.ColumnIndex == dgvSinhVienCuaLop.Columns["DiemQuaTrinh"].Index ||
                e.ColumnIndex == dgvSinhVienCuaLop.Columns["DiemCuoiKy"].Index)
            {
                // Lấy mã sinh viên và mã lớp học từ DataGridView
                int maSinhVien = (int)dgvSinhVienCuaLop.Rows[e.RowIndex].Cells["MaSinhVien"].Value;
                int maLopHoc = int.Parse(cbxMaLopHoc.SelectedValue.ToString());

                // Lấy giá trị điểm đã được chỉnh sửa
                decimal diemQuaTrinh = Convert.ToDecimal(dgvSinhVienCuaLop.Rows[e.RowIndex].Cells["DiemQuaTrinh"].Value);
                decimal diemCuoiKy = Convert.ToDecimal(dgvSinhVienCuaLop.Rows[e.RowIndex].Cells["DiemCuoiKy"].Value);

                try
                {
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
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật điểm: {ex.Message}", "Lỗi");
                }
            }
        }

        private void FrmCapNhatDiemSinhVien_Load(object sender, EventArgs e)
        {

        }
    }
}
