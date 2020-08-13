namespace QuanLyPhongNet.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GroupUser
    {
        private string _groupUserID;
        private string groupUserName;

        public string GroupUserID { get => _groupUserID; set => _groupUserID = value; }
        public string GroupUserName { get => groupUserName; set => groupUserName = value; }
    }
}
