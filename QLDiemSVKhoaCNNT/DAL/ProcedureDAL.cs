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
        /// Cập nhật điểm quá trình và điểm cuối kỳ cho sinh viên trong lớp học.
        /// </summary>
        /// <param name="maSV">Mã số sinh viên cần cập nhật điểm.</param>
        /// <param name="maLH">Mã lớp học mà sinh viên đã đăng ký.</param>
        /// <param name="diemGK">Điểm quá trình (giữa kỳ) cần cập nhật.</param>
        /// <param name="diemCK">Điểm cuối kỳ cần cập nhật.</param>
        /// <returns>
        /// Trả về số lượng dòng bị ảnh hưởng (nếu cập nhật thành công).
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc thực thi câu lệnh SQL.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi chung khác.
        /// </exception>
        public int CapNhatDiem(int maSV, int maLH, decimal diemGK, decimal diemCK)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("proc_CapNhatDiemSinhVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@MaSinhVien", maSV));
                        command.Parameters.Add(new SqlParameter("@MaLopHoc", maLH));
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

        /// <summary>
        /// Gọi thủ tục proc_XemKetQuaHocTapCuaLop để lấy danh sách kết quả học tập môn học được dạy tại lớp học, kết quả này là bảng điểm của sinh viên với môn học được dạy. 
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
        /// Gọi thủ tục proc_XemThoiKhoaBieuSinhVien để lấy thời khóa biểu của sinh viên.
        /// </summary>
        /// <param name="maSinhVien">Mã sinh viên cần xem thời khóa biểu.</param>
        /// <returns>
        /// Danh sách các sinh viên bao gồm:
        /// <br>- Thu: thứ của lớp học.</br>
        /// <br>- TietBatDau: Tiết bắt đầu.</br>
        /// <br>- TietKetThuc: Tiết kết thúc.</br>
        /// <br>- TenMonHoc: Tên môn học được dạy tại lớp.</br>
        /// <br>- SoTinChi: Số tín chỉ của môn học.</br>
        /// <br>- TenGiangVien: Xếp loại học lực (Giỏi, Khá, Trung Bình, Yếu, hoặc Chưa biết nếu thiếu điểm).</br>
        /// <br>- MaPhongHoc: Trạng thái qua môn (QUA, RỚT hoặc Chưa biết nếu thiếu điểm).</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public DataTable XemThoiKhoaBieu1SV(int maSinhVien)
        {
            try
            {
                DataTable thoiKhoaBieu = new DataTable();
                String connectionString = QLDSVCNTTConnection.connectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_XemThoiKhoaBieuSinhVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaSinhVien", maSinhVien);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                           thoiKhoaBieu.Load(reader);
                            return thoiKhoaBieu;
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
        /// Gọi thủ tục proc_GiangVienDayMonHocVoiSoSVDangKyCaoNhat để lấy danh sách giảng viên dạy môn học với số lượng sinh viên đăng ký cao nhất.
        /// </summary>
        /// <returns>
        /// Danh sách giảng viên dạy môn học có số lượng sinh viên đăng ký cao nhất, bao gồm:
        /// <br>- MaGiangVien: Mã giảng viên.</br>
        /// <br>- TenGiangVien: Tên giảng viên.</br>
        /// <br>- TenMonHoc: Tên môn học giảng viên dạy.</br>
        /// <br>- SoLuongSinhVien: Số lượng sinh viên đăng ký môn học.</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public DataTable GetGiangVienDayMonHocVoiSoSVDangKyCaoNhat()
        {
            try
            {
                DataTable result = new DataTable();

                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("proc_GiangVienDayMonHocVoiSoSVDangKyCaoNhat", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);
                        }
                    }
                }

                return result;
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
