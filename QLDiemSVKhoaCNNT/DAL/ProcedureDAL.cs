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
    internal class ProcedureDAL
    {
        /// <summary>
        /// Gọi thủ tục proc_XepLoaiDiemSinhVienCuaLop để lấy danh sách sinh viên trong một lớp học
        /// và xếp loại học lực dựa trên điểm trung bình môn.
        /// </summary>
        /// <param name="maLopHoc">Mã lớp học cần xem danh sách sinh viên</param>
        /// <returns>
        /// Danh sách các sinh viên bao gồm:
        /// <br>- MaSinhVien: Mã sinh viên.</br>
        /// <br>- HoVaTen: Họ và tên sinh viên.</br>
        /// <br>- DiemQuaTrinh: Điểm quá trình.</br>
        /// <br>- DiemCuoiKy: Điểm cuối kỳ.</br>
        /// <br>- DiemTrungBinhMon: Điểm trung bình môn (trung bình cộng của điểm quá trình và điểm cuối kỳ).</br>
        /// <br>- XepLoai: Xếp loại học lực (Giỏi, Khá, Trung Bình, Yếu, hoặc Chưa biết nếu thiếu điểm).</br>
        /// <br>- TrangThaiQuaMon: Trạng thái qua môn (QUA, RỚT hoặc Chưa biết nếu thiếu điểm).</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public DataTable XepLoaiDiemSinhVienCuaLop(int maLopHoc)
        {
            try
            {
                DataTable ketQuaXepLoaiDiem = new DataTable();
                String connectionString = QLDSVCNTTConnection.connectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_XepLoaiDiemSinhVienCuaLop", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLopHoc", maLopHoc);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            ketQuaXepLoaiDiem.Load(reader);
                            return ketQuaXepLoaiDiem;
                        }
                    }
                }
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
        /// Thêm một giảng viên mới vào cơ sở dữ liệu.
        /// </summary>
        /// <param name="maGiangVien">Mã giảng viên cần thêm.</param>
        /// <param name="hoVaTen">Họ và tên của giảng viên.</param>
        /// <param name="email">Email của giảng viên.</param>
        /// <param name="soDienThoai">Số điện thoại của giảng viên.</param>
        /// <returns>Trả về số lượng bản ghi bị ảnh hưởng (thông thường là 1 nếu thành công).</returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public int ThemGiangVien(int maGiangVien, string hoVaTen, string email, string soDienThoai)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_ThemGiangVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào Stored Procedure
                        command.Parameters.AddWithValue("@MaGiangVien", maGiangVien);
                        command.Parameters.AddWithValue("@HoVaTen", hoVaTen);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                        // Thực thi lệnh và trả về số dòng bị ảnh hưởng
                        return command.ExecuteNonQuery();
                    }
                }
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
        /// Xóa môn học khỏi cơ sở dữ liệu theo mã môn học.
        /// </summary>
        /// <param name="maMonHoc">Mã môn học cần xóa.</param>
        /// <returns>Trả về số lượng bản ghi bị ảnh hưởng (0 hoặc 1).</returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public int XoaMonHoc(int maMonHoc)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_XoaMonHoc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số mã môn học vào Stored Procedure
                        command.Parameters.AddWithValue("@MaMonHoc", maMonHoc);

                        // Thực thi lệnh và trả về số dòng bị ảnh hưởng
                        return command.ExecuteNonQuery();
                    }
                }
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
        /// Đăng ký sinh viên vào lớp học bằng cách gọi thủ tục proc_DangKySinhVienVaoLop.
        /// </summary>
        /// <param name="maSinhVien">Mã sinh viên cần đăng ký.</param>
        /// <param name="maLopHoc">Mã lớp học mà sinh viên muốn đăng ký.</param>
        /// <returns>
        /// Trả về true nếu đăng ký thành công, false nếu đã đăng ký hoặc xảy ra lỗi.
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public bool DangKySinhVienVaoLop(int maSinhVien, int maLopHoc)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_DangKySinhVienVaoLop", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số vào thủ tục
                        command.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
                        command.Parameters.AddWithValue("@MaLopHoc", maLopHoc);

                        // Thực thi lệnh
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
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
