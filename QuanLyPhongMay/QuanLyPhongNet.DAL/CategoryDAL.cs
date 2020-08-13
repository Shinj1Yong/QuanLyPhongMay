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
    }
}
