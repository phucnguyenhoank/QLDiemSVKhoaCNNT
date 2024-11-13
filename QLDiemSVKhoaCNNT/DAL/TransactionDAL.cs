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
    internal class TransactionDAL
    {
        public int ChuyenSinhVienSangLopKhac(int maSinhVien, int maLopHocCu, int maLopHocMoi)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString; // Chuỗi kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_ChuyenSinhVienSangLopKhac", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số vào stored procedure
                        command.Parameters.AddWithValue("@MaSinhVien", maSinhVien);
                        command.Parameters.AddWithValue("@MaLopHocCu", maLopHocCu);
                        command.Parameters.AddWithValue("@MaLopHocMoi", maLopHocMoi);

                        // Thực thi stored procedure và trả về số dòng bị ảnh hưởng
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                throw;  // Ném lại lỗi SQL nếu có
            }
            catch (Exception ex)
            {
                // Ném lại lỗi với thông điệp chi tiết nếu có lỗi khác
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
