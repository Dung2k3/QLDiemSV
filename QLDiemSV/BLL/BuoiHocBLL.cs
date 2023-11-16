using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSV.BLL
{
    internal class BuoiHocBLL
    {
        public void InsertBuoiHoc(BUOIHOC bh)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                db.pr_InsertBuoiHoc(bh.MaLop, bh.MaCa, bh.MaPhong, bh.Thu);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void UpdateBuoiHoc(BUOIHOC bhUpdate)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                db.pr_UpdateBuoiHoc(bhUpdate.MaLop, bhUpdate.MaCa, bhUpdate.MaPhong, bhUpdate.Thu);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void DeleteBuoiHoc(BUOIHOC bhDelete)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                db.pr_DeleteBuoiHoc(bhDelete.MaLop, bhDelete.MaCa, bhDelete.MaPhong, bhDelete.Thu);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public List<BUOIHOC> FindAllBuoiHoc()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.BUOIHOCs.ToList();
        }

        public List<vi_LopCaPhong> FindThongTinLop()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.vi_LopCaPhongs.ToList();
        }
    }
}
