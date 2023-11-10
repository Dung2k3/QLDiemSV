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
                MessageBox.Show(e.Message);
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
                MessageBox.Show(e.Message);
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
                MessageBox.Show(e.Message);
            }
        }
        public List<DIEM> FindAllDiem()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.DIEMs.ToList();
        }

        public DIEM FindDiemByID(string maSV, string maLop)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.DIEMs.FirstOrDefault(e => e.MaSV.Equals(maSV) && e.MaLop.Equals(maLop));
        }

        public List<vi_DiemSVTheoLop> FindDiemSVTheoLop()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.vi_DiemSVTheoLops.ToList();
        }

        public List<vi_DiemSVTheoMon> FindDiemSVTheoMon()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.vi_DiemSVTheoMons.ToList();
        }
        public double TinhDiemTBTichLuy(string maSV)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            decimal? diem = db.ft_TinhTBTL(maSV);
            return (double)(diem.HasValue ? diem.Value : 0);
        }
    }

}
