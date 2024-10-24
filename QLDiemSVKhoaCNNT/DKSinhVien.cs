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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLDiemSVKhoaCNNT
{
    public partial class DKSinhVien : Form
    {
        public DKSinhVien()
        {
            InitializeComponent();
        }

        private void DKSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                LopHocDAL lopHocDAL = new LopHocDAL();
                comboBox1.DataSource = lopHocDAL.GetViewLopHoc();
                comboBox1.DisplayMember = "MaLopHoc";
                comboBox1.ValueMember = "MaLopHoc";
                comboBox1.SelectedIndex = 0;
                
            }
            catch (SqlException sqlEx)
            {

                MessageBox.Show(sqlEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                ViewDAL viewDAL = new ViewDAL();
                dataGridView2.DataSource = viewDAL.GetViewSinhVien();

            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FunctionDAL lopHocDAL = new FunctionDAL();
                dataGridView1.DataSource = lopHocDAL.LayDanhSachSinhVienTrongLop(int.Parse(comboBox1.Text));
                label4.Text = "So luong SV: " + lopHocDAL.DemSoLuongSinhVienCuaLop(int.Parse(comboBox1.Text));
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy Mã Sinh Viên từ DataGridView2 (giả sử cột đầu tiên là MaSinhVien)
                int maSinhVien = Convert.ToInt32(dataGridView2.CurrentRow.Cells["MaSinhVien"].Value);

                // Lấy Mã Lớp Học từ ComboBox
                int maLopHoc = Convert.ToInt32(comboBox1.SelectedValue);

                // Gọi phương thức thêm sinh viên vào lớp học
                ProcedureDAL lopHocDAL = new ProcedureDAL();
                bool ketQua = lopHocDAL.DangKySinhVienVaoLop(maSinhVien, maLopHoc);

                // Kiểm tra kết quả và thông báo cho người dùng
                if (ketQua)
                {
                    MessageBox.Show("Đã thêm sinh viên vào lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm sinh viên vào lớp học thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi tổng quát và hiển thị thông báo
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                FunctionDAL lopHocDAL = new FunctionDAL();
                dataGridView1.DataSource = lopHocDAL.LayDanhSachSinhVienTrongLop(int.Parse(comboBox1.Text));

            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
