using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSVKhoaCNNT.DTO
{
    internal class LopHoc
    {
        public int MaLopHoc { get; set; }
        public byte Thu { get; set; }
        public byte TietBatDau { get; set; }
        public byte TietKetThuc { get; set; }
        public int MaPhongHoc { get; set; }
        public int MaGiangVien { get; set; }
        public int MaMonHoc { get; set; }

        public LopHoc(int maLopHoc = 0, byte thu = 1, byte tietBatDau = 1, byte tietKetThuc = 1, int maPhongHoc = 0, int maGiangVien = 0, int maMonHoc = 0)
        {
            MaLopHoc = maLopHoc;
            Thu = thu;
            TietBatDau = tietBatDau;
            TietKetThuc = tietKetThuc;
            MaPhongHoc = maPhongHoc;
            MaGiangVien = maGiangVien;
            MaMonHoc = maMonHoc;
        }
    }
}
