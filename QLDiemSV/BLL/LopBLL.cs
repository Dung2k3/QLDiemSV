using QLDiemSV.UI.Teacher;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSV.BLL
{
    internal class LopBLL
    {
        public List<LOP> FindAllLop()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.LOPs.ToList();
        }

        public LOP FindByID(string maLop)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.LOPs.FirstOrDefault(e=>e.Equals(maLop));
        }

        public void InsertLop(LOP lop)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                db.LOPs.InsertOnSubmit(lop);
                db.SubmitChanges();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void UpdateLop(LOP lop)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                LOP updateLop = db.LOPs.FirstOrDefault(e => e.MaLop.Equals(lop.MaLop));
                updateLop.TenLop = lop.TenLop;
                updateLop.SL = lop.SL;
                updateLop.HK = lop.HK;
                db.SubmitChanges();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void DeleteLop(string maLop)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                LOP deleteLop = db.LOPs.FirstOrDefault(e => e.MaLop.Equals(maLop));
                db.LOPs.DeleteOnSubmit(deleteLop);
                db.SubmitChanges();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public List<FT_ThongTinLopTheoHSResult> FindByID_HK_NHvi(string maSV, int hk, int nh)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.FT_ThongTinLopTheoHS(maSV,hk,nh).ToList();
        }
    }
}
