using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSV.BLL
{
    internal class MonTienQuyet
    {
        public void InsertMonTienQuyet(MONTIENQUYET monTienQuyet)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                db.PR_InsertMONTQ(monTienQuyet.MaMon, monTienQuyet.MaMonTQ);
            }
            catch (SqlException e) { 
                MessageBox.Show(e.Message); 
            }
        }

        public void DeleteMonTienQyet(MONTIENQUYET monTienQuyet)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                MONTIENQUYET deleteMonTienQuyet = db.MONTIENQUYETs.FirstOrDefault(e => e.Equals(monTienQuyet.MaMon) && e.Equals(monTienQuyet.MaMonTQ));
                db.PR_DeleteMONTQ(deleteMonTienQuyet.MaMon, deleteMonTienQuyet.MaMonTQ);
            }
            catch (SqlException e) 
            { 
                MessageBox.Show(e.Message); 
            }
        }
    }
}
