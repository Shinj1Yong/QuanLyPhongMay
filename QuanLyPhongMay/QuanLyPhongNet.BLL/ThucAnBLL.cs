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
        
        //Load toàn bộ
        public List<QuanLyPhongNet.DTO.Food> getALLThucAn()
        {
           return _thucAn.getThucAn();
        }
        
        //Lấy mã tự động 
        public string getMa()
        {
            return _thucAn.MaTuDong();
        }

        //Hàm Insert
        public void InsertToThucAn(string _Name, string _categoryName, string _priceUnit, string _unitLot, string _inventoryNumber)
        {
            _thucAn.InsertThucAn(_Name, _categoryName, _priceUnit, _unitLot, _inventoryNumber);
        }

        //Hàm Update
        public void UpdateThucAnOf(string _ID, string _Name, string _categoryName, string _priceUnit, string _unitLot, string _inventoryNumber)
        {
            _thucAn.UpdateThucAn(_ID ,_Name, _categoryName, _priceUnit, _unitLot, _inventoryNumber);
        }

        //Hàm Delete
        public void DeleteThucAnOf(string _ID)
        {
            _thucAn.DeleteThucAn(_ID);
        }

        //Load theo ID
        public List<QuanLyPhongNet.DTO.Food> getThucAnOfID(string _ID)
        {
            return _thucAn.getThucAnOfID(_ID);
        }

        //Load theo Name
        public List<QuanLyPhongNet.DTO.Food> getThucAnOfName(string _Name)
        {
            return _thucAn.getThucAnOfName(_Name);
        }
    }
}
