using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDiemSVKhoaCNNT.DBConnection;

namespace QLDiemSVKhoaCNNT.DAL
{
    internal class GiangVienDAL
    {
        /// <summary>
        /// Xóa giảng viên khỏi cơ sở dữ liệu theo mã giảng viên.
        /// </summary>
        /// <param name="maGiangVien">Mã giảng viên cần xóa.</param>
        /// <returns>Trả về số lượng bản ghi bị ảnh hưởng (0 hoặc 1).</returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public int XoaGiangVien(int maGiangVien)
        {
            try
            {
                string connectionString = QLDSVCNTTConnection.connectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("proc_XoaGiangVien", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaGiangVien", maGiangVien);
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
