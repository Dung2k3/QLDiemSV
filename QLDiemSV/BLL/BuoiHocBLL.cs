﻿using System;
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
                db.BUOIHOCs.InsertOnSubmit(bh);
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
      
        public void DeleteBuoiHoc(BUOIHOC bh)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                BUOIHOC bhDelete = db.BUOIHOCs.FirstOrDefault(e => e.MaLop.Equals(bh.MaLop) && e.MaPhong.Equals(bh.MaPhong) && e.MaCa.Equals(bh.MaCa) && e.Thu.Equals(bh.Thu));
                db.BUOIHOCs.DeleteOnSubmit(bhDelete);
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
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

        public void ThemBuoiHoc(LOP lop, BUOIHOC buoiHoc)
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                db.PR_ThemBuoiHoc(lop.TenLop, lop.MaLoaiLop, lop.SL, lop.HK, lop.Namhoc, lop.MaGV, lop.MaMon, buoiHoc.MaCa, buoiHoc.MaPhong, buoiHoc.Thu);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
