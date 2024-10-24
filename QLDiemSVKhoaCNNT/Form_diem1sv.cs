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
    public partial class Form_diem1sv : Form
    {
        public Form_diem1sv()
        {
            InitializeComponent();
        }

        private void Form_diem1sv_Load(object sender, EventArgs e)
        {
            

        }

        private void buttonshow_Click(object sender, EventArgs e)
        {
            int mssv = Convert.ToInt32(textBoxmssv.Text);
            FunctionDAL functionDAL = new FunctionDAL();
            dgvdanhsachdiemsv.DataSource = functionDAL.LayBangDiemSinhVien(mssv);
            dgvdanhsachdiemsv.Columns[0].HeaderText = "Mã môn học";
            dgvdanhsachdiemsv.Columns[1].HeaderText = "Tên môn học";
            dgvdanhsachdiemsv.Columns[2].HeaderText = "Điểm quá trình";
            dgvdanhsachdiemsv.Columns[3].HeaderText = "Điểm cuối kỳ";
            dgvdanhsachdiemsv.Columns[4].HeaderText = "Điểm trung bình";
            dgvdanhsachdiemsv.Columns[5].HeaderText = "Xếp loại";
            label1.Text ="Điểm Trung Bình: " + Convert.ToString( functionDAL.LayDiemTrungBinhSinhVien( mssv ));

            label2.Text = "Điểm Trung Bình Tích Lũy: " + Convert.ToString(functionDAL.TinhDiemTrungBinhTichLuy(mssv));
            label3.Text = "Số Tín Chỉ Hoàn Thành: " + Convert.ToString(functionDAL.SoTinChiHoanThanh(mssv));
        }
    }
}
