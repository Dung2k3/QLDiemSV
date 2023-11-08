using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSV.BLL
{
    internal class CaHoc
    {
        public List<CAHOC> FindAllCaHoc()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.CAHOCs.ToList();
        }
        public CAHOC FindByID(string maCaHoc)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.CAHOCs.FirstOrDefault(e => e.Equals(maCaHoc));
        }  
    }
}
