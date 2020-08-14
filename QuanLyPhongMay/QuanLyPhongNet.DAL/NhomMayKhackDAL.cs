using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DTO;
namespace QuanLyPhongNet.DAL
{
    public class NhomMayKhackDAL
    {
        QuanLyPhongNetDataContext qlpn = new QuanLyPhongNetDataContext();
        public NhomMayKhackDAL()
        {

        }
        public List<QuanLyPhongNet.DTO.GroupClient> getNhomMayKhach()
        {
            return (from food in qlpn.GroupClients
                    select new QuanLyPhongNet.DTO.GroupClient
                    {
                        GroupClientID = food.GroupClientID,
                        GroupClientName = food.GroupClientName,
                        Description=food.Discription
                    }).ToList();
        }
    }
}
