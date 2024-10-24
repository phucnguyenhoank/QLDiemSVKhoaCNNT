using QLDiemSVKhoaCNNT.DBConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSVKhoaCNNT.DAL
{
    internal class MonHocDAL
    {
        /// <summary>
        /// Thêm một môn học mới vào cơ sở dữ liệu thông qua stored procedure "proc_ThemMonHoc".
        /// </summary>
        /// <param name="maMonHoc">
        /// Mã môn học của môn học cần thêm.
        /// </param>
        /// <param name="tenMonHoc">
        /// Tên môn học của môn học cần thêm.
        /// </param>
        /// <param name="soTinChi">
        /// Số tín chỉ của môn học cần thêm.
        /// </param>
        /// <returns>
        /// Trả về số dòng bị ảnh hưởng sau khi thực thi stored procedure.
        /// <br>- Nếu trả về giá trị > 0, nghĩa là thêm môn học thành công.</br>
        /// <br>- Nếu trả về 0, nghĩa là không có bản ghi nào được thêm.</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc thực thi câu lệnh SQL.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi không xác định khác.
        /// </exception>
        public int ThemMonHoc(int maMonHoc, string tenMonHoc, byte soTinChi)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_ThemMonHoc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaMonHoc", maMonHoc);
                        command.Parameters.AddWithValue("@TenMonHoc", tenMonHoc);
                        command.Parameters.AddWithValue("@SoTinChi", soTinChi);
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
        /// Cập nhật thông tin môn học trong cơ sở dữ liệu.
        /// </summary>
        /// <param name="maMonHoc">Mã môn học cần cập nhật.</param>
        /// <param name="tenMonHoc">Tên mới của môn học.</param>
        /// <param name="soTinChi">Số tín chỉ mới của môn học.</param>
        /// <returns>Trả về số lượng bản ghi bị ảnh hưởng (0 hoặc 1).</returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public int SuaMonHoc(int maMonHoc, string tenMonHoc, byte soTinChi)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_SuaMonHoc", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaMonHoc", maMonHoc);
                        command.Parameters.AddWithValue("@TenMonHoc", tenMonHoc);
                        command.Parameters.AddWithValue("@SoTinChi", soTinChi);
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
