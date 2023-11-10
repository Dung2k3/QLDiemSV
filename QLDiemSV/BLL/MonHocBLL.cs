using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Windows.Forms;

namespace QLDiemSV.BLL
{
    internal class MonHocBLL
    {
        public List<MONHOC> FindAllMonHoc()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.MONHOCs.ToList();
        }
        public MONHOC FindByID(string maMon)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.MONHOCs.FirstOrDefault(e => e.Equals(maMon));
        }
        public void InsertMonHoc(MONHOC monHoc)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                db.MONHOCs.InsertOnSubmit(monHoc);
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void UpdateMonHoc(MONHOC monHoc)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                MONHOC updateMonHoc = db.MONHOCs.FirstOrDefault(e=>e.MaMon.Equals(monHoc.MaMon));
                updateMonHoc.TenMon = monHoc.TenMon;
                updateMonHoc.SoTinChi = monHoc.SoTinChi;
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void DeleteMonHoc(string maMonHoc)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                MONHOC deleteMonHoc = db.MONHOCs.FirstOrDefault(e => e.Equals(maMonHoc));
                db.MONHOCs.DeleteOnSubmit(deleteMonHoc);
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
