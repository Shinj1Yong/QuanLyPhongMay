using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DTO;
using QuanLyPhongNet.DAL;
namespace QuanLyPhongNet.BLL
{
    public class MayKhachBLL
    {
        MayKhachDAL _mayKhach = new MayKhachDAL();
        public MayKhachBLL()
        {

        }
        //Load toàn bộ
        public List<QuanLyPhongNet.DTO.Client> getALLMayKhach()
        {
            return _mayKhach.getMayKhach();
        }

        ////Lấy mã tự động 
        //public string getMa()
        //{
        //    return _mayKhach.MaTuDong();
        //}

    }
}
