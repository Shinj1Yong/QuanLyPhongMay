using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DTO;
namespace QuanLyPhongNet.DAL
{
    public class NuocUongDAL
    {
        QuanLyPhongNetDataContext qlpn = new QuanLyPhongNetDataContext();
        public NuocUongDAL()
        {

        }

        public string MaTuDong()
        {
            List<QuanLyPhongNet.DTO.Drink> dr = getNuocUong();
            int dem = 1;
            string ma = "DRINK0" + dem;
            foreach (DTO.Drink it in dr)
            {
                
                if (it.DrinkID.Trim() == ma)
                {
                    
                    dem++;
                    if(dem<10)
                    {
                        ma = "DRINK0" + dem;
                    }
                    else
                    {
                        ma = "DRINK" + dem;
                    }
                }
            }
            if(dem<10)
            {
                return "DRINK0" + dem;
            }
            return "DRINK" + dem;
            
        }
        public List<QuanLyPhongNet.DTO.Drink> getNuocUong()
        {
            return (from drink in qlpn.Drinks select new QuanLyPhongNet.DTO.Drink {DrinkID=drink.DrinkID, DrinkName=drink.DrinkName,CategoryName=drink.CategoryName,PriceUnit=(double)drink.PriceUnit.GetValueOrDefault(),UnitLot=drink.UnitLot,InventoryNumber=drink.InventoryNumber.GetValueOrDefault() }).ToList();
        }
        //hàm Insert 
        public void InsertNuocUong(string _Name, string _categoryName, string _priceUnit, string _unitLot, string _inventoryNumber)
        {
            qlpn.Drinks.InsertOnSubmit(new Drink
            {
                DrinkID = MaTuDong(),
                DrinkName = _Name,
                CategoryName = _categoryName,
                PriceUnit = double.Parse(_priceUnit),
                UnitLot = _unitLot,
                InventoryNumber = int.Parse(_inventoryNumber)
            });
            qlpn.SubmitChanges();
        }

        //hàm Update
        public void UpdateNuocUong(string _ID, string _Name, string _categoryName, string _priceUnit, string _unitLot, string _inventoryNumber)
        {
            Drink _UPDATE = qlpn.Drinks.Where(food => food.DrinkID == _ID).FirstOrDefault();
            if (_UPDATE != null)
            {
                _UPDATE.DrinkName = _Name;
                _UPDATE.CategoryName = _categoryName;
                _UPDATE.PriceUnit = double.Parse(_priceUnit);
                _UPDATE.UnitLot = _unitLot;
                _UPDATE.InventoryNumber = int.Parse(_inventoryNumber);
                qlpn.SubmitChanges();
            }
        }

        //hàm Delete
        public void DeleteNuocUong(string _ID)
        {
            Drink _DELETE = qlpn.Drinks.Where(food => food.DrinkID == _ID).SingleOrDefault();
            if (_DELETE != null)
            {
                qlpn.Drinks.DeleteOnSubmit(_DELETE);
                qlpn.SubmitChanges();
            }
        }

        //hàm Search theo ID
        public List<QuanLyPhongNet.DTO.Drink> getNuocUongOfID(string _ID)
        {
            return (from food in qlpn.Drinks
                    where food.DrinkID == _ID
                    select new QuanLyPhongNet.DTO.Drink
                    {
                        DrinkID = food.DrinkID,
                        DrinkName = food.DrinkName,
                        CategoryName = food.CategoryName,
                        PriceUnit = (double)food.PriceUnit.GetValueOrDefault(),
                        UnitLot = food.UnitLot,
                        InventoryNumber = food.InventoryNumber.GetValueOrDefault()
                    }).ToList();
        }

        //hàm Search theo Name
        public List<QuanLyPhongNet.DTO.Drink> getNuocUongOfName(string _Name)
        {
            return (from food in qlpn.Drinks
                    where food.DrinkName == _Name
                    select new QuanLyPhongNet.DTO.Drink
                    {
                        DrinkID = food.DrinkID,
                        DrinkName = food.DrinkName,
                        CategoryName = food.CategoryName,
                        PriceUnit = (double)food.PriceUnit.GetValueOrDefault(),
                        UnitLot = food.UnitLot,
                        InventoryNumber = food.InventoryNumber.GetValueOrDefault()
                    }).ToList();
        }
    }
}
