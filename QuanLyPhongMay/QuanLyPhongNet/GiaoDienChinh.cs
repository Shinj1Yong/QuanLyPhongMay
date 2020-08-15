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
    }
}
