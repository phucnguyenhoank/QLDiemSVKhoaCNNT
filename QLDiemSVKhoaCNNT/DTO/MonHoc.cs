using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSVKhoaCNNT.DTO
{
    internal class MonHoc
    {
        public int MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public byte SoTinChi { get; set; }

        public MonHoc(int maMonHoc = 0, string tenMonHoc = "", byte soTinChi = 1)
        {
            MaMonHoc = maMonHoc;
            TenMonHoc = tenMonHoc;
            SoTinChi = soTinChi;
        }

    }
}
