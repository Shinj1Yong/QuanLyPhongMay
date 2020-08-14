using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DTO;
using QuanLyPhongNet.DAL;
namespace QuanLyPhongNet.BLL
{
    public class NhanSuBLL
    {
        NhanSuDAL _nhanSu = new NhanSuDAL();
        public NhanSuBLL()
        {

        }
        //Load toàn bộ
        public List<QuanLyPhongNet.DTO.User> getALLNhanSu()
        {
            return _nhanSu.getNhanSu();
        }
        public string getMa()
        {
            return _nhanSu.MaTuDong();
        }
    }
}
