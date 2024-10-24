using QLDiemSVKhoaCNNT.DBConnection;
using QLDiemSVKhoaCNNT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLDiemSVKhoaCNNT.DAL
{
    internal class ProcedureDAL
    {
        /// <summary>
        /// Gọi thủ tục proc_XemKetQuaHocTapCuaLop để lấy danh sách kết quả học tập môn học được dạy tại lớp học, 
        /// kết quả này là bảng điểm của sinh viên với môn học được dạy. 
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
        public DataTable XemKetQuaHocTapCuaLop(int maLopHoc)
        {
            try
            {
                DataTable ketQuaXepLoaiDiem = new DataTable();
                String connectionString = QLDSVCNTTConnection.connectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_XemKetQuaHocTapCuaLop", connection))
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
        /// <summary>
        /// Cập nhật giảng viên vào lớp học trong cơ sở dữ liệu.
        /// </summary>
        /// <param name="maGiangVien">Mã giảng viên cần cập nhật vào lớp học.</param>
        /// <param name="maLopHoc">Mã lớp học mà giảng viên sẽ được cập nhật vào.</param>
        /// <returns>Trả về số lượng bản ghi bị ảnh hưởng (0 hoặc 1) sau khi thực hiện cập nhật.</returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
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

        /// <summary>
        /// Cập nhật điểm quá trình và điểm cuối kỳ của sinh viên cho một môn học.
        /// </summary>
        /// <param name="maSV">
        /// Mã số sinh viên cần cập nhật điểm.
        /// </param>
        /// <param name="maMH">
        /// Mã môn học của sinh viên.
        /// </param>
        /// <param name="diemGK">
        /// Điểm quá trình (giữa kỳ) của sinh viên.
        /// </param>
        /// <param name="diemCK">
        /// Điểm cuối kỳ của sinh viên.
        /// </param>
        /// <returns>
        /// Trả về số dòng bị ảnh hưởng sau khi thực thi lệnh cập nhật.
        /// <br>- Nếu trả về giá trị > 0, nghĩa là việc cập nhật thành công.</br>
        /// <br>- Nếu trả về 0, nghĩa là không có bản ghi nào bị ảnh hưởng.</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc thực thi câu lệnh SQL.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi không xác định khác.
        /// </exception>
        public int CapNhatDiem(int maSV, int maMH, decimal diemGK, decimal diemCK)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_CapNhatDiemSinhVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@MaSinhVien", maSV));
                        command.Parameters.Add(new SqlParameter("@MaMonHoc", maMH));
                        command.Parameters.Add(new SqlParameter("@DiemQuaTrinh", diemGK));
                        command.Parameters.Add(new SqlParameter("@DiemCuoiKy", diemCK));
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
                throw new Exception(ex.Message);
            }
        }





    }
}
