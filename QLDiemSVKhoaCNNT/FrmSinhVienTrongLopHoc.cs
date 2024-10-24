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
    public partial class FrmSinhVienTrongLopHoc : Form
    {
        int maLH;
        public FrmSinhVienTrongLopHoc(int maLH)
        {
            InitializeComponent();
            this.maLH = maLH;
        }

        private void FrmSinhVienTrongLopHoc_Load(object sender, EventArgs e)
        {
            FunctionDAL functionDAL = new FunctionDAL();
            lblSoLuongSV.Text = "Số lượng sinh viên: " + functionDAL.DemSoLuongSinhVienCuaLop(maLH);
            lblPhanTramQuaMon.Text = "Phần trăm qua môn của lớp: " + functionDAL.TinhPhanTramQuaMon(maLH) + "%";
            dgvDanhSachSV.DataSource = functionDAL.LayDanhSachSinhVienTrongLop(maLH);
            dgvDanhSachSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
