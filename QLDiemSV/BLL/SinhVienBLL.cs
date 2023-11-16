using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSV.BLL
{
    internal class SinhVienBLL
    {
        public void Insert(SINHVIEN sv)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                db.pr_InsertSinhVien(sv.HoSV,sv.TenlotSV,sv.TenSV,sv.CCCD,sv.DiaChi,sv.Gioitinh, sv.NgaySinh, sv.SDT,sv.Email, sv.NamNhapHoc, sv.MaKhoa,null,true);
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Update(SINHVIEN sv)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                db.pr_UpdateSinhVien(sv.MaSV,sv.HoSV,sv.TenlotSV,sv.TenSV,sv.CCCD,sv.DiaChi,sv.Gioitinh,sv.NgaySinh,sv.SDT,sv.Email,sv.NamNhapHoc,sv.MaKhoa,sv.TaiKhoan,sv.TrangThai);
                
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void Delete(SINHVIEN sv)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                db.pr_DeleteSinhVien(sv.MaSV);
               
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public SINHVIEN FindByID(string id)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.SINHVIENs.FirstOrDefault(e => e.MaSV.Equals(id));
        }
        public List<SINHVIEN> FindAll()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.SINHVIENs.ToList();
        }

            public List<ft_TimSVTheoKhoaResult> FindSinhVienbyKhoa(string maKhoa)
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                return db.ft_TimSVTheoKhoa(maKhoa).ToList();
            }

        public List<vi_ThongTinSV> FindAllThongTinSV()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.vi_ThongTinSVs.ToList();
        }

        public List<ft_LayDanhSachLopSinhVienDaHocCoDiemResult> FindLopSVHoc(string maSV)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.ft_LayDanhSachLopSinhVienDaHocCoDiem(maSV).ToList();
        }
        public vi_ThongTinSV FindByIDvi(string id)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.vi_ThongTinSVs.FirstOrDefault(e => e.MaSV.Equals(id));
        }
        public List<ft_TKBSVTheoHKResult> LayTKB(string maSV, int hk, int nam)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.ft_TKBSVTheoHK(maSV, hk, nam).ToList();
        }
    }
}
