using QLDiemSVKhoaCNNT.DBConnection;
using QLDiemSVKhoaCNNT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;

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
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
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
        /// Xem học lực của một sinh viên dựa vào điểm trung bình các môn đã đăng ký.
        /// </summary>
        /// <param name="maSinhVien">Mã sinh viên cần xem học lực.</param>
        /// <returns>
        /// Trả về chuỗi học lực của sinh viên:
        /// <br>- Giỏi</br>
        /// <br>- Khá</br>
        /// <br>- Trung Bình</br>
        /// <br>- Yếu</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public string XemHocLucSinhVien(int maSinhVien)
        {
            try
            {
                string hocLuc = string.Empty;

                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    string query = @"SELECT dbo.fn_XemHocLucSinhVien(@MaSinhVien) AS HocLuc";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaSinhVien", maSinhVien);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            hocLuc = result.ToString();
                        }
                    }
                }

                return hocLuc;
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

        public int SoTinChiHoanThanh(int maSV)
        {
            try
            {
                int soTinChi = 0;
                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    string querry = "select dbo.fn_SoTinChiDaHoanThanh(" + maSV + ")";
                    using (SqlCommand command = new SqlCommand(querry, connection))
                    {
                        soTinChi = (int)command.ExecuteScalar();
                    }
                    connection.Close();
                }
                return soTinChi;
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Trả về số lượng sinh viên của một lớp học.
        /// </summary>
        /// <param name="maLopHoc">Mã lớp học của lớp cần được đếm sinh viên.</param>
        /// <returns>Sô lượng sinh viên của lớp cần đếm.</returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
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
        /// Tính phần trăm sinh viên qua môn trong một lớp học.
        /// </summary>
        /// <param name="maLopHoc">Mã lớp học cần tính phần trăm qua môn.</param>
        /// <returns>
        /// Trả về phần trăm qua môn (decimal, từ 0 đến 100) của lớp học.
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public decimal TinhPhanTramQuaMon(int maLopHoc)
        {
            try
            {
                decimal phanTramQuaMon = 0;
                string connectionString = QLDSVCNTTConnection.connectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT dbo.fn_TinhPhanTramQuaMon(@MaLopHoc)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaLopHoc", maLopHoc);

                        object result = cmd.ExecuteScalar();

                        // Kiểm tra giá trị trả về không null
                        if (result != DBNull.Value)
                        {
                            phanTramQuaMon = Convert.ToDecimal(result);
                        }
                    }
                }

                return phanTramQuaMon;
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
        /// Đếm số lớp một giảng viên đang phụ trách.
        /// </summary>
        /// <param name="maGiangVien">Mã giảng viên cần kiểm tra.</param>
        /// <returns>Sô lượng lớp mà giảng viên phụ trách.</returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
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
        /// <br>- DiemQuaTrinh: Điểm quá trình của sinh viên.</br>
        /// <br>- Điểm cuối kỳ: Điểm cuối kỳ của sinh viên.</br>
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
                        sv.QueQuan,
                        sv.DiemQuaTrinh,
		                sv.DiemCuoiKy
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
                        XepLoaiMon 
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


        /// <summary>
        /// Lấy điểm trung bình của sinh viên dựa trên mã sinh viên.
        /// </summary>
        /// <param name="maSinhVien">Mã sinh viên cần tính điểm trung bình.</param>
        /// <returns>
        /// Trả về điểm trung bình (decimal) của sinh viên.
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
   
        public decimal LayDiemTrungBinhSinhVien(int maSinhVien)
        {
            try
            {
                decimal diemTrungBinh = 0; // Khởi tạo biến để lưu kết quả
                string connectionString = QLDSVCNTTConnection.connectionString; // Chuỗi kết nối đến SQL Server

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Truy vấn để gọi hàm TinhDiemTrungBinh từ SQL Server
                    string query = "SELECT dbo.fn_TinhDiemTrungBinh(@MaSinhVien)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Thêm tham số maSinhVien
                        cmd.Parameters.AddWithValue("@MaSinhVien", maSinhVien);

                        // Thực thi lệnh và lấy giá trị trả về của function
                        object result = cmd.ExecuteScalar();

                        // Kiểm tra giá trị trả về không null
                        if (result != DBNull.Value)
                        {
                            diemTrungBinh = Convert.ToDecimal(result);
                        }
                    }
                }

                return diemTrungBinh; // Trả về điểm trung bình
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
        /// Hàm tính điểm trung bình tích lũy của một sinh viên dựa trên mã sinh viên.
        /// </summary>
        /// <param name="maSinhVien">Mã sinh viên cần tính điểm trung bình tích lũy.</param>
        /// <returns>Trả về điểm trung bình tích lũy của sinh viên. Nếu có lỗi xảy ra, trả về 0.</returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public decimal TinhDiemTrungBinhTichLuy(int maSinhVien)
        {
            try
            {
                decimal diemTrungBinhTichLuy = 0; // Khởi tạo giá trị ban đầu

                // Chuỗi kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();

                    // Tạo lệnh gọi hàm fn_TinhDiemTrungBinhTichLuy
                    using (SqlCommand cmd = new SqlCommand("SELECT dbo.fn_TinhDiemTrungBinhTichLuy(@MaSinhVien)", connection))
                    {
                        // Thêm tham số mã sinh viên
                        cmd.Parameters.AddWithValue("@MaSinhVien", maSinhVien);

                        // Thực thi lệnh và lấy kết quả trả về
                        object result = cmd.ExecuteScalar();

                        // Nếu kết quả không null, gán vào biến điểm trung bình tích lũy
                        if (result != null && result != DBNull.Value)
                        {
                            diemTrungBinhTichLuy = Convert.ToDecimal(result);
                        }
                    }
                }

                return diemTrungBinhTichLuy;
            }
            catch (SqlException ex)
            {
                // Xử lý lỗi SQL
                throw new Exception($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                throw new Exception($"Error: {ex.Message}");
            }
        }


        public int SoLuongLopSVDangKy(int maSinhVien)
        {
            try
            {
                int soLuongLop = 0;
                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT dbo.fn_DemSoLuongLopDangKy(@MaSinhVien)", connection))
                    {
                        cmd.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
                        soLuongLop = (int)cmd.ExecuteScalar();
                    }
                }
                return soLuongLop;
            }
            catch (SqlException ex)
            {
                // Xử lý lỗi SQL
                throw new Exception($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
