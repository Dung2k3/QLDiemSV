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
        public List<TAIKHOAN> FindAll(TAIKHOAN tk)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.TAIKHOANs.ToList();
        }

        public TAIKHOAN FindByID(String taikhoan)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.TAIKHOANs.FirstOrDefault(tk => tk.TaiKhoan1.Equals(taikhoan));
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

        public void Delete(String taikhoan)
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
    }
}
