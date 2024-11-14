using QLDiemSVKhoaCNNT.DAL;
using QLDiemSVKhoaCNNT.DBConnection;
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
    public partial class FrmBangXepHangDiem : Form
    {
        public FrmBangXepHangDiem()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Bang_xep_hang_theo_diem_Load(object sender, EventArgs e)
        {
            using (SqlConnection connectcion = new SqlConnection(QLDSVCNTTConnection.connectionString))
            {
                try
                {
                    ViewDAL viewDAL = new ViewDAL();
                    dataGridView1.DataSource = viewDAL.GetViewXepHangSinhVien();
                    dataGridView1.AllowUserToAddRows = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
