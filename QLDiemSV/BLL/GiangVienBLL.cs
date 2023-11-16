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
                db.pr_InsertGiangVien(gv.HoGV, gv.TenlotGV, gv.TenGV, gv.CCCD, gv.DiaChi, gv.Gioitinh,gv.NgaySinh, gv.SDT, gv.Email, gv.MaLoaiGV, gv.MaKhoa, gv.TaiKhoan, gv.TrangThai);
                
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void UpdateGiangVien(GIANGVIEN gv)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                db.pr_UpdateGiangVien(gv.MaGV,gv.HoGV, gv.TenlotGV, gv.TenGV, gv.CCCD, gv.DiaChi, gv.Gioitinh, gv.NgaySinh, gv.SDT, gv.Email, gv.MaLoaiGV, gv.MaKhoa, gv.TaiKhoan, gv.TrangThai);
                
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void DeleteGiangVien(GIANGVIEN gv)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                db.pr_DeleteGiangVien(gv.MaGV);
                
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
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
                MessageBox.Show(e.Message);
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
                MessageBox.Show(e.Message);
                return null;
            }
        }  
        public List<ft_TKBLopGVDangDayResult> GetTKBGV(string maGV, int hk, int namHoc)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.ft_TKBLopGVDangDay(maGV, hk, namHoc).ToList();
        }
        public List<ft_GVXemDiemResult> GVXemDiem(string maGV,string maLop)
        {

            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return  db.ft_GVXemDiem(maGV,maLop).ToList();

        }
        public List<vi_ThongTinGV> FindAllThongTinGV()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.vi_ThongTinGVs.ToList();
        }

        public List<ft_TimGVTheoKhoaResult> FindThongTinGiangVienByMaKhoa(string tenKhoa)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.ft_TimGVTheoKhoa(tenKhoa).ToList();
        }

        public List<ft_LayDanhSachLopGiangVienDaDayResult> FindLopGVDay(string maGV)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.ft_LayDanhSachLopGiangVienDaDay(maGV).ToList();
        }
    }
}
