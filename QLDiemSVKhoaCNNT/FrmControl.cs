using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSVKhoaCNNT
{
    public partial class FrmControl : Form
    {
        private Form currentFormChild;
        public FrmControl()
        {
            InitializeComponent();
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(childForm);
            pnlBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pbxUTELogo_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLSinhVien());
            lblTitle.Text = "Sinh Viên";
        }

        private void btnGiangVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLGiaoVien());
            lblTitle.Text = "Giảng Viên";
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLMonHoc());
            lblTitle.Text = "Môn Học";
        }

        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLLopHoc());
            lblTitle.Text = "Lớp Học";
        }
    }
}
