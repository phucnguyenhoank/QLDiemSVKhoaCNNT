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
    public partial class FrmXemKetQuaHocTapTaiLop : Form
    {
        public FrmXemKetQuaHocTapTaiLop()
        {
            InitializeComponent();
            LoadLopHoc();
        }

        private void LoadLopHoc()
        {
            try
            {
                LopHocDAL lopHocDAL = new LopHocDAL();
                cbxMaLopHoc.DataSource = lopHocDAL.GetViewLopHoc();
                cbxMaLopHoc.DisplayMember = "MaLopHoc";
                cbxMaLopHoc.ValueMember = "MaLopHoc";
                cbxMaLopHoc.SelectedIndex = 0;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server LoadLopHoc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi LoadLopHoc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmXemKetQuaHocTapTaiLop_Load(object sender, EventArgs e)
        {

        }

        private void cbxMaLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LopHoc selectedLopHoc = cbxMaLopHoc.SelectedItem as LopHoc;
            if (selectedLopHoc != null)
            {
                int maLopHoc = selectedLopHoc.MaLopHoc;

                // Gọi phương thức lấy danh sách sinh viên trong lớp
                ProcedureDAL procedureDAL = new ProcedureDAL();
                dgvDiemSinhVienCuaLop.DataSource = procedureDAL.XemKetQuaHocTapCuaLop(maLopHoc);
            }
        }
    }
}
