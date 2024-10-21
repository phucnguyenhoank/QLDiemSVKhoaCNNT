using QLDiemSVKhoaCNNT.DAL;
using QLDiemSVKhoaCNNT.DBConnection;
using QLDiemSVKhoaCNNT.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace QLDiemSVKhoaCNNT
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                ViewDAL viewDAL = new ViewDAL();
                DataTable dt = viewDAL.GetDanhSachDiemTongKetTheoHocKy();
                dgvReadData.DataSource = dt;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server btnGet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi btnGet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (QLDSVCNTTConnection.TestConnection() == 0)
                {
                    MessageBox.Show("HURRAYY");
                }
                else
                {
                    MessageBox.Show("SAD");
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server btnGet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi btnGet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemGV_Click(object sender, EventArgs e)
        {
            try
            {
                int maGiangVien = 7;
                string hoVaTen = "Lê Minh Tân";
                string email = "tanlm@hcmute.edu.vn";
                string soDienThoai = "0987654327";
                ProcedureDAL procedureDAL = new ProcedureDAL();
                procedureDAL.ThemGiangVien(maGiangVien, hoVaTen, email, soDienThoai);
                MessageBox.Show($"Them giang vien {maGiangVien} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server btnGet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi btnGet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaMonHoc_Click(object sender, EventArgs e)
        {
            try
            {
                int maMonHoc = 22111;

                ProcedureDAL procedureDAL = new ProcedureDAL();
                procedureDAL.XoaMonHoc(maMonHoc);
                MessageBox.Show($"Xoa mon hoc {maMonHoc} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server btnGet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi btnGet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDKSinhVienVaoLop_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = 22110427;
                int maLopHoc = 2;
                ProcedureDAL procedureDAL = new ProcedureDAL();
                procedureDAL.DangKySinhVienVaoLop(maSinhVien, maLopHoc);
                MessageBox.Show($"Dang ky lop {maLopHoc} cho sinh vien {maSinhVien} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server btnGet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi btnGet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
