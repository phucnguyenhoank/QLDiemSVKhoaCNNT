using QLDiemSVKhoaCNNT.DBConnection;
using QLDiemSVKhoaCNNT.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSVKhoaCNNT.DAL
{
    internal class LopHocDAL
    {
        public List<LopHoc> GetLopHoc()
        {
            List<LopHoc> lopHocList = new List<LopHoc>();

            try
            {
                using (SqlConnection connection = new SqlConnection(QLDSVCNTTConnection.connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaLopHoc, Thu, TietBatDau, TietKetThuc FROM LopHoc";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        LopHoc lopHoc = new LopHoc
                        {
                            MaLopHoc = reader.GetInt32(0),
                            Thu = reader.GetByte(1),
                            TietBatDau = reader.GetByte(2),
                            TietKetThuc = reader.GetByte(3)
                        };
                        lopHocList.Add(lopHoc);
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

            return lopHocList;

        }
    }
}
