using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DAL;
namespace QuanLyPhongNet.BLL
{
    public class NuocUongBLL
    {
        NuocUongDAL _drink = new NuocUongDAL();
        public NuocUongBLL()
        {

        }
        //Load toàn bộ
        public List<QuanLyPhongNet.DTO.Drink> getAllNuocUong()
        {
            return _drink.getNuocUong();
        }
        //Lấy mã tự động 
        public string getMa()
        {
            return _drink.MaTuDong();
        }

        //Hàm Insert
        public void InsertToNuocUong(string _Name, string _categoryName, string _priceUnit, string _unitLot, string _inventoryNumber)
        {
            _drink.InsertNuocUong(_Name, _categoryName, _priceUnit, _unitLot, _inventoryNumber);
        }

        //Hàm Update
        public void UpdateNuocUongOf(string _ID, string _Name, string _categoryName, string _priceUnit, string _unitLot, string _inventoryNumber)
        {
            _drink.UpdateNuocUong(_ID, _Name, _categoryName, _priceUnit, _unitLot, _inventoryNumber);
        }

        //Hàm Delete
        public void DeleteNuocUongOf(string _ID)
        {
            _drink.DeleteNuocUong(_ID);
        }

        //Load theo ID
        public List<QuanLyPhongNet.DTO.Drink> getNuocUongOfID(string _ID)
        {
            return _drink.getNuocUongOfID(_ID);
        }

        //Load theo Name
        public List<QuanLyPhongNet.DTO.Drink> getNuocUongOfName(string _Name)
        {
            return _drink.getNuocUongOfName(_Name);
        }
    }
}
