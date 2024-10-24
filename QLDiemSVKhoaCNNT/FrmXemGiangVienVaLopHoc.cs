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
    public partial class FrmXemGiangVienVaLopHoc : Form
    {
        public FrmXemGiangVienVaLopHoc()
        {
            InitializeComponent();
        }

        private void FrmXemGiangVienVaLopHoc_Load(object sender, EventArgs e)
        {
            using (SqlConnection connectcion = new SqlConnection(QLDSVCNTTConnection.connectionString))
            {
                try
                {
                    string query = "select * from GiangVien";
                    using (SqlCommand command = new SqlCommand(query, connectcion))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        cbx_giangvien.DataSource = table;
                        cbx_giangvien.DisplayMember = "HoVaTen";
                        cbx_giangvien.ValueMember = "MaGiangVien";
                        ViewDAL viewDAL = new ViewDAL();
                        dgvLopHocDcPhuTrach.DataSource = viewDAL.GetViewLopHocGiangVienPhuTrach();
                        dgvLopHocDcPhuTrach.AllowUserToAddRows = false;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cbx_giangvien_SelectedValueChanged(object sender, EventArgs e)
        {
            int maGV;
            if (Int32.TryParse(cbx_giangvien.SelectedValue.ToString(), out maGV))
            {
                FunctionDAL functionDAL = new FunctionDAL();
                label2.Text = "Số lượng lớp giảng viên này phụ trách: " + functionDAL.DemSoLopGiangVienPhuTrach(maGV);
            }
        }

        private void dgvLopHocDcPhuTrach_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu có hàng được chọn
                if (dgvLopHocDcPhuTrach.CurrentRow != null)
                {
                    // Lấy giá trị từ ô đầu tiên của dòng hiện tại và chuyển đổi sang int
                    int maLH = Convert.ToInt32(dgvLopHocDcPhuTrach.CurrentRow.Cells[0].Value);
                    FrmSinhVienTrongLopHoc frmSinhVienTrongLopHoc = new FrmSinhVienTrongLopHoc(maLH);

                    frmSinhVienTrongLopHoc.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không có hàng nào được chọn.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
