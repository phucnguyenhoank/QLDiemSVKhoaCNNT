using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSVKhoaCNNT.DBConnection
{
    internal class QLDSVCNTTConnection
    {
        public static string connectionString = "";
        public QLDSVCNTTConnection(string username="sa", string password="1234")
        {
            connectionString = $@"Data Source=LAPTOP-EC6KMGRU;Initial Catalog=QLDiemSVKhoaCNTT;User ID={username};Password={password};TrustServerCertificate=True";
        }

        /// <summary>
        /// Test the database connection.
        /// </summary>
        /// <returns>0 nếu kết nối thành công.</returns>
        /// <exception cref="SqlException">
        /// Ném ra khi có lỗi xảy ra trong quá trình kết nối hoặc truy vấn cơ sở dữ liệu.
        /// </exception>
        /// <exception cref="Exception">
        /// Ném ra khi có lỗi khác không xác định xảy ra.
        /// </exception>
        public static int TestConnection()
        {
            try
            {
                // Sử dụng chuỗi kết nối đã định nghĩa để tạo kết nối tới cơ sở dữ liệu
                string connectionString = QLDSVCNTTConnection.connectionString;

                // Tạo đối tượng SqlConnection với chuỗi kết nối
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Mở kết nối tới cơ sở dữ liệu
                    connection.Open();

                    // Nếu mở kết nối thành công, trả về 0
                    return 0; // Có thể trả về mã 0 nếu kết nối thành công
                }
            }
            catch (SqlException)
            {
                // Ném lại lỗi SQL để xử lý ở nơi gọi hàm
                throw;
            }
            catch (Exception ex)
            {
                // Ném lỗi chung với thông điệp cụ thể
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }

}
