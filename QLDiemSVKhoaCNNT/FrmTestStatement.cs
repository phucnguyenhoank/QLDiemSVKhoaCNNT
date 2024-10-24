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
                ProcedureDAL procedureDAL = new ProcedureDAL();
                ViewDAL viewDAL = new ViewDAL();
                FunctionDAL functionDAL = new FunctionDAL();
                lblScalarReturnedValue.Text = functionDAL.XemHocLucSinhVien(22110400);
                DataTable dt = viewDAL.GetViewXepHangSinhVien();
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

        private void btnXoaSinhVien_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = 22110443;

                ProcedureDAL procedureDAL = new ProcedureDAL();
                procedureDAL.XoaSinhVien(maSinhVien);
                MessageBox.Show($"Xoa sinh vien {maSinhVien} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSuaGiangVien_Click(object sender, EventArgs e)
        {
            try
            {
                int maGiangVien = 7;

                ProcedureDAL procedureDAL = new ProcedureDAL();
                procedureDAL.SuaGiangVien(maGiangVien, "Lê Minh Tân", "tanlm@hcmute.edu.vnnn", "0999999999");
                MessageBox.Show($"Sua giang vien {maGiangVien} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnGiangVienToLop_Click(object sender, EventArgs e)
        {
            try
            {
                int maGiangVien = 7;
                int maLophoc = 2;
                ProcedureDAL procedureDAL = new ProcedureDAL();
                procedureDAL.CapNhatGiangVienVaoLop(maGiangVien, maLophoc);
                MessageBox.Show($"Phu trach giang vien {maGiangVien} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnThemMonHoc_Click(object sender, EventArgs e)
        {
            try
            {
                int maMonHoc = 1430011;
                string tenMonHoc = "DSTT";
                byte soTinChi = 3;
                ProcedureDAL procedureDAL = new ProcedureDAL();
                procedureDAL.ThemMonHoc(maMonHoc, tenMonHoc, soTinChi);
                MessageBox.Show($"Them mon hoc {maMonHoc} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSuaSinhVien_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = 22110400;

                ProcedureDAL procedureDAL = new ProcedureDAL();
                procedureDAL.SuaSinhVien(maSinhVien, "Sam Nguyễn", "aaa2gmail.com", "5544778", "Sơn hòa");
                MessageBox.Show($"Sua sinh vien {maSinhVien} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnCapNhatDiem_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = 22110400;

                ProcedureDAL procedureDAL = new ProcedureDAL();
                procedureDAL.CapNhatDiem(maSinhVien, 2211, 10.0M, 10.0M);
                MessageBox.Show($"Sua sinh vien {maSinhVien} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSoTCHoanThanh_Click(object sender, EventArgs e)
        {

        }
    }
}
