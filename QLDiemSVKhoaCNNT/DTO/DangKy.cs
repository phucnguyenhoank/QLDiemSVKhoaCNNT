using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSVKhoaCNNT.DTO
{
    internal class DangKy
    {
        public int MaSinhVien { get; set; }
        public int MaLopHoc { get; set; }
        public decimal DiemQuaTrinh { get; set; }
        public decimal DiemCuoiKy { get; set; }

        public DangKy(int maSinhVien = 0, int maLopHoc = 0, decimal diemQuaTrinh = 0, decimal diemCuoiKy = 0)
        {
            MaSinhVien = maSinhVien;
            MaLopHoc = maLopHoc;
            DiemQuaTrinh = diemQuaTrinh;
            DiemCuoiKy = diemCuoiKy;
        }
    }
}
