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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLDiemSVKhoaCNNT
{
    public partial class FrmQLLopHoc : Form
    {
        public FrmQLLopHoc()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maGiangVienTimKiem = textBox1.Text.Trim(); // Lấy mã sinh viên từ TextBox

            if (!string.IsNullOrEmpty(maGiangVienTimKiem)) // Kiểm tra mã sinh viên không rỗng
            {
                try
                {
                    // Khởi tạo ViewDAL để lấy dữ liệu
                    LopHocDAL lopHocDAL = new LopHocDAL();

                    // Lấy danh sách sinh viên
                    DataTable dtLopHoc = lopHocDAL.GetViewLopHoc();

                    // Sử dụng DataView để lọc dữ liệu theo Mã sinh viên
                    DataView dv = new DataView(dtLopHoc);
                    dv.RowFilter = string.Format("MaLopHoc = '{0}'", maGiangVienTimKiem);

                    // Kiểm tra nếu có kết quả tìm kiếm
                    if (dv.Count > 0)
                    {
                        dataGridView1.DataSource = dv; // Gán DataView đã lọc vào DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Lop hoc với mã này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException sqlEx)
                {
                    // Bắt lỗi SQL Server nếu có
                    MessageBox.Show(sqlEx.Message, "Lỗi từ SQL Server btnTimKiem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Bắt lỗi tổng quát
                    MessageBox.Show(ex.Message, "Lỗi btnTimKiem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải dòng hợp lệ hay không (dòng tiêu đề không hợp lệ)
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán giá trị từ các ô của dòng vào các TextBox
                textBox2.Text = row.Cells["MaLopHoc"].Value.ToString();
                comboBox6.Text = row.Cells["Thu"].Value.ToString();
                comboBox1.Text = row.Cells["TietBatDau"].Value.ToString();
                comboBox2.Text = row.Cells["TietKetThuc"].Value.ToString();
                comboBox3.Text = row.Cells["MaPhongHoc"].Value.ToString();
                comboBox4.Text = row.Cells["MaGiangVien"].Value.ToString();
                comboBox5.Text = row.Cells["MaMonHoc"].Value.ToString();

            }
        }

        private void FrmQLLopHoc_Load(object sender, EventArgs e)
        {
            try
            {
                ViewDAL monHocDAL = new ViewDAL();
                comboBox5.DataSource = monHocDAL.GetViewMonHoc();
                comboBox5.DisplayMember = "MaMonHoc";
                comboBox5.ValueMember = "MaMonHoc";
                comboBox5.SelectedIndex = 0;
                ViewDAL giangVienDAl = new ViewDAL();
                comboBox4.DataSource = giangVienDAl.GetViewGiangVien();
                comboBox4.DisplayMember = "MaGiangVien";
                comboBox4.ValueMember = "MaGiangVien";
                comboBox4.SelectedIndex = 0;
                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from PhongHoc", connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        comboBox3.DataSource = dt;
                        comboBox3.DisplayMember = "MaPhongHoc";
                        comboBox3.ValueMember = "MaPhongHoc";
                    }
                }

            }
            catch (SqlException sqlEx)
            {

                MessageBox.Show(sqlEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                LopHocDAL viewDAL = new LopHocDAL();
                dataGridView1.DataSource = viewDAL.GetViewLopHoc();
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
                int MaLopHoc = int.Parse(textBox2.Text); ;
                byte Thu = byte.Parse(comboBox6.Text);
                byte TietBatDau = byte.Parse(comboBox1.Text);
                byte TietKetThu = byte.Parse(comboBox2.Text);
                int MaPhongHoc = int.Parse(comboBox3.Text);
                int MaGiangVien = int.Parse(comboBox4.Text);
                int MaMonHoc = int.Parse(comboBox5.Text);

                LopHocDAL lopHocDAL = new LopHocDAL();
                lopHocDAL.ThemLopHoc(MaLopHoc, Thu, TietBatDau, TietKetThu, MaPhongHoc, MaGiangVien, MaMonHoc);

                MessageBox.Show($"Them lop hoc {MaLopHoc} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo lại lớp ViewDAL để lấy dữ liệu mới
                LopHocDAL viewDAL = new LopHocDAL();

                // Nạp lại dữ liệu vào DataGridView
                dataGridView1.DataSource = viewDAL.GetViewLopHoc();
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int maSinhVien = int.Parse(textBox2.Text);

                LopHocDAL sinhVienDAL = new LopHocDAL();
                sinhVienDAL.XoaLopHoc(maSinhVien);
                MessageBox.Show($"Xoa lop hoc {maSinhVien} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int MaLopHoc = int.Parse(textBox2.Text); ;
                byte Thu = byte.Parse(comboBox6.Text);
                byte TietBatDau = byte.Parse(comboBox1.Text);
                byte TietKetThu = byte.Parse(comboBox2.Text);
                int MaPhongHoc = int.Parse(comboBox3.Text);
                int MaGiangVien = int.Parse(comboBox4.Text);
                int MaMonHoc = int.Parse(comboBox5.Text);

                LopHocDAL lopHocDAL = new LopHocDAL();
                lopHocDAL.CapNhatGiangVienVaoLop(MaGiangVien, MaLopHoc);

                MessageBox.Show($"Sua lop hoc {MaLopHoc} thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnLopPhuTrach_Click(object sender, EventArgs e)
        {
            try
            {
                FrmXemGiangVienVaLopHoc frmXemGiangVienVaLop = new FrmXemGiangVienVaLopHoc();
                frmXemGiangVienVaLop.ShowDialog();
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

        private void btnXemLopTrong_Click(object sender, EventArgs e)
        {
            try
            {
                FrmLopHocTrong frmLopHocTrong = new FrmLopHocTrong();
                frmLopHocTrong.ShowDialog();
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

        private void btnDangKySVvaoLop_Click(object sender, EventArgs e)
        {
            try
            {
                DKSinhVien dKSinhVien = new DKSinhVien();
                dKSinhVien.ShowDialog();
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

        private void btnXemBangDiemCuaLop_Click(object sender, EventArgs e)
        {
            try
            {
                FrmXemKetQuaHocTapTaiLop frmXemKetQuaHocTapTaiLop = new FrmXemKetQuaHocTapTaiLop();
                frmXemKetQuaHocTapTaiLop.ShowDialog();
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
