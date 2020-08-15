using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongNet.BLL;
using QuanLyPhongNet.DTO;
namespace QuanLyPhongNet
{
    public partial class GiaoDienDangNhap : Form
    {
        NhanSuBLL _nhansu = new NhanSuBLL();
        public GiaoDienDangNhap()
        {
            InitializeComponent();
        }

        private void GiaoDienDangNhap_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
        
            cboUser.DataSource = _nhansu.getALLNhanSu();
            cboUser.DisplayMember = "UserName";
            cboUser.ValueMember = "UserID";
        }
        public void exitGiaoDien(string formname)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == formname)
                {
                    frm.Close();
                }
            }

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_nhansu.kiemTraDangNhap(cboUser.SelectedValue.ToString(), txtPassword.Text))
            {
                GiaoDienTuyChon gd = new GiaoDienTuyChon();
                gd.Show();

            }
            else
            {
                MessageBox.Show("Sai mật khẩu");
            }
        }

        private void GiaoDienDangNhap_VisibleChanged(object sender, EventArgs e)
        {
          
        }
    }
}
