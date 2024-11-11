using QLDiemSVKhoaCNNT.DBConnection;
using QLDiemSVKhoaCNNT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSVKhoaCNNT.DAL
{
    internal class LopHocDAL
    {
        /// <summary>
        /// Thêm một lớp học mới vào cơ sở dữ liệu thông qua stored procedure "proc_ThemLopHoc".
        /// </summary>
        /// <param name="maLopHoc">
        /// Mã lớp học của lớp học cần thêm.
        /// </param>
        /// <param name="thu">
        /// Ngày trong tuần của lớp học cần thêm (1-7).
        /// </param>
        /// <param name="tietBatDau">
        /// Tiết bắt đầu của lớp học cần thêm.
        /// </param>
        /// <param name="tietKetThuc">
        /// Tiết kết thúc của lớp học cần thêm.
        /// </param>
        /// <param name="maPhongHoc">
        /// Mã phòng học của lớp học cần thêm.
        /// </param>
        /// <param name="maGiangVien">
        /// Mã giảng viên phụ trách lớp học cần thêm.
        /// </param>
        /// <param name="maMonHoc">
        /// Mã môn học của lớp học cần thêm.
        /// </param>
        /// <returns>
        /// Trả về số dòng bị ảnh hưởng sau khi thực thi stored procedure.
        /// <br>- Nếu trả về giá trị > 0, nghĩa là thêm lớp học thành công.</br>
        /// <br>- Nếu trả về 0, nghĩa là không có bản ghi nào được thêm.</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc thực thi câu lệnh SQL.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi không xác định khác.
        /// </exception>
        public int ThemLopHoc(int maLopHoc, byte thu, byte tietBatDau, byte tietKetThuc, int maPhongHoc, int maGiangVien, int maMonHoc)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_ThemLopHoc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLopHoc", maLopHoc);
                        command.Parameters.AddWithValue("@Thu", thu);
                        command.Parameters.AddWithValue("@TietBatDau", tietBatDau);
                        command.Parameters.AddWithValue("@TietKetThuc", tietKetThuc);
                        command.Parameters.AddWithValue("@MaPhongHoc", maPhongHoc);
                        command.Parameters.AddWithValue("@MaGiangVien", maGiangVien);
                        command.Parameters.AddWithValue("@MaMonHoc", maMonHoc);
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                throw; // Ném lại ngoại lệ SqlException nếu có lỗi xảy ra
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}"); // Ném lại ngoại lệ khác
            }
        }

        /// <summary>
        /// Xóa một lớp học khỏi cơ sở dữ liệu thông qua stored procedure "proc_XoaLopHoc".
        /// </summary>
        /// <param name="maLopHoc">
        /// Mã lớp học của lớp học cần xóa.
        /// </param>
        /// <returns>
        /// Trả về số dòng bị ảnh hưởng sau khi thực thi stored procedure.
        /// <br>- Nếu trả về giá trị > 0, nghĩa là xóa lớp học thành công.</br>
        /// <br>- Nếu trả về 0, nghĩa là không có bản ghi nào được xóa.</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc thực thi câu lệnh SQL.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi không xác định khác.
        /// </exception>
        public int XoaLopHoc(int maLopHoc)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_XoaLopHoc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLopHoc", maLopHoc);
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                throw; // Ném lại ngoại lệ SqlException nếu có lỗi xảy ra
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}"); // Ném lại ngoại lệ khác
            }
        }

        /// <summary>
        /// Sửa thông tin của một lớp học trong cơ sở dữ liệu thông qua stored procedure "proc_SuaLopHoc".
        /// </summary>
        /// <param name="maLopHoc">
        /// Mã lớp học của lớp học cần sửa.
        /// </param>
        /// <param name="thu">
        /// Ngày trong tuần của lớp học cần sửa (1-7).
        /// </param>
        /// <param name="tietBatDau">
        /// Tiết bắt đầu của lớp học cần sửa.
        /// </param>
        /// <param name="tietKetThuc">
        /// Tiết kết thúc của lớp học cần sửa.
        /// </param>
        /// <param name="maPhongHoc">
        /// Mã phòng học của lớp học cần sửa.
        /// </param>
        /// <param name="maGiangVien">
        /// Mã giảng viên phụ trách lớp học cần sửa.
        /// </param>
        /// <param name="maMonHoc">
        /// Mã môn học của lớp học cần sửa.
        /// </param>
        /// <returns>
        /// Trả về số dòng bị ảnh hưởng sau khi thực thi stored procedure.
        /// <br>- Nếu trả về giá trị > 0, nghĩa là sửa lớp học thành công.</br>
        /// <br>- Nếu trả về 0, nghĩa là không có bản ghi nào được sửa.</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc thực thi câu lệnh SQL.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi không xác định khác.
        /// </exception>
        public int SuaLopHoc(int maLopHoc, byte thu, byte tietBatDau, byte tietKetThuc, int maPhongHoc, int maGiangVien, int maMonHoc)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_SuaLopHoc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaLopHoc", maLopHoc);
                        command.Parameters.AddWithValue("@Thu", thu);
                        command.Parameters.AddWithValue("@TietBatDau", tietBatDau);
                        command.Parameters.AddWithValue("@TietKetThuc", tietKetThuc);
                        command.Parameters.AddWithValue("@MaPhongHoc", maPhongHoc);
                        command.Parameters.AddWithValue("@MaGiangVien", maGiangVien);
                        command.Parameters.AddWithValue("@MaMonHoc", maMonHoc);
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                throw; // Ném lại ngoại lệ SqlException nếu có lỗi xảy ra
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}"); // Ném lại ngoại lệ khác
            }
        }
        
    }
}
