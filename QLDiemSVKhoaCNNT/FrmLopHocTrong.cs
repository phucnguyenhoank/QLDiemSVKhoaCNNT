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
    public partial class FrmLopHocTrong : Form
    {
        public FrmLopHocTrong()
        {
            InitializeComponent();
        }

        private void LoadDataGridView()
        {
            ViewDAL viewDAL = new ViewDAL();
            dgvLopHocConTrong.DataSource = viewDAL.GetDanhSachLopHocConTrong();

        }

        private void FrmLopHocTrong_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
    }
}
