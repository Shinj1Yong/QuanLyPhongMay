namespace QuanLyPhongNet.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User
    {
        private string _userID;
        private string _userName;
        private string _groupUserID;
        private string _phoneNumber;
        private string _email;

        public string UserID { get => _userID; set => _userID = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string GroupUserID { get => _groupUserID; set => _groupUserID = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Email { get => _email; set => _email = value; }
    }
}
