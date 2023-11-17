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
                db.pr_InsertDiem(diem.MaSV,diem.MaLop,diem.DiemQT,diem.DiemCK);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void UpdateDiem(DIEM diemUpdate)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                db.pr_UpdateDiem(diemUpdate.MaSV,diemUpdate.MaLop,diemUpdate.DiemQT,diemUpdate.DiemCK);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void DeleteDiem(DIEM diemDelete)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                db.pr_DeleteDiem(diemDelete.MaSV, diemDelete.MaLop);
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

        public List<ft_FindDiemSVTheoLopResult> FindDiemSVTheoMaLop (string maLop)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.ft_FindDiemSVTheoLop(maLop).ToList();
        }
    }

}
