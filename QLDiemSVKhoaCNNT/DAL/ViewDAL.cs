using QLDiemSVKhoaCNNT.DBConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDiemSVKhoaCNNT.DTO;

namespace QLDiemSVKhoaCNNT.DAL
{
    internal class ViewDAL
    {
        /// <summary>
        /// Lấy danh sách sinh viên từ view vw_SinhVien.
        /// </summary>
        /// <returns>
        /// Một bảng chứa thông tin của toàn bộ sinh viên gồm các cột:
        /// <br>- MaSinhVien</br>
        /// <br>- HoVaTen</br>
        /// <br>- Email</br>
        /// <br>- SoDienThoai</br>
        /// <br>- QueQuan</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public DataTable GetViewSinhVien()
        {
            try
            {
                DataTable danhSachSinhVien = new DataTable();

                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    string query = @"SELECT MaSinhVien, HoVaTen, Email, SoDienThoai, QueQuan FROM vw_SinhVien";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
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
        /// Lấy danh sách giảng viên từ view vw_GiangVien.
        /// </summary>
        /// <returns>
        /// Một bảng chứa thông tin của toàn bộ giảng viên gồm các cột:
        /// <br>- MaGiangVien</br>
        /// <br>- HoVaTen</br>
        /// <br>- Email</br>
        /// <br>- SoDienThoai</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public DataTable GetViewGiangVien()
        {
            try
            {
                DataTable danhSachGiangVien = new DataTable();

                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    string query = @"SELECT MaGiangVien, HoVaTen, Email, SoDienThoai FROM vw_GiangVien";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(danhSachGiangVien);
                        }
                    }
                }

                return danhSachGiangVien;
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
        /// Lấy danh sách môn học từ view vw_MonHoc.
        /// </summary>
        /// <returns>
        /// Một bảng chứa thông tin của toàn bộ môn học gồm các cột:
        /// <br>- MaMonHoc</br>
        /// <br>- TenMonHoc</br>
        /// <br>- SoTinChi</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public DataTable GetViewMonHoc()
        {
            try
            {
                DataTable danhSachMonHoc = new DataTable();

                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    string query = @"SELECT MaMonHoc, TenMonHoc, SoTinChi FROM vw_MonHoc";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(danhSachMonHoc);
                        }
                    }
                }

                return danhSachMonHoc;
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
        /// Lấy danh sách lớp học và giảng viên phụ trách từ view vw_LopHocGiangVienPhuTrach.
        /// </summary>
        /// <returns>
        /// Một bảng chứa thông tin của toàn bộ lớp học cùng với giảng viên phụ trách gồm các cột:
        /// <br>- MaLopHoc</br>
        /// <br>- Thu</br>
        /// <br>- TietBatDau</br>
        /// <br>- TietKetThuc</br>
        /// <br>- MaPhongHoc</br>
        /// <br>- MaMonHoc</br>
        /// <br>- MaGiangVien</br>
        /// <br>- HoVaTen</br>
        /// <br>- Email</br>
        /// <br>- SoDienThoai</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public DataTable GetViewLopHocGiangVienPhuTrach()
        {
            try
            {
                DataTable danhSachLopHocGiangVien = new DataTable();

                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
                                MaLopHoc, 
                                Thu, 
                                TietBatDau, 
                                TietKetThuc, 
                                MaPhongHoc, 
                                MaMonHoc, 
                                MaGiangVien, 
                                HoVaTen, 
                                Email, 
                                SoDienThoai 
                            FROM vw_LopHocGiangVienPhuTrach";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(danhSachLopHocGiangVien);
                        }
                    }
                }

                return danhSachLopHocGiangVien;
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
        /// Lấy danh sách điểm trung bình của sinh viên từ view vw_DiemTrungBinhSinhVien.
        /// </summary>
        /// <returns>
        /// Một bảng chứa thông tin về điểm trung bình của sinh viên gồm các cột:
        /// <br>- MaSinhVien</br>
        /// <br>- HoVaTen</br>
        /// <br>- DiemTrungBinh</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public DataTable GetViewDiemTrungBinhSinhVien()
        {
            try
            {
                DataTable danhSachDiemTrungBinh = new DataTable();

                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    string query = @"SELECT MaSinhVien, HoVaTen, DiemTrungBinh 
                             FROM vw_DiemTrungBinhSinhVien";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(danhSachDiemTrungBinh);
                        }
                    }
                }

                return danhSachDiemTrungBinh;
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
        /// Lấy danh sách điểm trung bình tích lũy của sinh viên từ view vw_DiemTrungBinhTichLuySinhVien.
        /// </summary>
        /// <returns>
        /// Một bảng chứa thông tin về điểm trung bình tích lũy của sinh viên gồm các cột:
        /// <br>- MaSinhVien</br>
        /// <br>- HoVaTen</br>
        /// <br>- DiemTrungBinhTichLuy</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public DataTable GetViewDiemTrungBinhTichLuySinhVien()
        {
            try
            {
                DataTable danhSachDiemTrungBinhTichLuy = new DataTable();

                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
                                MaSinhVien, 
                                HoVaTen, 
                                DiemTrungBinhTichLuy 
                             FROM vw_DiemTrungBinhTichLuySinhVien";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(danhSachDiemTrungBinhTichLuy);
                        }
                    }
                }

                return danhSachDiemTrungBinhTichLuy;
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
        /// Lấy danh sách điểm tổng kết theo học kỳ từ view vw_DiemTongKetTheoHocKy.
        /// </summary>
        /// <returns>
        /// Một bảng chứa thông tin của toàn bộ sinh viên và điểm tổng kết theo học kỳ gồm các cột:
        /// <br>- MaSinhVien</br>
        /// <br>- HoVaTen</br>
        /// <br>- MaLopHoc</br>
        /// <br>- MaMonHoc</br>
        /// <br>- DiemQuaTrinh</br>
        /// <br>- DiemCuoiKy</br>
        /// <br>- DiemTrungBinhMon</br>
        /// <br>- XepLoai</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public DataTable GetDanhSachDiemTongKetTheoHocKy()
        {
            try
            {
                DataTable danhSachDiemTongKet = new DataTable();

                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
                                MaSinhVien, 
                                HoVaTen, 
                                MaLopHoc, 
                                MaMonHoc, 
                                DiemQuaTrinh, 
                                DiemCuoiKy, 
                                DiemTrungBinhMon, 
                                XepLoai 
                            FROM vw_DiemTongKetTheoHocKy";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(danhSachDiemTongKet);
                        }
                    }
                }

                return danhSachDiemTongKet;
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

        public List<PhongHoc> GetPhongHocConTrong()
        {
            string connectionString = QLDSVCNTTConnection.connectionString;
            string query = "SELECT MaPhongHoc, SucChua FROM vw_PhongHocConTrong";
            List<PhongHoc> phongHocList = new List<PhongHoc>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PhongHoc phongHoc = new PhongHoc(
                                    reader.GetInt32(0),  // MaPhongHoc
                                    reader.GetByte(1)    // SucChua
                                );
                                phongHocList.Add(phongHoc);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("GetPhongHocConTrong: " + ex.Message);
                }
            }

            return phongHocList;
        }



    }
}
