using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSV
{
    internal class KhoaBLL
    {
        public void InsertKhoa(KHOA khoa)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                db.KHOAs.InsertOnSubmit(khoa);
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void UpdateKhoa(KHOA khoa)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                KHOA khoaUpdate = db.KHOAs.FirstOrDefault(e => e.MaKhoa.Equals(khoa.MaKhoa));
                khoaUpdate.MONHOCs = khoa.MONHOCs;
                khoaUpdate.TenKhoa = khoa.TenKhoa;
                khoaUpdate.MaTrKhoa = khoa.MaTrKhoa;
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void DeleteKhoa(String maKhoa)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                KHOA khoaDelete = db.KHOAs.FirstOrDefault(e => e.MaKhoa.Equals(maKhoa));
                db.KHOAs.DeleteOnSubmit(khoaDelete);
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public List<KHOA> FindAllKhoa()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.KHOAs.ToList();
        }
        public KHOA FindOneByID(String maKhoa)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.KHOAs.FirstOrDefault(e => e.MaKhoa.Equals(maKhoa));
        }
    }
}
