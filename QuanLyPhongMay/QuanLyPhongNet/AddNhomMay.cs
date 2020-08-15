using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongNet.DTO;
using QuanLyPhongNet.BLL;
using QuanLyPhongNet.DAL;
namespace QuanLyPhongNet
{
    public partial class AddNhomMay : Form
    {
        NhomMayKhachBLL _nhommay = new NhomMayKhachBLL();
        public AddNhomMay()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_nhommay.kt_TK(txtID.Text)==true)
            {
                _nhommay.UpdateNhomMay(txtID.Text,txtName.Text,txtMieuTa.Text);
                MessageBox.Show("Sửa thành công");
                this.Close();
            }
            else
            {
                _nhommay.InsertToNhomMay(txtID.Text, txtName.Text, txtMieuTa.Text);
                MessageBox.Show("Thêm thành công");
                this.Close();
            }
        }
    }
}
