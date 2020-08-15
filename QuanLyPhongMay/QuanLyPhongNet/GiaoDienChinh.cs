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

namespace QuanLyPhongNet
{
    public partial class GiaoDienChinh : Form
    {
        MayKhachBLL _maykhach = new MayKhachBLL();
        ThanhVienBLL _thanhvien = new ThanhVienBLL();
        NhomMayKhachBLL _nhomMay = new NhomMayKhachBLL();
        ThucAnBLL _thucAnBll = new ThucAnBLL();
        NuocUongBLL _nuocUongBll = new NuocUongBLL();
        TheCaoBLL _theCaoBll = new TheCaoBLL();
        NhomNguoiDungBLL _nhomNguoiDung = new NhomNguoiDungBLL();
        NhanSuBLL _nhanSu = new NhanSuBLL();
        public GiaoDienChinh()
        {
            InitializeComponent();
        }

        private void Load_GridView()
        {
            drgvClient.DataSource = _maykhach.getALLMayKhach();
            drgvMember.DataSource = _thanhvien.getALLThanhVien();
            drgvClientGroup.DataSource = _nhomMay.getALLNhomMayKhach();
            drgvFood.DataSource = _thucAnBll.getALLThucAn();
            drgvDrink.DataSource = _nuocUongBll.getAllNuocUong();
            drgvCard.DataSource = _theCaoBll.getAllTheCao();
            drgvUserGroup.DataSource = _nhomNguoiDung.getALLNhomNguoiDung();
            drgvStaff.DataSource = _nhanSu.getALLNhanSu();
        }
        private void picOpenClient_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void GiaoDienChinh_Load(object sender, EventArgs e)
        {
            Load_GridView();
        }

        private void picAddMember_Click(object sender, EventArgs e)
        {
            ThemThanhVien frmAddMember = new ThemThanhVien();
            frmAddMember.ShowDialog();
        }

        private void picDeleteMember_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xóa tài khoản không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                _thanhvien.DeleteMember(drgvMember.CurrentRow.Cells[0].Value.ToString());
            }
            picUpdateMember_Click(sender, e);
        }

        private void drgvClient_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void drgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void picUpdateMember_Click(object sender, EventArgs e)
        {
            drgvMember.DataSource = _thanhvien.getALLThanhVien();
        }

        private void drgvMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSuaOfTaiKhoan_Click(object sender, EventArgs e)
        {
            ThemThanhVien frmAddMember = new ThemThanhVien();
            
            frmAddMember.txtSDT.Text = drgvMember.CurrentRow.Cells[0].Value.ToString();
            frmAddMember.txtName.Text = drgvMember.CurrentRow.Cells[1].Value.ToString();
            frmAddMember.txtPass.Text = drgvMember.CurrentRow.Cells[2].Value.ToString();
            frmAddMember.txtCurrentMoney.Text = drgvMember.CurrentRow.Cells[5].Value.ToString();
            frmAddMember.txtAddMoney.Text = "0";
            frmAddMember.grbTimeManager.Enabled = true;
            frmAddMember.ShowDialog();
        }

        private void picOrder_Click(object sender, EventArgs e)
        {

        }
    }
}
