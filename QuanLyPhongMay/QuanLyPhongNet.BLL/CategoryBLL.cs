using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DAL;
namespace QuanLyPhongNet.BLL
{
    public class CategoryBLL
    {
        CategoryDAL _category = new CategoryDAL();
        public CategoryBLL()
        {
            
        }
        public List<QuanLyPhongNet.DTO.Category> getAllCategory()
        {
            return _category.getCategory();
        }
        //Hàm Insert
        public void InsertCategory(string _Name)
        {
            _category.InsertCategory(_Name);
        }

        //Hàm Update
        public void UpdateCategory(string _oldName, string _Name)
        {
            _category.UpdateCategory(_oldName, _Name);
        }

        //Hàm Delete
        public void DeleteCategory(string _ID)
        {
            _category.DeleteThucAn(_ID);
        }

     
    }
}
