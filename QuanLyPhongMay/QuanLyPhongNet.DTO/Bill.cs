namespace QuanLyPhongNet.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Bill
    {
        private string _billID;
        private string _foundedUserID;
        private DateTime _foundedDate;
        private double _priceTotal;

        public string BillID { get => _billID; set => _billID = value; }
        public string FoundedUserID { get => _foundedUserID; set => _foundedUserID = value; }
        public DateTime FoundedDate { get => _foundedDate; set => _foundedDate = value; }
        public double PriceTotal { get => _priceTotal; set => _priceTotal = value; }
    }
}
