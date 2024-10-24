using QLDiemSVKhoaCNNT.DTO;
using QLDiemSVKhoaCNNT.DBConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLDiemSVKhoaCNNT.DAL
{
    internal class SinhVienDAL
    {
        public int ThemSinhVien(int maSinhVien, string hoVaTen, string email, string soDienThoai, string queQuan)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_ThemSinhVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
                        command.Parameters.AddWithValue("@HoVaTen", hoVaTen);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                        command.Parameters.AddWithValue("@QueQuan", queQuan);

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
                // Handle other exceptions
                throw new Exception($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa sinh viên khỏi cơ sở dữ liệu theo mã sinh viên.
        /// </summary>
        /// <param name="maSinhVien">Mã sinh viên cần xóa.</param>
        /// <returns>Trả về số lượng bản ghi bị ảnh hưởng (0 hoặc 1).</returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public int XoaSinhVien(int maSinhVien)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_XoaSinhVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số mã sinh viên vào Stored Procedure
                        command.Parameters.AddWithValue("@MaSinhVien", maSinhVien);

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
        /// Cập nhật thông tin sinh viên trong cơ sở dữ liệu thông qua stored procedure "proc_SuaSinhVien".
        /// </summary>
        /// <param name="maSV">
        /// Mã sinh viên cần cập nhật.
        /// </param>
        /// <param name="hoten">
        /// Họ và tên mới của sinh viên.
        /// </param>
        /// <param name="email">
        /// Email mới của sinh viên.
        /// </param>
        /// <param name="sdt">
        /// Số điện thoại mới của sinh viên.
        /// </param>
        /// <param name="quequan">
        /// Quê quán mới của sinh viên.
        /// </param>
        /// <returns>
        /// Trả về số dòng bị ảnh hưởng sau khi thực thi stored procedure.
        /// <br>- Nếu trả về giá trị > 0, nghĩa là cập nhật sinh viên thành công.</br>
        /// <br>- Nếu trả về 0, nghĩa là không có bản ghi nào được cập nhật.</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc thực thi câu lệnh SQL.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi không xác định khác.
        /// </exception>
        public int SuaSinhVien(int maSV, string hoten, string email, string sdt, string quequan)
        {
            try
            {
            
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_SuaSinhVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@MaSinhVien", maSV));
                        command.Parameters.Add(new SqlParameter("@HoVaTen", hoten));
                        command.Parameters.Add(new SqlParameter("@Email", email));
                        command.Parameters.Add(new SqlParameter("@SoDienThoai", sdt));
                        command.Parameters.Add(new SqlParameter("@QueQuan", quequan));
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
