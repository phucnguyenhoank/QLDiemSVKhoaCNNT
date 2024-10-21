using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSVKhoaCNNT.DTO
{
    internal class SinhVien
    {
        public int MaSinhVien { get; set; }
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string QueQuan { get; set; }

        public SinhVien(int maSinhVien = 0, string hoVaTen = "", string email = "", string soDienThoai = "", string queQuan = "")
        {
            MaSinhVien = maSinhVien;
            HoVaTen = hoVaTen;
            Email = email;
            SoDienThoai = soDienThoai;
            QueQuan = queQuan;
        }
    }
}
