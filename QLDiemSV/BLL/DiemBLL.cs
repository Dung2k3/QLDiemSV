using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSV.BLL
{
    internal class DiemBLL
    {
        public void InsertDiem(DIEM diem)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                db.DIEMs.InsertOnSubmit(diem);
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void UpdateDiem(DIEM diem)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                DIEM diemUpdate = db.DIEMs.FirstOrDefault(e => e.MaSV.Equals(diem.MaSV) && e.MaLop.Equals(diem.MaLop));
                diemUpdate.DiemCK = diem.DiemCK;
                diemUpdate.DiemQT = diem.DiemQT;
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void DeleteDiem(DIEM diem)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                DIEM diemDelete = db.DIEMs.FirstOrDefault(e => e.MaSV.Equals(diem.MaSV) && e.MaLop.Equals(diem.MaLop));
                db.DIEMs.DeleteOnSubmit(diemDelete);
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public List<DIEM> FindAllDiem()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.DIEMs.ToList();
        }
    }

}
