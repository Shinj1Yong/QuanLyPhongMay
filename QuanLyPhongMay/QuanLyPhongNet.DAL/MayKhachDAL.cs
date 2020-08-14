using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DTO;
namespace QuanLyPhongNet.DAL
{
    public class MayKhachDAL
    {
        QuanLyPhongNetDataContext qlpn = new QuanLyPhongNetDataContext();
        public MayKhachDAL()
        {

        }
        public List<QuanLyPhongNet.DTO.Client> getMayKhach()
        {
            return (from food in qlpn.Clients
                    select new QuanLyPhongNet.DTO.Client
                    {
                        ClientName = MaTuDong(),
                        StatusClient = food.StatusClient,
                        RoomID = food.RoomID
                    }).ToList();
        }
        //Lấy Mã tự động
        public string MaTuDong()
        {
            List<QuanLyPhongNet.DTO.Client> dr = getMayKhach();
            int dem = 1;
            string ma = "MAY0" + dem;
            foreach (DTO.Client it in dr)
            {

                if (it.ClientName.Trim() == ma)
                {

                    dem++;
                    if (dem < 10)
                    {
                        ma = "MAY0" + dem;
                    }
                    else
                    {
                        ma = "MAY" + dem;
                    }
                }
            }
            if (dem < 10)
            {
                return "MAY0" + dem;
            }
            return "MAY" + dem;
        }
    }
}
