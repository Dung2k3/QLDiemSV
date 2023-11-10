﻿using QLDiemSV.UI.Teacher;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSV.BLL
{
    internal class LopBLL
    {
        public List<LOP> FindAllLop()
        {
            try
            {
                QLSinhVienDataContext db = new QLSinhVienDataContext();
                return db.LOPs.ToList();
            } catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public LOP FindByID(string maLop)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.LOPs.FirstOrDefault(e=>e.Equals(maLop));
        }

        public List<vi_ThongTinLop> FindAllThongTinLop()
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.vi_ThongTinLops.ToList();
        }

        public void InsertLop(LOP lop)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                db.LOPs.InsertOnSubmit(lop);
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void UpdateLop(LOP lop)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                LOP updateLop = db.LOPs.FirstOrDefault(e => e.MaLop.Equals(lop.MaLop));
                updateLop.TenLop = lop.TenLop;
                updateLop.SL = lop.SL;
                updateLop.HK = lop.HK;
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void DeleteLop(string maLop)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            try
            {
                LOP deleteLop = db.LOPs.FirstOrDefault(e => e.MaLop.Equals(maLop));
                db.LOPs.DeleteOnSubmit(deleteLop);
                db.SubmitChanges();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public List<ft_ThongTinLopTheoHSResult> FindByID_HK_NHvi(string maSV, int hk, int nh)
        {
            QLSinhVienDataContext db = new QLSinhVienDataContext();
            return db.ft_ThongTinLopTheoHS(maSV,hk,nh).ToList();
        }
    }
}
