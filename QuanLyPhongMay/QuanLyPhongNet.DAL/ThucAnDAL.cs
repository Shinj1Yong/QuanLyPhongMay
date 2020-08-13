using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DTO;
namespace QuanLyPhongNet.DAL
{
    public class ThucAnDAL
    {
        QuanLyPhongNetDataContext qlpn = new QuanLyPhongNetDataContext();
        public ThucAnDAL()
        {

        }
        public List<QuanLyPhongNet.DTO.Food> getThucAn()
        {
            return (from food in qlpn.Foods select new QuanLyPhongNet.DTO.Food { FoodID = food.FoodID, FoodName = food.FoodName, CategoryName = food.CategoryName, PriceUnit = (double) food.PriceUnit.GetValueOrDefault(), UnitLot = food.UnitLot,InventoryNumber=food.InventoryNumber.GetValueOrDefault() }).ToList();
        }

        //Lấy Mã tự động
        public string MaTuDong()
        {
            List<QuanLyPhongNet.DTO.Food> dr = getThucAn();
            int dem = 1;
            string ma = "FOOD0" + dem;
            foreach (DTO.Food it in dr)
            {

                if (it.FoodID.Trim() == ma)
                {

                    dem++;
                    if (dem < 10)
                    {
                        ma = "FOOD0" + dem;
                    }
                    else
                    {
                        ma = "FOOD" + dem;
                    }
                }
            }
            if (dem < 10)
            {
                return "FOOD0" + dem;
            }
            return "FOOD" + dem;
        }

        //hàm Insert 
        public void InsertThucAn(string _Name, string _categoryName, string _priceUnit, string _unitLot, string _inventoryNumber)
        {
            qlpn.Foods.InsertOnSubmit(new Food
             {
                 FoodID = MaTuDong(),
                 FoodName = _Name,
                 CategoryName = _categoryName,
                 PriceUnit = double.Parse(_priceUnit),
                 UnitLot = _unitLot,
                 InventoryNumber = int.Parse(_inventoryNumber)
             });
            qlpn.SubmitChanges();
        }

        //hàm Update
        public void UpdateThucAn(string _ID, string _Name, string _categoryName, string _priceUnit, string _unitLot, string _inventoryNumber)
        {
            Food _UPDATE = qlpn.Foods.Where(food => food.FoodID == _ID).FirstOrDefault();
            if (_UPDATE != null)
            {
                _UPDATE.FoodName = _Name;
                _UPDATE.CategoryName = _categoryName;
                _UPDATE.PriceUnit = double.Parse(_priceUnit);
                _UPDATE.UnitLot = _unitLot;
                _UPDATE.InventoryNumber = int.Parse(_inventoryNumber);
                qlpn.SubmitChanges();
            }
        }
        
        //hàm Delete
        public void DeleteThucAn(string _ID)
        {
            Food _DELETE = qlpn.Foods.Where(food => food.FoodID == _ID).SingleOrDefault();
            if (_DELETE != null)
            {
                qlpn.Foods.DeleteOnSubmit(_DELETE);
                qlpn.SubmitChanges();
            }
        }

        //hàm Search theo ID
        public List<QuanLyPhongNet.DTO.Food> getThucAnOfID(string _ID)
        {
            return (from food in qlpn.Foods
                    where food.FoodID == _ID
                    select new QuanLyPhongNet.DTO.Food 
                    { 
                        FoodID = food.FoodID, 
                        FoodName = food.FoodName, 
                        CategoryName = food.CategoryName, 
                        PriceUnit = (double)food.PriceUnit.GetValueOrDefault(), 
                        UnitLot = food.UnitLot, 
                        InventoryNumber = food.InventoryNumber.GetValueOrDefault()
                    }).ToList();
        }

        //hàm Search theo Name
        public List<QuanLyPhongNet.DTO.Food> getThucAnOfName(string _Name)
        {
            return (from food in qlpn.Foods
                    where food.FoodName == _Name
                    select new QuanLyPhongNet.DTO.Food
                    {
                        FoodID = food.FoodID,
                        FoodName = food.FoodName,
                        CategoryName = food.CategoryName,
                        PriceUnit = (double)food.PriceUnit.GetValueOrDefault(),
                        UnitLot = food.UnitLot,
                        InventoryNumber = food.InventoryNumber.GetValueOrDefault()
                    }).ToList();
        }
    }
}
