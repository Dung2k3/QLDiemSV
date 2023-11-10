﻿using QLDiemSV.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSV.UI.Admin
{
    public partial class UCQuanTriGV : UserControl
    {
        GiangVienBLL giangvien = new GiangVienBLL();
        KhoaBLL khoaBLL = new KhoaBLL();
        public UCQuanTriGV()
        {
            InitializeComponent();
        }

        private void UCQuanTriGV_Load(object sender, EventArgs e)
        {
            this.gvGiangVien.DataSource = giangvien.FindAllThongTinGV();
            gvGiangVien.ScrollBars = ScrollBars.Both;

            cmbKhoa.DataSource = khoaBLL.FindAllKhoa();
            cmbKhoa.DisplayMember = "TenKhoa";
            cmbKhoa.ValueMember = "MaKhoa";
        }
        private void pbXoa_Click(object sender, EventArgs e)
        {
            GIANGVIEN gv = giangvien.FindGiangVienByID(txtMaGV.Text);
            giangvien.DeleteGiangVien(gv);
            UCQuanTriGV_Load(sender, e);
        }

        private void pbThem_Click(object sender, EventArgs e)
        {
                FInsertGV form = new FInsertGV();
                form.ShowDialog();
                UCQuanTriGV_Load(sender, e);
        }

        private void pbSua_Click(object sender, EventArgs e)
        {
                FUpdateGV form = new FUpdateGV(txtMaGV.Text);
                form.ShowDialog();
                UCQuanTriGV_Load(sender, e);
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvGiangVien.DataSource = giangvien.FindThongTinGiangVienByMaKhoa(cmbKhoa.Text);
            gvGiangVien.ScrollBars = ScrollBars.Both;
        }

        private void gvGiangVien_DoubleClick(object sender, EventArgs e)
        {
            txtMaGV.Text = gvGiangVien.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = gvGiangVien.CurrentRow.Cells[1].Value.ToString();
            txtCMND.Text = gvGiangVien.CurrentRow.Cells[2].Value.ToString();
            txtDiaChi.Text = gvGiangVien.CurrentRow.Cells[3].Value.ToString();
            txtGioiTinh.Text = gvGiangVien.CurrentRow.Cells[4].Value.ToString();
            dtpNgaySinh.Text = gvGiangVien.CurrentRow.Cells[5].Value.ToString();
            txtSDT.Text = gvGiangVien.CurrentRow.Cells[6].Value.ToString();
            txtEmail.Text = gvGiangVien.CurrentRow.Cells[7].Value.ToString();
            txtKhoa.Text = gvGiangVien.CurrentRow.Cells[8].Value.ToString();
            txtLoaiGV.Text = gvGiangVien.CurrentRow.Cells[10].Value.ToString();

            gvLopGV.DataSource = giangvien.FindLopGVDay(txtMaGV.Text);
            gvGiangVien.ScrollBars = ScrollBars.Both;
        }
    }
}
