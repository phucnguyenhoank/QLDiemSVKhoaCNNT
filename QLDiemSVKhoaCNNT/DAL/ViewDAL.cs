﻿using QLDiemSVKhoaCNNT.DBConnection;
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
        /// Lấy danh sách các lớp học còn trống và số lượng chỗ trống.
        /// </summary>
        /// <returns>
        /// Trả về một DataTable chứa thông tin các lớp học còn trống sinh viên, bao gồm các cột:
        /// <br>- MaLopHoc</br>
        /// <br>- MaPhongHoc</br>
        /// <br>- SucChua</br>
        /// <br>- SoSinhVienDaDangKy</br>
        /// <br>- SoLuongConTrong</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public DataTable GetDanhSachLopHocConTrong()
        {
            try
            {
                DataTable danhSachLopHocConTrong = new DataTable();

                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
                                MaLopHoc, 
                                MaPhongHoc, 
                                SucChua, 
                                SoSinhVienDaDangKy, 
                                SoLuongConTrong 
                             FROM vw_LopHocConTrong";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(danhSachLopHocConTrong);
                        }
                    }
                }

                return danhSachLopHocConTrong;
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
        /// Lấy danh sách xếp hạng sinh viên từ view vw_XepHangSinhVienBangDiemTBTichLuy.
        /// </summary>
        /// <returns>
        /// Trả về một DataTable chứa danh sách xếp hạng sinh viên gồm các cột như:
        /// <br>- MaSinhVien: Mã sinh viên</br>
        /// <br>- HoVaTen: Họ và tên sinh viên</br>
        /// <br>- SoTinChiDaHoanThanh: Số tín chỉ đã hoàn thành</br>
        /// <br>- DiemTrungBinh: Điểm trung bình tích lũy</br>
        /// </returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception
        public DataTable GetViewXepHangSinhVien()
        {
            try
            {
                DataTable DanhSachXepHang = new DataTable();
                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select * from vw_XepHangSinhVien", connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(DanhSachXepHang);
                        }
                    }
                }
                return DanhSachXepHang;
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
        public int capNhatDiem(int maSV, int maLH, decimal diemGK, decimal diemCK)
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


    }
}
