using QLDiemSVKhoaCNNT.DAL;
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
    public partial class FrmXemThoiKhoaBieu : Form
    {
        public FrmXemThoiKhoaBieu()
        {
            InitializeComponent();
        }

        private void cbxMaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maSV;
            if (Int32.TryParse(cbxMaSV.SelectedValue.ToString(), out maSV))
            {
                // Gọi phương thức lấy danh sách sinh viên trong lớp
                ProcedureDAL procedureDAL = new ProcedureDAL();
                dgvTKBCuaSV.DataSource = procedureDAL.XemThoiKhoaBieu1SV(maSV);
                dgvTKBCuaSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void FrmXemThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            ViewDAL viewDAL = new ViewDAL();
            cbxMaSV.DataSource = viewDAL.GetViewSinhVien();
            cbxMaSV.DisplayMember = "MaSinhVien";
            cbxMaSV.ValueMember = "MaSinhVien";

        }
    }
}
