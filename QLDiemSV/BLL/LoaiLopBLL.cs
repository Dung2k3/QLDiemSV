using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDiemSV.BLL
{
    internal class LoaiLopBLL
    {
        public List<LOAILOP> FindAll()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.LOAILOPs.ToList();
        }

        public LOAILOP FindByID(string maLoaiLop)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.LOAILOPs.FirstOrDefault(ll => ll.MaLoaiLop.Equals(maLoaiLop));
        }
    }
}
