using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DAL;
namespace QuanLyPhongNet.BLL
{
    public class TheCaoBLL
    {
        TheCaoDAL theCao = new TheCaoDAL();
        public TheCaoBLL()
        {

        }
        public List<QuanLyPhongNet.DTO.Card> getAllTheCao()
        {
            return theCao.getTheCao();
        }
       
    }
}
