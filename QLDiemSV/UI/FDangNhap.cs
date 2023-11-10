using QLDiemSV.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSV.UI
{
    public partial class FDangNhap : Form
    {
        TaiKhoanBLL tkBLL = new TaiKhoanBLL(); 
        public FDangNhap()
        {
            InitializeComponent();
        }
        private void btnQuen_Click(object sender, EventArgs e)
        {
            this.Hide();
            FQuenMatKhau fQuenMK = new FQuenMatKhau();
            fQuenMK.ShowDialog();
            this.Show();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            string tk = txtTenTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            if (radQTV.Checked)
            {
                string ma = tkBLL.CheckDangNhap(tk, mk, 0);
                if ("admin".Equals(ma))
                {
                    this.Hide();
                    //FrmQTV frmQTV = new FrmQTV();
                    //frmQTV.ShowDialog();
                    MessageBox.Show("Admin");
                    this.Show();
                    return;
                }
            }
            if (radHV.Checked)
            {
                string ma = tkBLL.CheckDangNhap(tk, mk, 1);
                if (ma != null)
                {
                    this.Hide();
                    //FrmHV frmQTV_HV = new FrmHV(txtTenTaiKhoan.Text);
                    //frmQTV_HV.ShowDialog();
                    MessageBox.Show("SinhVien" + ma);
                    this.Show();
                    return;
                }
            }
            if (radGV.Checked)
            {
                string ma = tkBLL.CheckDangNhap(tk, mk, 2);
                if (ma != null)
                {
                    this.Hide();
                    //FrmHV frmQTV_HV = new FrmHV(txtTenTaiKhoan.Text);
                    //frmQTV_HV.ShowDialog();
                    MessageBox.Show("GiangVien" + ma);
                    this.Show();
                    return;
                }
            }
            //FrmMessageBox frmMessageBox = new FrmMessageBox("Your login information is not correct. Please try again.", "WARNING");
            //DialogResult result = frmMessageBox.ShowDialog();
            MessageBox.Show("DangNhapLai");
        }

        private void cbHide_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHide.Checked)
                txtMatKhau.PasswordChar = '●';
            else
                txtMatKhau.PasswordChar = '\0';
        }
    }
}
