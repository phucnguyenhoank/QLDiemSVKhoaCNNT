using QLDiemSVKhoaCNNT.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSVKhoaCNNT
{
    public partial class FrmChuyenLop : Form
    {
        public FrmChuyenLop()
        {
            InitializeComponent();
        }

        private void FrmChuyenLop_Load(object sender, EventArgs e)
        {
            try
            {
                ViewDAL sinhVienDAl = new ViewDAL();
                cbxMaSV.DataSource = sinhVienDAl.GetViewSinhVien();
                cbxMaSV.DisplayMember = "MaSinhVien";
                cbxMaSV.ValueMember = "MaSinhVien";
                cbxMaSV.SelectedIndex = 0;
                ViewDAL lopHocDAL = new ViewDAL();
                cbxMaLopMoi.DataSource = lopHocDAL.GetViewLopHoc();
                cbxMaLopMoi.DisplayMember = "MaLopHoc";
                cbxMaLopMoi.ValueMember = "MaLopHoc";
                cbxMaLopMoi.SelectedIndex = 0;

                cbxMaLopCu.DataSource = lopHocDAL.GetViewLopHoc();
                cbxMaLopCu.DisplayMember = "MaLopHoc";
                cbxMaLopCu.ValueMember = "MaLopHoc";
                cbxMaLopCu.SelectedIndex = 0;

            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxMaSV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnChuyenLop_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = int.Parse(cbxMaSV.Text);
                int maLopHocCu = int.Parse(cbxMaLopCu.Text);
                int maLopHocMoi = int.Parse(cbxMaLopMoi.Text);

                TransactionDAL transactionDAL = new TransactionDAL();
                int res = transactionDAL.ChuyenSinhVienSangLopKhac(maSinhVien, maLopHocCu, maLopHocMoi);

                if (res > 0)
                {
                    MessageBox.Show("Chuyển thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
