namespace QuanLyPhongNet.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GroupClient
    {
        private string _groupClientID;
        private string _groupClientName;
        private string _description;

        public string GroupClientID { get => _groupClientID; set => _groupClientID = value; }
        public string GroupClientName { get => _groupClientName; set => _groupClientName = value; }
        public string Description { get => _description; set => _description = value; }
    }
}
