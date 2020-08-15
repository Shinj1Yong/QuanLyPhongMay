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
namespace QuanLyPhongNet
{
    public partial class ThemThanhVien : Form
    {
        ThanhVienBLL _tvbll = new ThanhVienBLL();
        public ThemThanhVien()
        {
            InitializeComponent();
        }
        private void ThemThanhVien_Load(object sender, EventArgs e)
        {
            txtSDT.Focus();
            txtAddMoney.Text = "0";
            
            
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
            if(txtSDT.Text.Length == 10)
            {
                grbTimeManager.Enabled = true;
            }
            else
            {
                grbTimeManager.Enabled = false;
            }
        }

        public string tinhTime(string tongTien)
        {
            int gioChoi = int.Parse(tongTien.ToString()) / (int) 5000;
            float phutChoi = float.Parse(tongTien.ToString()) % (float) 5000 * (float) 60;

            return gioChoi + ":" + phutChoi;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            float tongTien = float.Parse(txtCurrentMoney.Text) + float.Parse(txtAddMoney.Text);
            if (txtSDT.Text.Length == 10)
            {
                if(_tvbll.KT_TK(txtSDT.Text))
                {
                    _tvbll.UpdateMember(txtSDT.Text, txtPass.Text, "Member", tinhTime(tongTien.ToString()), tongTien.ToString(), true.ToString());
                    MessageBox.Show("Sửa thành công");
                    this.Close();
                }
                else
                {
                    _tvbll.InsertToMember(txtSDT.Text, txtName.Text, txtPass.Text, "Member", tinhTime(txtAddMoney.Text), txtAddMoney.Text, true.ToString());
                    MessageBox.Show("Thêm thành công");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Số điện thoại phải có 10 số");
                return;
            }
        }
    }
}
