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
        CategoryDAL category = new CategoryDAL();
        public CategoryBLL()
        {
            
        }
        public List<QuanLyPhongNet.DTO.Category> getAllCategory()
        {
            return category.getCategory();
        }
    }
}
