using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DTO;
using QuanLyPhongNet.DAL;
namespace QuanLyPhongNet.BLL
{
    public class NhomMayKhachBLL
    {
        NhomMayKhachDAL _nhomMay = new NhomMayKhachDAL();
        public NhomMayKhachBLL()
        {

        }
        //Load toàn bộ
        public List<QuanLyPhongNet.DTO.GroupClient> getALLNhomMayKhach()
        {
            return _nhomMay.getNhomMayKhach();
        }
    }
}
