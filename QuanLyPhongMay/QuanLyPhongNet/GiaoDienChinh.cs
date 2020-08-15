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
        private void picOpenClient_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void GiaoDienChinh_Load(object sender, EventArgs e)
        {
            Load_GridView();
            closeGiaoDien("GiaoDienTuyChon");
        }

        private void GiaoDienChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            openGiaoDien("GiaoDienTuyChon");
        }

        private void lblLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
           // exitGiaoDien("GiaoDienTuyChon");
            openGiaoDien("GiaoDienDangNhap");
        }

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            openGiaoDien("GiaoDienTuyChon");
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

        private void picAddMember_Click_1(object sender, EventArgs e)
        {
            ThemThanhVien addMem = new ThemThanhVien();
            addMem.ShowDialog();
        }

        private void picDeleteMember_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                _thanhvien.DeleteMember(drgvMember.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picUpdateMember_Click_1(object sender, EventArgs e)
        {
            ThemThanhVien addMem = new ThemThanhVien();
            addMem.ShowDialog();
        }

        private void picSearchMember_Click(object sender, EventArgs e)
        {
          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (cboSearchType.SelectedIndex)
            {
                case 0:
                  drgvMember.DataSource=_thanhvien.timTheoTen(txtSearchOfMember.Text);
                    break;
               
            }
        }

        private void pSuaNhomMay_Click(object sender, EventArgs e)
        {
            AddNhomMay nm = new AddNhomMay();
            nm.ShowDialog();
        }

        private void pXoaNhomMay_Click(object sender, EventArgs e)
        {
            try
            {
                _nhomMay.DeleteNhomMay(drgvClientGroup.CurrentRow.Cells[0].Value.ToString());
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picOrder_Click_1(object sender, EventArgs e)
        {
            GiaoDienGoiDichVu goidv = new GiaoDienGoiDichVu();
            switch (tabCategory.SelectedIndex)
            {
                case 0:
                    goidv.txtName.Text = drgvFood.CurrentRow.Cells[0].Value.ToString();
                    goidv.txtPrice.Text = drgvFood.CurrentRow.Cells[3].Value.ToString();
                    goidv.txtUnit.Text = drgvFood.CurrentRow.Cells[4].Value.ToString();
                    goidv.txtGroupName.Text = drgvFood.CurrentRow.Cells[2].Value.ToString();
                    goidv.textBox5.Text = drgvFood.CurrentRow.Cells[5].Value.ToString();
                    goidv.ShowDialog();
                    break;
                case 1:
                    goidv.txtName.Text = drgvDrink.CurrentRow.Cells[0].Value.ToString();
                    goidv.txtPrice.Text = drgvDrink.CurrentRow.Cells[3].Value.ToString();
                    goidv.txtUnit.Text = drgvDrink.CurrentRow.Cells[4].Value.ToString();
                    goidv.txtGroupName.Text = drgvDrink.CurrentRow.Cells[2].Value.ToString();
                    goidv.textBox5.Text = drgvDrink.CurrentRow.Cells[5].Value.ToString();
                    goidv.ShowDialog();
                    break;
                case 2:
                    goidv.txtName.Text = drgvCard.CurrentRow.Cells[0].Value.ToString();
                    goidv.txtPrice.Text = drgvCard.CurrentRow.Cells[3].Value.ToString();
                    goidv.txtUnit.Text = drgvCard.CurrentRow.Cells[4].Value.ToString();
                    goidv.txtGroupName.Text = drgvCard.CurrentRow.Cells[2].Value.ToString();
                    goidv.textBox5.Text = drgvCard.CurrentRow.Cells[5].Value.ToString();
                    goidv.ShowDialog();
                    break;
            }
            
        }
    }
}
