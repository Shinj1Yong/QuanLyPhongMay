namespace QuanLyPhongNet.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Drink
    {
        private string _drinkID;
        private string _drinkName;
        private string _categoryName;
        private double _priceUnit;
        private string _unitLot;
        private int _inventoryNumber;

        public string DrinkID { get => _drinkID; set => _drinkID = value; }
        public string DrinkName { get => _drinkName; set => _drinkName = value; }
        public string CategoryName { get => _categoryName; set => _categoryName = value; }
        public double PriceUnit { get => _priceUnit; set => _priceUnit = value; }
        public string UnitLot { get => _unitLot; set => _unitLot = value; }
        public int InventoryNumber { get => _inventoryNumber; set => _inventoryNumber = value; }
    }
}
