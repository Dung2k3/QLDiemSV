using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSV.BLL
{
    internal class TaiKhoanBLL
    {
        public List<TAIKHOAN> FindAll()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.TAIKHOANs.ToList();
        }

        public TAIKHOAN FindByID(string taikhoan)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.TAIKHOANs.FirstOrDefault(tk => tk.TaiKhoan1.Equals(taikhoan));
        }

        public List<vi_taikhoangiangvien> FindTKGV()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.vi_taikhoangiangviens.ToList();
        }

        public List<vi_taikhoansinhvien> FindTKSV()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.vi_taikhoansinhviens.ToList();
        }

        public void Insert(TAIKHOAN taikhoan)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                db.TAIKHOANs.InsertOnSubmit(taikhoan);
                db.SubmitChanges();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Update(TAIKHOAN taikhoan)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                TAIKHOAN uptaikhoan = db.TAIKHOANs.FirstOrDefault(tk => tk.TaiKhoan1.Equals(taikhoan.TaiKhoan1));
                uptaikhoan.MatKhau = taikhoan.MatKhau;
                db.SubmitChanges();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Delete(string taikhoan)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                TAIKHOAN deltaikhoan = db.TAIKHOANs.FirstOrDefault(tk => tk.TaiKhoan1.Equals(taikhoan));
                db.TAIKHOANs.DeleteOnSubmit(deltaikhoan);
                db.SubmitChanges();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public string CheckDangNhap(string tk, string mk,int loai)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.ft_ChkDangNhap(tk, mk, loai);
        }
        public bool CheckQuenMK(string tk, string email, string cccd, int loai)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return (bool)db.ft_ChkQuenMatKhau(tk, email, cccd, loai);   
        }
    }
}
