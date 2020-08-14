using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongNet.DAL
{
    public class CategoryDAL
    {
        QuanLyPhongNetDataContext qlpn = new QuanLyPhongNetDataContext();
        public CategoryDAL()
        {

        }
        public List<QuanLyPhongNet.DTO.Category> getCategory()
        {
            return (from category in qlpn.Categories select new QuanLyPhongNet.DTO.Category { CategoryName = category.CategoryName }).ToList();
        }
        //hàm Insert 
        public void InsertCategory(string _categoryName)
        {
            qlpn.Categories.InsertOnSubmit(new Category
            {
                CategoryName = _categoryName
            });
            qlpn.SubmitChanges();
        }

        //hàm Update
        public void UpdateCategory(string _oldName,string _Name)
        {
            Category _UPDATE = qlpn.Categories.Where(food => food.CategoryName == _oldName).FirstOrDefault();
            if (_UPDATE != null)
            {
                _UPDATE.CategoryName = _Name;
                qlpn.SubmitChanges();
            }
        }

        //hàm Delete
        public void DeleteThucAn(string _ID)
        {
            Category _DELETE = qlpn.Categories.Where(food => food.CategoryName == _ID).SingleOrDefault();
            if (_DELETE != null)
            {
                qlpn.Categories.DeleteOnSubmit(_DELETE);
                qlpn.SubmitChanges();
            }
        }
    }
}
