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
                db.pr_InsertKhoa(khoa.MaKhoa, khoa.TenKhoa, khoa.MaTrKhoa, khoa.TrangThai);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void UpdateKhoa(KHOA khoa)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                db.pr_UpdateKhoa(khoa.MaKhoa, khoa.TenKhoa, khoa.MaTrKhoa, khoa.TrangThai);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void DeleteKhoa(string maKhoa)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                db.pr_DeleteKhoa(maKhoa);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public List<KHOA> FindAllKhoa()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.KHOAs.ToList();
        }
        public KHOA FindOneByID(string maKhoa)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.KHOAs.FirstOrDefault(e => e.MaKhoa.Equals(maKhoa));
        }

        
    }
}
