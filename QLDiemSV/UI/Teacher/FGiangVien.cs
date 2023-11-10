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

namespace QLDiemSV.UI.Teacher
{
    
    public partial class FGiangVien : Form
    {
        public Form currentFormChild;
        GiangVienBLL gvBLL = new GiangVienBLL();
        public FGiangVien()
        {
            InitializeComponent();
        }
        private void FThongTinGiangVien_Load(object sender, EventArgs e)
        {

        }
        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            UCThongTinGV ucTTGV = new UCThongTinGV(gvBLL.FindGiangVienByID("1500001"));
            pnlNoiDung.Controls.Add(ucTTGV);
        }
        private void btnTKB_Click_1(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            UCThoiKhoaBieuGV ucTKBGV = new UCThoiKhoaBieuGV(gvBLL.FindGiangVienByID("1500001"));
            pnlNoiDung.Controls.Add(ucTKBGV);
        }
        private void btnXemDiem_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            UCXemDiemGV ucXemDiem = new UCXemDiemGV(gvBLL.FindGiangVienByID("1500001"));
            pnlNoiDung.Controls.Add(ucXemDiem);
        }
    }
}
