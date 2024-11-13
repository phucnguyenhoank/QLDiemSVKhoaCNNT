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
    public partial class FrmGiangVienDayLopNhieuDKNhat : Form
    {
        public FrmGiangVienDayLopNhieuDKNhat()
        {
            InitializeComponent();
        }

        private void FrmGiangVienDayLopNhieuDKNhat_Load(object sender, EventArgs e)
        {
            try
            {
                ProcedureDAL procedureDAL = new ProcedureDAL();
                dgvGVDayLopNhieuDKNhat.DataSource = procedureDAL.GetGiangVienDayMonHocVoiSoSVDangKyCaoNhat();
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
