namespace QuanLyPhongNet.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Client
    {
        private string _clientName;
        private string _statusClient;
        private string _roomID;

        public string ClientName { get => _clientName; set => _clientName = value; }
        public string StatusClient { get => _statusClient; set => _statusClient = value; }
        public string RoomID { get => _roomID; set => _roomID = value; }
    }
}
