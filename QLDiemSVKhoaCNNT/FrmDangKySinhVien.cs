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
    public partial class FrmDangKySinhVien : Form
    {
        private void LoadDataToForm()
        {
            try
            {
                ViewDAL viewDAL = new ViewDAL();
                cbxLopHoc.DisplayMember = "MaLopHoc";
                cbxLopHoc.ValueMember = "MaLopHoc";
                cbxLopHoc.DataSource = viewDAL.GetViewLopHoc();
                cbxLopHoc.SelectedIndex = 0;
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
        public FrmDangKySinhVien()
        {
            InitializeComponent();
            LoadDataToForm();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = Convert.ToInt32(dgvSinhVien.CurrentRow.Cells["MaSinhVien"].Value);

                int maLopHoc = Convert.ToInt32(cbxLopHoc.Text);

                ProcedureDAL lopHocDAL = new ProcedureDAL();
                bool ketQua = lopHocDAL.DangKySinhVienVaoLop(maSinhVien, maLopHoc);

                // Kiểm tra kết quả và thông báo cho người dùng
                if (ketQua)
                {
                    MessageBox.Show("Đã thêm sinh viên vào lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxMaLopHoc_SelectedIndexChanged(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm sinh viên vào lớp học thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi tổng quát và hiển thị thông báo
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxMaLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxLopHoc.SelectedValue != null)
                {
                    FunctionDAL functionDAL = new FunctionDAL();
                    int maLopHoc = Convert.ToInt32(cbxLopHoc.SelectedValue);
                    dgvSinhVienDangKy.DataSource = functionDAL.LayDanhSachSinhVienTrongLop(maLopHoc);
                    lblSoLuongSinhVien.Text = "Số lượng sinh viên: " + functionDAL.DemSoLuongSinhVienCuaLop(Convert.ToInt32(cbxLopHoc.SelectedValue));
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server tại cbxMaLopHoc_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi tại cbxMaLopHoc_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
