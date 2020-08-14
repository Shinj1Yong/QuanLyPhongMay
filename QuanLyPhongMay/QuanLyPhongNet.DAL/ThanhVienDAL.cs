using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DTO;
namespace QuanLyPhongNet.DAL
{
    public class ThanhVienDAL
    {
        QuanLyPhongNetDataContext qlpn = new QuanLyPhongNetDataContext();
        public ThanhVienDAL()
        {

        }
        public List<QuanLyPhongNet.DTO.Member> getMember()
        {
            return (from food in qlpn.Members select new QuanLyPhongNet.DTO.Member
            {
                PhoneNumber = food.PhoneNumber,
                AccountName = food.AccountName,
                Password = food.Password,
                GroupUserID = food.GroupUserID,
                CurrentTime=(TimeSpan)food.CurrentTime,
                CurrentMoney=(float)food.CurrentMoney,
                StatusAccount=(bool)food.StatusAccount
            }).ToList();
        }
        //hàm Insert 
        public void InsertMember(string _PhoneNumber, string _Account, string _Password, string _groupUser, TimeSpan _currentTime,float _currentMoney,bool _statusAcc)
        {
            qlpn.Members.InsertOnSubmit(new Member
            {
                PhoneNumber = _PhoneNumber,
                AccountName = _Account,
                Password = _Password,
                GroupUserID = _groupUser,
                CurrentTime =_currentTime,
                CurrentMoney = _currentMoney,
                StatusAccount=_statusAcc
             });
            qlpn.SubmitChanges();
        }

        //hàm Update
        public void UpdateMember(string _PhoneNumber, string _Account, string _Password, string _groupUser, TimeSpan _currentTime, float _currentMoney, bool _statusAcc)
        {
            Member _UPDATE = qlpn.Members.Where(food => food.PhoneNumber == _PhoneNumber).FirstOrDefault();
            if (_UPDATE != null)
            {
                _UPDATE.AccountName = _Account;
                _UPDATE.Password = _Password;
                _UPDATE.GroupUserID = _groupUser;
                _UPDATE.CurrentTime = _currentTime;
                _UPDATE.CurrentMoney = _currentMoney;
                _UPDATE.StatusAccount = _statusAcc;
                qlpn.SubmitChanges();
            }
        }
        
        //hàm Delete
        public void DeleteMember(string _PhoneNumber)
        {
            Member _DELETE = qlpn.Members.Where(food => food.PhoneNumber == _PhoneNumber).SingleOrDefault();
            if (_DELETE != null)
            {
                qlpn.Members.DeleteOnSubmit(_DELETE);
                qlpn.SubmitChanges();
            }
        }
    }
}
