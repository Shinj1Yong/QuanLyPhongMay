using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DTO;
namespace QuanLyPhongNet.DAL
{
    public class NhomMayKhachDAL
    {
        QuanLyPhongNetDataContext qlpn = new QuanLyPhongNetDataContext();
        public NhomMayKhachDAL()
        {

        }
        public List<QuanLyPhongNet.DTO.GroupClient> getNhomMayKhach()
        {
            return (from food in qlpn.GroupClients
                    select new QuanLyPhongNet.DTO.GroupClient
                    {
                        GroupClientID = food.GroupClientID,
                        GroupClientName = food.GroupClientName,
                        Description = food.Description,
                    }).ToList();
        }
        //hàm Insert 
        public void InsertGClient(string _groupID, string _groupClientName,string _description)
        {
            qlpn.GroupClients.InsertOnSubmit(new GroupClient
            {
                GroupClientID = _groupID,
                GroupClientName = _groupClientName,
                Description = _description,
            });
            qlpn.SubmitChanges();
        }

        //hàm Update
        public void UpdateGClient(string _groupID, string _groupClientName, string _description)
        {
            GroupClient _UPDATE = qlpn.GroupClients.Where(food => food.GroupClientID == _groupID).FirstOrDefault();
            if (_UPDATE != null)
            {

                _UPDATE.GroupClientName = _groupClientName;
                _UPDATE.Description = _description;
                qlpn.SubmitChanges();
            }
        }

        //hàm Delete
        public void DeleteGClient(string _groupID)
        {
            GroupClient _DELETE = qlpn.GroupClients.Where(food => food.GroupClientID == _groupID).SingleOrDefault();
            if (_DELETE != null)
            {
                qlpn.GroupClients.DeleteOnSubmit(_DELETE);
                qlpn.SubmitChanges();
            }
        }
        //Hàm check tồn tại
        public bool KT_TK(string _ID)
        {
            List<QuanLyPhongNet.DTO.GroupClient> lst = (from tk in qlpn.GroupClients where tk.GroupClientID == _ID select new QuanLyPhongNet.DTO.GroupClient { GroupClientID= tk.GroupClientID,GroupClientName=tk.GroupClientName,Description=tk.Description}).ToList();
            if (lst.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
