using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSV.BLL
{
    internal class GiangVienBLL
    {

        public void InsertGiangVien(GIANGVIEN gv)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                db.GIANGVIENs.InsertOnSubmit(gv);
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void UpdateGiangVien(GIANGVIEN gv)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                GIANGVIEN giangVienUpdate = db.GIANGVIENs.FirstOrDefault(e => e.MaGV.Equals(gv.MaGV));
                giangVienUpdate.HoGV = gv.HoGV;
                giangVienUpdate.TenlotGV = gv.TenlotGV;
                giangVienUpdate.TenGV = gv.TenGV;
                giangVienUpdate.DiaChi = gv.DiaChi;
                giangVienUpdate.CCCD = gv.CCCD;
                giangVienUpdate.Email = gv.Email;
                giangVienUpdate.SDT = gv.SDT;
                giangVienUpdate.Gioitinh = gv.Gioitinh;
                giangVienUpdate.MaKhoa = gv.MaKhoa;
                giangVienUpdate.MaLoaiGV = gv.MaLoaiGV;
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void DeleteGiangVien(GIANGVIEN gv)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                GIANGVIEN giangVien = db.GIANGVIENs.FirstOrDefault(e => e.MaGV.Equals(gv.MaGV));
                db.GIANGVIENs.DeleteOnSubmit(giangVien);
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public List<GIANGVIEN> FindAllGiangVien()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
           return db.GIANGVIENs.ToList();
        }
        public GIANGVIEN FindGiangVienByID(string maGV)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                return db.GIANGVIENs.FirstOrDefault(e => e.MaGV.Equals(maGV));
            } catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
           
        }
        public vi_ThongTinGV FindViewByID(string maGV)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                return db.vi_ThongTinGVs.FirstOrDefault(e => e.MaGV.Equals(maGV));
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }  
        public List<FT_TKBLopGVDangDayResult> GetTKBGV(string maGV, int hk, int namHoc)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                return db.FT_TKBLopGVDangDay(maGV, hk, namHoc).ToList();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
        public List<FT_GVXemDiemResult> GVXemDiem(string maGV,string maLop)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                return  db.FT_GVXemDiem(maGV,maLop).ToList();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
    }
}
