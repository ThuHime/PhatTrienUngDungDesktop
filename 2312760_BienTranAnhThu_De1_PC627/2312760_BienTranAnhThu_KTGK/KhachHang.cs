using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312760_BienTranAnhThu_KTGK
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string Ten {  get; set; }    
        public string SDT {  get; set; }
        public string DiaChi {  get; set; }
        public KhachHang() { }
        public KhachHang(string maKH, string ten, string sDT, string diaChi)
        {
            MaKH = maKH;
            Ten = ten;
            SDT = sDT;
            DiaChi = diaChi;
        }
    }
}
