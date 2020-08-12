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
            return (from kh in qlpn.Foods select new QuanLyPhongNet.DTO.Food { FoodID = kh.FoodID, Name = kh.FoodName, CategoryName = kh.CategoryName, PriceUnit = kh.PriceUnit.GetValueOrDefault(), UnitLot = kh.UnitLot,InventoryNumber=kh.InventoryNumber.GetValueOrDefault() }).ToList();
        }
        public List<QuanLyPhongNet.DTO.Food> getCategoryThucAn()
        {
            return (from kh in qlpn.Foods select new QuanLyPhongNet.DTO.Food { CategoryName = kh.CategoryName}).ToList();
        }
    }
}
