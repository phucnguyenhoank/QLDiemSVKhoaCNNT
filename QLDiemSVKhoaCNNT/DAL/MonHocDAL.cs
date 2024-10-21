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
