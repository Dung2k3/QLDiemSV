using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSV.BLL
{
    internal class PhongHocBLL
    {
        public List<PHONGHOC> FindAll(TAIKHOAN tk)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.PHONGHOCs.ToList();
        }
        public PHONGHOC FindByID(String maPhong)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.PHONGHOCs.FirstOrDefault(ph => ph.MaPhong.Equals(maPhong));
        }
    }
}
