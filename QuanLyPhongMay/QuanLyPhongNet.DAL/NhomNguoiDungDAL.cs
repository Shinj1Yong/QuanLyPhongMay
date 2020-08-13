using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DTO;
namespace QuanLyPhongNet.DAL
{
    public class NhomNguoiDungDAL
    {
        QuanLyPhongNetDataContext qlpn = new QuanLyPhongNetDataContext();
        public NhomNguoiDungDAL()
        {

        }
        public List<QuanLyPhongNet.DTO.GroupUser> getNhomNguoiDung()
        {
            return (from kh in qlpn.GroupUsers
                    select new QuanLyPhongNet.DTO.GroupUser
                    {
                        GroupUserName = kh.GroupName,
                        TypeName = kh.TypeName
                    }
                    ).ToList();
        }
    }
}
