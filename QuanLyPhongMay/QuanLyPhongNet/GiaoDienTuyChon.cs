using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongNet
{
    public partial class GiaoDienTuyChon : Form
    {
        public GiaoDienTuyChon()
        {
            InitializeComponent();
        }

        private void GiaoDienTuyChon_Load(object sender, EventArgs e)
        {
            closeGiaoDien("GiaoDienDangNhap");
        }
        public void closeGiaoDien(string formname)
        {
             FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
               if (frm.Name == formname)
               {
                    frm.Visible = false;
               }
            }
            
        }
        public void openGiaoDien(string formname)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == formname)
                {
                    frm.Visible = true;
                }
            }

        }

        private void llblSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            openGiaoDien("GiaoDienDangNhap");
            
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            GiaoDienChinh gdc = new GiaoDienChinh();
            gdc.Show();
           
        }

        private void picCategory_Click(object sender, EventArgs e)
        {
            QuanLyMenuDichVu gdmenu = new QuanLyMenuDichVu();
            gdmenu.Show();
        }

        private void picReport_Click(object sender, EventArgs e)
        {

        }
    }
}
