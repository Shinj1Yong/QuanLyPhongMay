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
       
    }
}
