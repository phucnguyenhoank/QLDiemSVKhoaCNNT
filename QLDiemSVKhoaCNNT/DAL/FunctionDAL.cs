using QLDiemSVKhoaCNNT.DBConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSVKhoaCNNT.DAL
{
    internal class FunctionDAL
    {
        /// <summary>
        /// Kiểm tra tình trạng qua môn học của sinh viên dựa trên mã sinh viên và mã môn học.
        /// </summary>
        /// <param name="maSinhVien">Mã sinh viên cần kiểm tra.</param>
        /// <param name="maMonHoc">Mã môn học của sinh viên cần kiểm tra.</param>
        /// <returns>Trả về tình trạng qua môn dưới dạng byte: 1 (QUA), 0 (RỚT), 2 (Chưa nhập đủ điểm), 3 (Sinh viên không tồn tại), hoặc 4 (Sinh viên chưa đăng ký môn học).</returns>
        public byte KiemTraQuaMon(int maSinhVien, int maMonHoc)
        {
            try
            {
                byte ketQua; // Biến để lưu kết quả trả về từ hàm SQL
                string connectionString = QLDSVCNTTConnection.connectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT dbo.fn_KiemTraQuaMon(@MaSinhVien, @MaMonHoc)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
                        command.Parameters.AddWithValue("@MaMonHoc", maMonHoc);

                        ketQua = (byte)command.ExecuteScalar();
                    }
                }

                return ketQua;
            }
            catch (SqlException sqlEx)
            {
                throw new Exception($"SQL Error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
        /// <summary>
        /// Trả về số lượng sinh viên của một lớp học.
        /// </summary>
        /// <param name="maLopHoc">Mã lớp học của lớp cần được đếm sinh viên.</param>
        /// <returns>Sô lượng sinh viên của lớp cần đếm.</returns>
        public int DemSoLuongSinhVienCuaLop(int maLopHoc)
        {
            try
            {
                int soLuongSinhVien = 0;
                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT dbo.fn_DemSoLuongSinhVienCuaLop(@MaLopHoc)", connection))
                    {
                        cmd.Parameters.AddWithValue("@MaLopHoc", maLopHoc);
                        soLuongSinhVien = (int)cmd.ExecuteScalar();
                    }
                }
                return soLuongSinhVien;
            }
            catch (SqlException sqlEx)
            {
                throw new Exception($"SQL Error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Đếm số lớp một giảng viên đang phụ trách.
        /// </summary>
        /// <param name="maGiangVien">Mã giảng viên cần kiểm tra.</param>
        /// <returns>Sô lượng lớp mà giảng viên phụ trách.</returns>
        public int DemSoLopGiangVienPhuTrach(int maGiangVien)
        {
            try
            {
                int soLopGiangVienPhuTrach = 0;
                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT dbo.fn_DemSoLopGiangVienPhuTrach(@MaGiangVien)", connection))
                    {
                        cmd.Parameters.AddWithValue("@MaGiangVien", maGiangVien);
                        soLopGiangVienPhuTrach = (int)cmd.ExecuteScalar();
                    }
                }
                return soLopGiangVienPhuTrach;
            }
            catch (SqlException sqlEx)
            {
                throw new Exception($"SQL Error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }


        /// <summary>
        /// Lấy danh sách sinh viên trong lớp học có mã lớp học được chỉ định.
        /// </summary>
        /// <param name="maLopHoc">Mã lớp học cần lấy danh sách sinh viên.</param>
        /// <returns>
        /// Trả về một DataTable chứa danh sách sinh viên trong lớp, bao gồm các cột:
        /// <br>- MaSinhVien: Mã sinh viên.</br>
        /// <br>- HoVaTen: Họ và tên sinh viên.</br>
        /// <br>- Email: Địa chỉ email.</br>
        /// <br>- SoDienThoai: Số điện thoại.</br>
        /// <br>- QueQuan: Quê quán của sinh viên.</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public DataTable LayDanhSachSinhVienTrongLop(int maLopHoc)
        {
            try
            {
                DataTable danhSachSinhVien = new DataTable();

                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    string query = @"
                            SELECT 
                                sv.MaSinhVien, 
                                sv.HoVaTen, 
                                sv.Email, 
                                sv.SoDienThoai, 
                                sv.QueQuan 
                            FROM 
                                dbo.fn_LayDanhSachSinhVienTrongLop(@MaLopHoc) AS sv";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaLopHoc", maLopHoc);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(danhSachSinhVien);
                        }
                    }
                }

                return danhSachSinhVien;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy bảng điểm của sinh viên, bao gồm các môn học, điểm quá trình, điểm cuối kỳ, điểm trung bình môn và xếp loại.
        /// </summary>
        /// <param name="maSinhVien">Mã sinh viên cần lấy bảng điểm.</param>
        /// <returns>
        /// Trả về một DataTable chứa bảng điểm của sinh viên, bao gồm:
        /// <br>- MaMonHoc: Mã môn học.</br>
        /// <br>- TenMonHoc: Tên môn học.</br>
        /// <br>- DiemQuaTrinh: Điểm quá trình.</br>
        /// <br>- DiemCuoiKy: Điểm cuối kỳ.</br>
        /// <br>- DiemTrungBinh: Điểm trung bình môn.</br>
        /// <br>- XepLoaiMon: Xếp loại môn học.</br>
        /// <br>- DiemTrungBinhHocKy: Điểm trung bình học kỳ.</br>
        /// <br>- XepLoaiHocKy: Xếp loại học kỳ.</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public DataTable LayBangDiemSinhVien(int maSinhVien)
        {
            try
            {
                DataTable bangDiem = new DataTable();
                string connectionString = QLDSVCNTTConnection.connectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                    SELECT 
                        MaMonHoc, 
                        TenMonHoc, 
                        DiemQuaTrinh, 
                        DiemCuoiKy, 
                        DiemTrungBinh, 
                        XepLoaiMon, 
                        DiemTrungBinhHocKy, 
                        XepLoaiHocKy 
                    FROM dbo.fn_LayBangDiemSinhVien(@MaSinhVien)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaSinhVien", maSinhVien);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(bangDiem);
                        }
                    }
                }

                return bangDiem;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }


    }
}
