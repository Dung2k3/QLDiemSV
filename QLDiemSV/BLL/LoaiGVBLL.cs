using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSV.BLL
{
    internal class LoaiGVBLL
    {
        public List<LOAIGV> FindAll(TAIKHOAN tk)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.LOAIGVs.ToList();
        }

        public LOAIGV FindByID(String maLoaiGV)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.LOAIGVs.FirstOrDefault(lgv => lgv.MaLoaiGV.Equals(maLoaiGV));
        }
    }
}
