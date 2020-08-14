using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DTO;
namespace QuanLyPhongNet.DAL
{
    public class TheCaoDAL
    {
        QuanLyPhongNetDataContext qlpn = new QuanLyPhongNetDataContext();
        public TheCaoDAL()
        {

        }
        public List<QuanLyPhongNet.DTO.Card> getTheCao()
        {
            return (from card in qlpn.TheCards select new QuanLyPhongNet.DTO.Card { CardID = card.CardID,CardName = card.CardName,CategoryName=card.CategoryName,PriceUnit=(double)card.PriceUnit.GetValueOrDefault(),UnitLot=card.UnitLot,InventoryNumber=card.InventoryNumber.GetValueOrDefault() }).ToList();
        }
        //Lấy Mã tự động
        public string MaTuDong()
        {
            List<QuanLyPhongNet.DTO.Card> dr = getTheCao();
            int dem = 1;
            string ma = "CARD0" + dem;
            foreach (DTO.Card it in dr)
            {

                if (it.CardID.Trim() == ma)
                {

                    dem++;
                    if (dem < 10)
                    {
                        ma = "CARD0" + dem;
                    }
                    else
                    {
                        ma = "CARD" + dem;
                    }
                }
            }
            if (dem < 10)
            {
                return "CARD0" + dem;
            }
            return "CARD" + dem;
        }
        //hàm Insert 
        public void InsertCard(string _Name, string _categoryName, string _priceUnit, string _unitLot, string _inventoryNumber)
        {
            qlpn.TheCards.InsertOnSubmit(new TheCard
            {
                CardID = MaTuDong(),
                CardName = _Name,
                CategoryName = _categoryName,
                PriceUnit = double.Parse(_priceUnit),
                UnitLot = _unitLot,
                InventoryNumber = int.Parse(_inventoryNumber)
            });
            qlpn.SubmitChanges();
        }

        //hàm Update
        public void UpdateCard(string _ID, string _Name, string _categoryName, string _priceUnit, string _unitLot, string _inventoryNumber)
        {
            TheCard _UPDATE = qlpn.TheCards.Where(food => food.CardID == _ID).FirstOrDefault();
            if (_UPDATE != null)
            {
                _UPDATE.CardName = _Name;
                _UPDATE.CategoryName = _categoryName;
                _UPDATE.PriceUnit = double.Parse(_priceUnit);
                _UPDATE.UnitLot = _unitLot;
                _UPDATE.InventoryNumber = int.Parse(_inventoryNumber);
                qlpn.SubmitChanges();
            }
        }

        //hàm Delete
        public void DeleteCard(string _ID)
        {
            TheCard _DELETE = qlpn.TheCards.Where(food => food.CardID == _ID).SingleOrDefault();
            if (_DELETE != null)
            {
                qlpn.TheCards.DeleteOnSubmit(_DELETE);
                qlpn.SubmitChanges();
            }
        }

        //hàm Search theo ID
        public List<QuanLyPhongNet.DTO.Card> getCardOfID(string _ID)
        {
            return (from food in qlpn.TheCards
                    where food.CardID == _ID
                    select new QuanLyPhongNet.DTO.Card
                    {
                        CardID = food.CardID,
                        CardName = food.CardName,
                        CategoryName = food.CategoryName,
                        PriceUnit = (double)food.PriceUnit.GetValueOrDefault(),
                        UnitLot = food.UnitLot,
                        InventoryNumber = food.InventoryNumber.GetValueOrDefault()
                    }).ToList();
        }

        //hàm Search theo Name
        public List<QuanLyPhongNet.DTO.Card> getCardOfName(string _Name)
        {
            return (from food in qlpn.TheCards
                    where food.CardName == _Name
                    select new QuanLyPhongNet.DTO.Card
                    {
                        CardID = food.CardID,
                        CardName = food.CardName,
                        CategoryName = food.CategoryName,
                        PriceUnit = (double)food.PriceUnit.GetValueOrDefault(),
                        UnitLot = food.UnitLot,
                        InventoryNumber = food.InventoryNumber.GetValueOrDefault()
                    }).ToList();
        }
    }
}
