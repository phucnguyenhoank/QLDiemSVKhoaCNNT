using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSVKhoaCNNT.DTO
{
    internal class PhongHoc
    {
        public int MaPhongHoc { get; set; }
        public byte SucChua { get; set; }

        public PhongHoc(int maPhongHoc = 0, byte sucChua = 10)
        {
            MaPhongHoc = maPhongHoc;
            SucChua = sucChua;
        }
    }
}
