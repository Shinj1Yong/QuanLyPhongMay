using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DAL;
namespace QuanLyPhongNet.BLL
{
    public class NuocUongBLL
    {
        NuocUongDAL drink = new NuocUongDAL();
        public NuocUongBLL()
        {

        }
        public List<QuanLyPhongNet.DTO.Drink> getAllNuocUong()
        {
            return drink.getNuocUong();
        }
        public List<QuanLyPhongNet.DTO.Drink> getCategoryNuocUong()
        {
            return drink.getCategoryNuocUong();
        }
    }
}
