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
        private const int TAB_FOOD = 0;
        private const int TAB_DRINK = 1;
        private const int TAB_CARD = 2;
        private const int TAB_CATEGORY = 3;
        public QuanLyMenuDichVu()
        {
            InitializeComponent();
        }

        private void Load_ComboBox()
        {
            cboFoodCategory.DataSource = _category.getAllCategory();
            cboFoodCategory.DisplayMember = "CategoryName";
            cboFoodCategory.ValueMember = "CategoryName";
            cboDrinkCategory.DataSource = _category.getAllCategory();
            cboDrinkCategory.DisplayMember = "CategoryName";
            cboDrinkCategory.ValueMember = "CategoryName";
            cboCardCategory.DataSource = _category.getAllCategory();
            cboCardCategory.DisplayMember = "CategoryName";
            cboCardCategory.ValueMember = "CategoryName";
        }

        private void Load_GridView()
        {
            switch (tabMenu.SelectedIndex)
            {
                case TAB_FOOD:
                    drgvInformation.DataSource = _thucAnBll.getALLThucAn();
                    drgvInformation.Columns[0].HeaderText = "Mã Định Danh";
                    drgvInformation.Columns[0].Width = 100;
                    drgvInformation.Columns[1].HeaderText = "Tên Món Ăn";
                    drgvInformation.Columns[2].HeaderText = "Thuộc Loại";
                    drgvInformation.Columns[3].HeaderText = "Đơn Giá";
                    drgvInformation.Columns[4].HeaderText = "Đơn Vị Tính";
                    drgvInformation.Columns[5].HeaderText = "Số Lượng Tồn";
                    break;
                case TAB_DRINK:
                    drgvInformation.DataSource = _nuocUongBll.getAllNuocUong();
                    drgvInformation.Columns[0].HeaderText = "Mã Định Danh";
                    drgvInformation.Columns[0].Width = 100;
                    drgvInformation.Columns[1].HeaderText = "Tên Nước Uống";
                    drgvInformation.Columns[2].HeaderText = "Thuộc Loại";
                    drgvInformation.Columns[3].HeaderText = "Đơn Giá";
                    drgvInformation.Columns[4].HeaderText = "Đơn Vị Tính";
                    drgvInformation.Columns[5].HeaderText = "Số Lượng Tồn";
                    break;
                case TAB_CARD:
                    drgvInformation.DataSource = _theCaoBll.getAllTheCao();
                    drgvInformation.Columns[0].HeaderText = "Mã Định Danh";
                    drgvInformation.Columns[0].Width = 100;
                    drgvInformation.Columns[1].HeaderText = "Tên Thẻ";
                    drgvInformation.Columns[2].HeaderText = "Thuộc Loại";
                    drgvInformation.Columns[3].HeaderText = "Đơn Giá";
                    drgvInformation.Columns[4].HeaderText = "Đơn Vị Tính";
                    drgvInformation.Columns[5].HeaderText = "Số Lượng Tồn";
                    break;
                case TAB_CATEGORY:
                    drgvInformation.DataSource = _category.getAllCategory();
                    drgvInformation.Columns[0].HeaderText = "Tên Loại Danh Mục";
                    break;
            }
            drgvInformation.ClearSelection();
            drgvInformation.Refresh();
            Load_ComboBox();
           
        }
        private bool CheckValidInput(TabPage currentTAB)
        {
            int countFilled = currentTAB.Controls.OfType<TextBox>().Count(x => string.IsNullOrEmpty(x.Text));
            if (countFilled > 0)
                return false;
            return true;
        }
        private void ResetControl(TabPage currentTAB)
        {
            foreach (Control c in currentTAB.Controls)
            {
                if (c is TextBox)
                    (c as TextBox).ResetText();
                else if (c is ComboBox)
                {
                    (c as ComboBox).Text = "--Lựa Chọn--";
                    (c as ComboBox).ForeColor = Color.Blue;
                }
            }
        }
        private void tabMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_ComboBox();
            Load_GridView();
        }

        private void QuanLyMenuDichVu_Load(object sender, EventArgs e)
        {
            //drgvInformation.DataSource = _thucAnBll.getALLThucAn();
            //cboSearch.DataSource = _category.getAllCategory();
            //cboSearch.DisplayMember = "CategoryName";
            Load_ComboBox();
            Load_GridView();
            closeGiaoDien("GiaoDienTuyChon");

        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                Load_ComboBox();
                Load_GridView();
            }
            else
            {
                SearchProcess(txtSearch.Text);
            }
            
        }
        private void AddProcess()
        {
            TabPage tp = tabMenu.SelectedTab;
            if (!CheckValidInput(tp))
            {
                MessageBox.Show("Chưa điền đầy đủ thông tin!");
                return;
            }
            switch (tabMenu.SelectedIndex)
            {
                case TAB_FOOD:
                    _thucAnBll.InsertToThucAn(txtFoodName.Text, cboFoodCategory.SelectedValue.ToString(), txtPriceUnitOfFood.Text, txtUnitLotOfFood.Text, txtInventoryNumberOfFood.Text);
                    break;
                case TAB_DRINK:
                    _nuocUongBll.InsertToNuocUong(txtDrinkName.Text, cboDrinkCategory.Text, txtPriceUnitOfDrink.Text, txtUnitLotOfDrink.Text, txtInventoryNumberOfDrink.Text);
                    break;
                case TAB_CARD:
                    _theCaoBll.InsertToCard(txtCardName.Text, cboCardCategory.Text, txtPriceUnitOfCard.Text, txtUnitLotOfCard.Text, txtInventoryNumberOfCard.Text);
                    break;
                case TAB_CATEGORY:
                    _category.InsertCategory(txtCategoryName.Text);
                    break;
            }
            ResetControl(tp);
            Load_GridView();
            Load_ComboBox();
            MessageBox.Show("Thêm thành công!");
        }

        public void UpdateProcess(string _ID)
        {
            TabPage tp = tabMenu.SelectedTab;
            switch (tabMenu.SelectedIndex)
            {
                case TAB_FOOD:
                    _thucAnBll.UpdateThucAnOf(_ID, txtFoodName.Text, cboFoodCategory.SelectedValue.ToString(), txtPriceUnitOfFood.Text, txtUnitLotOfFood.Text, txtInventoryNumberOfFood.Text);
                    break;
                case TAB_DRINK:
                    _nuocUongBll.UpdateNuocUongOf(_ID, txtDrinkName.Text, cboDrinkCategory.SelectedValue.ToString(), txtPriceUnitOfDrink.Text, txtUnitLotOfDrink.Text, txtInventoryNumberOfDrink.Text);
                    break;
                case TAB_CARD:
                    _theCaoBll.UpdateCardOf(_ID, txtCardName.Text, cboCardCategory.SelectedValue.ToString(), txtPriceUnitOfCard.Text, txtUnitLotOfCard.Text, txtInventoryNumberOfCard.Text);
                    break;
                case TAB_CATEGORY:
                    _category.UpdateCategory(_ID, txtCategoryName.Text);
                    break;
            }
            ResetControl(tp);
            Load_ComboBox();
            Load_GridView();
            MessageBox.Show("Sửa thành công");
        }

        public void DeleteProcess(string _ID)
        {
            if (MessageBox.Show("Bạn muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                TabPage tp = tabMenu.SelectedTab;
                switch (tabMenu.SelectedIndex)
                {
                    case TAB_FOOD:
                        _thucAnBll.DeleteThucAnOf(_ID);
                        break;
                    case TAB_DRINK:
                        _nuocUongBll.DeleteNuocUongOf(_ID);
                        break;
                    case TAB_CARD:
                        _theCaoBll.DeleteCardOf(_ID);
                        break;
                    case TAB_CATEGORY:
                        _category.DeleteCategory(_ID);
                        break;
                }
                ResetControl(tp);
                Load_ComboBox();
                Load_GridView();
                MessageBox.Show("Xóa thành công!");
            }
        }

        public void SearchProcess(string _ID)
        {
            TabPage tp = tabMenu.SelectedTab;
            switch (tabMenu.SelectedIndex)
            {
                case TAB_FOOD:
                    {
                        if(cboSearch.Text.ToString() == "Tên Sản Phẩm")
                        {
                            drgvInformation.DataSource = _thucAnBll.getThucAnOfName(_ID);
                        }
                        else if (cboSearch.Text.ToString() == "Mã")
                        {
                            drgvInformation.DataSource = _thucAnBll.getThucAnOfID(_ID);
                        }
                    }
                    break;
                case TAB_DRINK:
                    {
                        if (cboSearch.Text.ToString() == "Tên Sản Phẩm")
                        {
                            drgvInformation.DataSource = _nuocUongBll.getNuocUongOfName(_ID);
                        }
                        else if (cboSearch.Text.ToString() == "Mã")
                        {
                            drgvInformation.DataSource = _nuocUongBll.getNuocUongOfName(_ID);
                        }
                    }
                    break;
                case TAB_CARD:
                    {
                        if (cboSearch.Text.ToString() == "Tên Sản Phẩm")
                        {
                            drgvInformation.DataSource = _theCaoBll.getTheCaoOfID(_ID);
                        }
                        else if (cboSearch.Text.ToString() == "Mã")
                        {
                            drgvInformation.DataSource = _theCaoBll.getTheCaoOfName(_ID);
                        }
                    }
                    break;
                case TAB_CATEGORY:

                    break;
            }
            ResetControl(tp);
        }
        private void picAdd_Click(object sender, EventArgs e)
        {
            AddProcess();

        }

        private void picUpdate_Click(object sender, EventArgs e)
        {
            UpdateProcess(drgvInformation.CurrentRow.Cells[0].Value.ToString());
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            DeleteProcess(drgvInformation.CurrentRow.Cells[0].Value.ToString());
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            
        }

        public void OnlyNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtPriceUnitOfFood_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumber(sender,e);
        }

        private void txtInventoryNumberOfFood_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumber(sender, e);
        }

        private void txtPriceUnitOfDrink_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumber(sender, e);
        }

        private void txtInventoryNumberOfDrink_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumber(sender, e);
        }

        private void txtPriceUnitOfCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumber(sender, e);
        }

        private void txtInventoryNumberOfCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumber(sender, e);
        }

        private void drgvInformation_SelectionChanged(object sender, EventArgs e)
        {

            switch (tabMenu.SelectedIndex)
            {

                case TAB_FOOD:
                    {

                        txtFoodName.Text = drgvInformation.CurrentRow.Cells[1].Value.ToString();
                        cboFoodCategory.Text = drgvInformation.CurrentRow.Cells[2].Value.ToString();
                        txtPriceUnitOfFood.Text = drgvInformation.CurrentRow.Cells[3].Value.ToString();
                        txtInventoryNumberOfFood.Text = drgvInformation.CurrentRow.Cells[5].Value.ToString();
                        txtUnitLotOfFood.Text = drgvInformation.CurrentRow.Cells[4].Value.ToString();
                        break;
                    }
                    
                case TAB_DRINK:
                    {

                        txtDrinkName.Text = drgvInformation.CurrentRow.Cells[1].Value.ToString();
                        cboDrinkCategory.Text = drgvInformation.CurrentRow.Cells[2].Value.ToString();
                        txtPriceUnitOfDrink.Text = drgvInformation.CurrentRow.Cells[3].Value.ToString();
                        txtInventoryNumberOfDrink.Text = drgvInformation.CurrentRow.Cells[5].Value.ToString();
                        txtUnitLotOfDrink.Text = drgvInformation.CurrentRow.Cells[4].Value.ToString();
                        break;
                    }
                case TAB_CARD:
                    {

                        txtCardName.Text = drgvInformation.CurrentRow.Cells[1].Value.ToString();
                        cboCardCategory.Text = drgvInformation.CurrentRow.Cells[2].Value.ToString();
                        txtPriceUnitOfCard.Text = drgvInformation.CurrentRow.Cells[3].Value.ToString();
                        txtInventoryNumberOfCard.Text = drgvInformation.CurrentRow.Cells[5].Value.ToString();
                        txtUnitLotOfCard.Text = drgvInformation.CurrentRow.Cells[4].Value.ToString();
                        break;
                    }
                case TAB_CATEGORY:
                    {

                        txtCategoryName.Text = drgvInformation.CurrentRow.Cells[0].Value.ToString();
                        break;
                    }
                    
            }
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

        private void llblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            openGiaoDien("GiaoDienTuyChon");
        }

        private void lblLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
           // exitGiaoDien("GiaoDienTuyChon");
            openGiaoDien("GiaoDienDangNhap");
        }

        private void QuanLyMenuDichVu_FormClosing(object sender, FormClosingEventArgs e)
        {
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
