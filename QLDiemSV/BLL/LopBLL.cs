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
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                return db.LOPs.ToList();
            } catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public LOP FindByID(string maLop)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.LOPs.FirstOrDefault(e=>e.Equals(maLop));
        }

        public List<vi_ThongTinLop> FindAllThongTinLop()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.vi_ThongTinLops.ToList();
        }

        public void InsertLop(LOP lop, BUOIHOC buoiHoc)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                db.pr_ThemLop(lop.TenLop, lop.MaLoaiLop, lop.SL, lop.HK, lop.Namhoc, lop.MaGV, lop.MaMon, buoiHoc.MaCa, buoiHoc.MaPhong, buoiHoc.Thu);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void UpdateLop(LOP lop)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                LOP updateLop = db.LOPs.FirstOrDefault(e => e.MaLop.Equals(lop.MaLop));
                db.PR_UpdateLOP(updateLop.MaLop, updateLop.TenLop, updateLop.MaLoaiLop, updateLop.SL, updateLop.HK, updateLop.Namhoc, updateLop.MaGV, updateLop.MaMon);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void DeleteLop(string maLop)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                LOP deleteLop = db.LOPs.FirstOrDefault(e => e.MaLop.Equals(maLop));
                db.PR_DeleteLOP(deleteLop.MaLop);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public List<ft_ThongTinLopTheoHSResult> FindByID_HK_NHvi(string maSV, int hk, int nh)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.ft_ThongTinLopTheoHS(maSV,hk,nh).ToList();
        }
    }
}
