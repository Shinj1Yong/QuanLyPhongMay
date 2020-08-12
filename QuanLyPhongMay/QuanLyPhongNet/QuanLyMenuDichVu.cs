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
    public partial class QuanLyMenuDichVu : Form
    {
        ThucAnBLL _thucAnBll = new ThucAnBLL();
        NuocUongBLL _nuocUongBll = new NuocUongBLL();
        TheCaoBLL _theCaoBll = new TheCaoBLL();
        CategoryBLL _category = new CategoryBLL();
        public QuanLyMenuDichVu()
        {
            InitializeComponent();
        }

        private void tabMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMenu.SelectedIndex==0)
            {
                drgvInformation.DataSource = _thucAnBll.getALLThucAn();
                cboFoodCategory.DataSource = _thucAnBll.getCategoryThucAn();
                cboFoodCategory.DisplayMember = "CategoryName";
                
            }
            if (tabMenu.SelectedIndex == 1)
            {
                drgvInformation.DataSource = _nuocUongBll.getAllNuocUong();
                cboDrinkCategory.DataSource = _nuocUongBll.getCategoryNuocUong();
                cboDrinkCategory.DisplayMember = "CategoryName";
                
            }
            if (tabMenu.SelectedIndex == 2)
            {
                drgvInformation.DataSource = _theCaoBll.getAllTheCao();
                cboCardCategory.DataSource = _theCaoBll.getCategoryTheCao();
                cboCardCategory.DisplayMember = "CategoryName";
                
            }
        }

        private void QuanLyMenuDichVu_Load(object sender, EventArgs e)
        {
            drgvInformation.DataSource = _thucAnBll.getALLThucAn();
            cboSearch.DataSource = _category.getAllCategory();
            cboSearch.DisplayMember = "CategoryName";
        }

        private void picSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
