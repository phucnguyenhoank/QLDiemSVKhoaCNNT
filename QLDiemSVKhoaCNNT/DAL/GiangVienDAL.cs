using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDiemSVKhoaCNNT.DBConnection;

namespace QLDiemSVKhoaCNNT.DAL
{
    internal class GiangVienDAL
    {
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
        /// Xóa giảng viên khỏi cơ sở dữ liệu theo mã giảng viên.
        /// </summary>
        /// <param name="maGiangVien">Mã giảng viên cần xóa.</param>
        /// <returns>Trả về số lượng bản ghi bị ảnh hưởng (0 hoặc 1).</returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public int XoaGiangVien(int maGiangVien)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_XoaGiangVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaGiangVien", maGiangVien);
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
        /// Cập nhật thông tin giảng viên trong cơ sở dữ liệu.
        /// </summary>
        /// <param name="maGiangVien">Mã giảng viên cần cập nhật.</param>
        /// <param name="hoVaTen">Họ và tên mới của giảng viên.</param>
        /// <param name="email">Email mới của giảng viên.</param>
        /// <param name="soDienThoai">Số điện thoại mới của giảng viên.</param>
        /// <returns>Trả về số lượng bản ghi bị ảnh hưởng (0 hoặc 1).</returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public int SuaGiangVien(int maGiangVien, string hoVaTen, string email, string soDienThoai)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_SuaGiangVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
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


    }
}
