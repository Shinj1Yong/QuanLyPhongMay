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
        public List<QuanLyPhongNet.DTO.Drink> getNuocUong()
        {
            return (from kh in qlpn.Drinks select new QuanLyPhongNet.DTO.Drink {DrinkID=kh.DrinkID, Name=kh.DrinkName,CategoryName=kh.CategoryName,PriceUnit=(float)kh.PriceUnit.GetValueOrDefault(),UnitLot=kh.UnitLot,InventoryNumber=kh.InventoryNumber.GetValueOrDefault() }).ToList();
        }
        public List<QuanLyPhongNet.DTO.Drink> getCategoryNuocUong()
        {
            return (from kh in qlpn.Drinks select new QuanLyPhongNet.DTO.Drink { CategoryName = kh.CategoryName.First().ToString() }).ToList();
        }
    }
}
