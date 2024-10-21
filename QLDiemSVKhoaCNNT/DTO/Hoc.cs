using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSVKhoaCNNT.DTO
{
    internal class Hoc
    {
        public int MaSinhVien { get; set; }
        public int MaMonHoc { get; set; }
        public decimal DiemQuaTrinh { get; set; }
        public decimal DiemCuoiKy { get; set; }

        public Hoc(int maSinhVien = 0, int maMonHoc = 0, decimal diemQuaTrinh = 0m, decimal diemCuoiKy = 0m)
        {
            MaSinhVien = maSinhVien;
            MaMonHoc = maMonHoc;
            DiemQuaTrinh = diemQuaTrinh;
            DiemCuoiKy = diemCuoiKy;
        }
    }
}
