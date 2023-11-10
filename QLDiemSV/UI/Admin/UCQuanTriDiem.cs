using QLDiemSV.BLL;
using QLDiemSV.UI.Student;
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
    public partial class UCQuanTriDiem : UserControl
    {
        DiemBLL diemBLL = new DiemBLL();
        public UCQuanTriDiem()
        {
            InitializeComponent();
        }

        private void UCQuanTriDiem_Load(object sender, EventArgs e)
        {
            this.gvDiemLop.DataSource = diemBLL.FindDiemSVTheoLop();
            this.gvDiemMon.DataSource = diemBLL.FindDiemSVTheoMon();
            gvDiemLop.ScrollBars = ScrollBars.Both;
            gvDiemMon.ScrollBars = ScrollBars.Both;
        }

        private void pbSua_Click(object sender, EventArgs e)
        {
            DIEM diem = diemBLL.FindDiemByID(txtMaSV.Text, txtMaLop.Text);
            if(txtDiemQT.Text !="")
                diem.DiemQT = decimal.Parse(txtDiemQT.Text);
            if (txtDiemCK.Text != "")
                diem.DiemCK = decimal.Parse(txtDiemCK.Text);
            diemBLL.UpdateDiem(diem);

            UCQuanTriDiem_Load(sender, e);
        }

        private void pbXoa_Click(object sender, EventArgs e)
        {
            DIEM diem = diemBLL.FindDiemByID(txtMaSV.Text, txtMaLop.Text);
            diemBLL.DeleteDiem(diem);
        }

        private void LamSach()
        {
            txtMaSV.Clear();
            txtTenSV.Clear();
            txtMaLop.Clear();
            txtLop.Clear();
            txtDiemQT.Clear();
            txtDiemCK.Clear();
        }

        private void gvDiemLop_DoubleClick(object sender, EventArgs e)
        {
            LamSach();
            lblMaLop.Text = "Mã lớp";
            lblTenLop.Text = "Tên lớp";


            txtMaSV.Text = gvDiemLop.CurrentRow.Cells[0].Value.ToString();
            txtTenSV.Text = gvDiemLop.CurrentRow.Cells[1].Value.ToString();
            txtMaLop.Text = gvDiemLop.CurrentRow.Cells[2].Value.ToString();
            txtLop.Text = gvDiemLop.CurrentRow.Cells[3].Value.ToString();

            if(gvDiemLop.CurrentRow.Cells[4].Value != null)
                txtDiemQT.Text = gvDiemLop.CurrentRow.Cells[4].Value.ToString();
            if(gvDiemLop.CurrentRow.Cells[5].Value != null)
            txtDiemCK.Text = gvDiemLop.CurrentRow.Cells[5].Value.ToString();
        }

        private void gvDiemMon_DoubleClick(object sender, EventArgs e)
        {
            LamSach();
            lblMaLop.Text = "Mã môn";
            lblTenLop.Text = "Tên môn";

            txtMaSV.Text = gvDiemMon.CurrentRow.Cells[0].Value.ToString();
            txtTenSV.Text = gvDiemMon.CurrentRow.Cells[1].Value.ToString();
            txtMaLop.Text = gvDiemMon.CurrentRow.Cells[2].Value.ToString();
            txtLop.Text = gvDiemMon.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
