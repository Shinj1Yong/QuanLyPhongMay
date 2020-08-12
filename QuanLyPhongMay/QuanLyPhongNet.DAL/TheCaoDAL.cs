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
            return (from kh in qlpn.TheCards select new QuanLyPhongNet.DTO.Card { CardID = kh.CardID,Name=kh.CardName,CategoryName=kh.CategoryName,PriceUnit=(float)kh.PriceUnit.GetValueOrDefault(),UnitLot=kh.UnitLot,InventoryNumber=kh.InventoryNumber.GetValueOrDefault() }).ToList();
        }
        public List<QuanLyPhongNet.DTO.Card> getCategoryTheCao()
        {
            return (from kh in qlpn.TheCards select new QuanLyPhongNet.DTO.Card { CategoryName = kh.CategoryName.First().ToString() }).ToList();
        }
    }
}
