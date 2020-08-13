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
        
    }
}
