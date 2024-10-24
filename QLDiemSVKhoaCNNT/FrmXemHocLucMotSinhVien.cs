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
    public partial class FrmXemHocLucMotSinhVien : Form
    {
        public FrmXemHocLucMotSinhVien()
        {
            InitializeComponent();
        }

        private void btnXemHocLuc_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = int.Parse(txtMaSinhVien.Text);
                FunctionDAL functionDAL = new FunctionDAL();
                lblHocLucSinhVien.Text = functionDAL.XemHocLucSinhVien(maSinhVien);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server btnXemHocLuc_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi btnXemHocLuc_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
