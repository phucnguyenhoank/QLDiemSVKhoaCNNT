using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSVKhoaCNNT.DTO
{
    internal class GiangVien
    {
        public int MaGiangVien { get; set; }
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }

        public GiangVien(int maGiangVien = 0, string hoVaTen = "", string email = "", string soDienThoai = "")
        {
            MaGiangVien = maGiangVien;
            HoVaTen = hoVaTen;
            Email = email;
            SoDienThoai = soDienThoai;
        }
    }
}
