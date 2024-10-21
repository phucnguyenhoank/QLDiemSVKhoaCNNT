using QLDiemSVKhoaCNNT.DTO;
using QLDiemSVKhoaCNNT.DBConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDiemSVKhoaCNNT.DAL
{
    internal class SinhVienDAL
    {
        public List<SinhVien> GetSinhVienList()
        {
            string connectionString = QLDSVCNTTConnection.connectionString;
            string query = "SELECT MaSinhVien, HoVaTen, Email, SoDienThoai, QueQuan FROM vw_SinhVien";
            List<SinhVien> sinhVienList = new List<SinhVien>();

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
                                SinhVien sinhVien = new SinhVien(
                                    reader.GetInt32(0),  // MaSinhVien
                                    reader.GetString(1), // HoVaTen
                                    reader.GetString(2), // Email
                                    reader.GetString(3), // SoDienThoai
                                    reader.GetString(4)  // QueQuan
                                );
                                sinhVienList.Add(sinhVien);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("GetSinhVienList: " + ex.Message);
                }
            }

            return sinhVienList;
        }
    }
}
