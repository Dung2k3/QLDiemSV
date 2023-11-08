using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSV.BLL
{
    internal class LoaiPhongBLL
    {
        public List<LOAIPHONG> FindAll(TAIKHOAN tk)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.LOAIPHONGs.ToList();
        }

        public LOAIPHONG FindByID(String maLoaiPhong)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.LOAIPHONGs.FirstOrDefault(lp => lp.MaLoaiPhong.Equals(maLoaiPhong));
        }
    }
}
