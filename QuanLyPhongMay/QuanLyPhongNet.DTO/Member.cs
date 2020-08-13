namespace QuanLyPhongNet.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Member
    {
        private string _phoneNumber;
        private string _accountName;
        private string _password;
        private string _groupUserID;
        private TimeSpan _currentTime;
        private double _currentMoney;
        private bool _statusAccount;

        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string AccountName { get => _accountName; set => _accountName = value; }
        public string Password { get => _password; set => _password = value; }
        public string GroupUserID { get => _groupUserID; set => _groupUserID = value; }
        public TimeSpan CurrentTime { get => _currentTime; set => _currentTime = value; }
        public double CurrentMoney { get => _currentMoney; set => _currentMoney = value; }
        public bool StatusAccount { get => _statusAccount; set => _statusAccount = value; }
    }
}
