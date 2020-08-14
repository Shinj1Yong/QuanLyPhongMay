using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DAL;
namespace QuanLyPhongNet.BLL
{
    public class TheCaoBLL
    {
        TheCaoDAL _theCao = new TheCaoDAL();
        public TheCaoBLL()
        {

        }
        //Load toàn bộ
        public List<QuanLyPhongNet.DTO.Card> getAllTheCao()
        {
            return _theCao.getTheCao();
        }
        //Lấy mã tự động 
        public string getMa()
        {
            return _theCao.MaTuDong();
        }
        //Hàm Insert
        public void InsertToCard(string _Name, string _categoryName, string _priceUnit, string _unitLot, string _inventoryNumber)
        {
            _theCao.InsertCard(_Name, _categoryName, _priceUnit, _unitLot, _inventoryNumber);
        }

        //Hàm Update
        public void UpdateCardOf(string _ID, string _Name, string _categoryName, string _priceUnit, string _unitLot, string _inventoryNumber)
        {
            _theCao.UpdateCard(_ID, _Name, _categoryName, _priceUnit, _unitLot, _inventoryNumber);
        }

        //Hàm Delete
        public void DeleteCardOf(string _ID)
        {
            _theCao.DeleteCard(_ID);
        }

        //Load theo ID
        public List<QuanLyPhongNet.DTO.Card> getTheCaoOfID(string _ID)
        {
            return _theCao.getCardOfID(_ID);
        }

        //Load theo Name
        public List<QuanLyPhongNet.DTO.Card> getTheCaoOfName(string _Name)
        {
            return _theCao.getCardOfName(_Name);
        }
    }
}
