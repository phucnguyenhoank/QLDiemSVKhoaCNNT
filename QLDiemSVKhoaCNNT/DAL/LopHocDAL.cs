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
        /// Lấy danh sách lớp học từ view vw_LopHoc.
        /// </summary>
        /// <returns>
        /// Một bảng chứa thông tin của toàn bộ lớp học gồm các cột:
        /// <br>- MaLopHoc</br>
        /// <br>- Thu</br>
        /// <br>- TietBatDau</br>
        /// <br>- TietKetThuc</br>
        /// <br>- MaPhongHoc</br>
        /// <br>- MaGiangVien</br>
        /// <br>- MaMonHoc</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public DataTable GetViewLopHoc()
        {
            try
            {
                DataTable danhSachLopHoc = new DataTable();

                // Thiết lập kết nối với cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open(); // Mở kết nối đến cơ sở dữ liệu

                    // Truy vấn để lấy dữ liệu từ view vw_LopHoc
                    string query = @"SELECT 
                                MaLopHoc, 
                                Thu, 
                                TietBatDau, 
                                TietKetThuc, 
                                MaPhongHoc, 
                                MaGiangVien, 
                                MaMonHoc 
                            FROM vw_LopHoc";

                    // Tạo đối tượng SqlCommand để thực thi truy vấn
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(danhSachLopHoc); // Điền dữ liệu vào DataTable
                        }
                    }
                }

                return danhSachLopHoc; // Trả về DataTable chứa danh sách lớp học
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
        public int CapNhatGiangVienVaoLop(int maGiangVien, int maLopHoc)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_CapNhatGiangVienVaoLop", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaGiangVien", maGiangVien);
                        command.Parameters.AddWithValue("@MaLopHoc", maLopHoc);

                        // Thực hiện thủ tục và trả về số lượng bản ghi bị ảnh hưởng
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
