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
                db.SINHVIENs.InsertOnSubmit(sv);
                db.SubmitChanges();
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
                SINHVIEN updateSV = db.SINHVIENs.FirstOrDefault(e => e.MaSV.Equals(sv.MaSV));
                updateSV.HoSV = sv.HoSV;
                updateSV.TenlotSV = sv.TenlotSV;
                updateSV.TenSV = sv.TenSV;
                updateSV.DiaChi = sv.DiaChi;
                updateSV.CCCD = sv.CCCD;
                updateSV.Email = sv.Email;
                updateSV.SDT = sv.SDT;
                updateSV.Gioitinh = sv.Gioitinh;
                updateSV.NgaySinh = sv.NgaySinh;
                updateSV.NamNhapHoc = sv.NamNhapHoc;
                updateSV.TrangThai = sv.TrangThai;
                db.SubmitChanges();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Delete(SINHVIEN sv)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {

                SINHVIEN deleteSV = db.SINHVIENs.FirstOrDefault(e => e.MaSV.Equals(sv.MaSV));
                db.SINHVIENs.DeleteOnSubmit(deleteSV);
                db.SubmitChanges();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public SINHVIEN FindByID(string id)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.SINHVIENs.FirstOrDefault(e => e.MaSV.Equals(id));
        }
        public List<SINHVIEN> FindAll(string id)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.SINHVIENs.ToList();
        }
    }
}
