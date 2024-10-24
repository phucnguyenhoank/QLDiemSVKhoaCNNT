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
    public partial class FrmMotSinhVienCoQuaMon : Form
    {
        public FrmMotSinhVienCoQuaMon()
        {
            InitializeComponent();
        }

        private void btnKiemTraQuaMon_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = int.Parse(txtMaSinhVien.Text);
                int maMonHoc = int.Parse(txtMaMonHoc.Text);
                FunctionDAL functionDAL = new FunctionDAL();
                byte quaMon = functionDAL.KiemTraQuaMon(maSinhVien, maMonHoc);
                if (quaMon == 1)
                {
                    MessageBox.Show($"Sinh viên {maSinhVien} đã QUA môn {maMonHoc}", "Kết quả kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (quaMon == 0)
                {
                    MessageBox.Show($"Sinh viên {maSinhVien} đã RỚT môn {maMonHoc}", "Kết quả kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (quaMon == 2)
                {
                    MessageBox.Show($"Sinh viên {maSinhVien} CHƯA ĐƯỢC NHẬP ĐIỂM cho môn {maMonHoc}", "Kết quả kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (quaMon == 3)
                {
                    MessageBox.Show($"Sinh viên {maSinhVien} KHÔNG TỒN TẠI", "Kết quả kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (quaMon == 4)
                {
                    MessageBox.Show($"Sinh viên {maSinhVien} CHƯA ĐĂNG KÝ môn {maMonHoc}", "Kết quả kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Lỗi chưa xác định", "Kết quả kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server btnKiemTraQuaMon_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi btnKiemTraQuaMon_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
