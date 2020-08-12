using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DAL;
namespace QuanLyPhongNet.BLL
{
   
    public class ThucAnBLL
    {
        ThucAnDAL _thucAn = new ThucAnDAL();
       
        public ThucAnBLL()
        {

        }
        public List<QuanLyPhongNet.DTO.Food> getALLThucAn()
        {
           return _thucAn.getThucAn();
        }
        public List<QuanLyPhongNet.DTO.Food> getCategoryThucAn()
        {
            return _thucAn.getCategoryThucAn();
        }
    }
}
