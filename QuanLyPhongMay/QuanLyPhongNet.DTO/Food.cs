namespace QuanLyPhongNet.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Food
    {
        private string _foodID;
        private string _foodName;
        private string _categoryName;
        private double _priceUnit;
        private string _unitLot;
        private int _inventoryNumber;

        public string FoodID { get => _foodID; set => _foodID = value; }
        public string FoodName { get => _foodName; set => _foodName = value; }
        public string CategoryName { get => _categoryName; set => _categoryName = value; }
        public double PriceUnit { get => _priceUnit; set => _priceUnit = value; }
        public string UnitLot { get => _unitLot; set => _unitLot = value; }
        public int InventoryNumber { get => _inventoryNumber; set => _inventoryNumber = value; }
    }
}
