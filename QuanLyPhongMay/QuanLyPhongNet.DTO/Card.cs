namespace QuanLyPhongNet.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Card
    {
        private string _cardID;
        private string _cardName;
        private string _categoryName;
        private double _priceUnit;
        private string _unitLot;
        private int _inventoryNumber;

        public string CardID { get => _cardID; set => _cardID = value; }
        public string CardName { get => _cardName; set => _cardName = value; }
        public string CategoryName { get => _categoryName; set => _categoryName = value; }
        public double PriceUnit { get => _priceUnit; set => _priceUnit = value; }
        public string UnitLot { get => _unitLot; set => _unitLot = value; }
        public int InventoryNumber { get => _inventoryNumber; set => _inventoryNumber = value; }
    }
}
