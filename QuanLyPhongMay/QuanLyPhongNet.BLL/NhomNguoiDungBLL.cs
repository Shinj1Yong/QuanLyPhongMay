using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DTO;
using QuanLyPhongNet.DAL;
namespace QuanLyPhongNet.BLL
{
    public class NhomNguoiDungBLL
    {
        NhomNguoiDungDAL _nhomNguoiDung = new NhomNguoiDungDAL();
        public NhomNguoiDungBLL()
        {

        }
        //Load toàn bộ
        public List<QuanLyPhongNet.DTO.GroupUser> getALLNhomNguoiDung()
        {
            return _nhomNguoiDung.getNhomNguoiDung() ;
        }
    }
}
