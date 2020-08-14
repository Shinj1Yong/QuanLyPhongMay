using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DTO;
namespace QuanLyPhongNet.DAL
{
    public class NhanSuDAL
    {
        QuanLyPhongNetDataContext qlpn = new QuanLyPhongNetDataContext();
        public NhanSuDAL()
        {

        }
        public List<QuanLyPhongNet.DTO.User> getNhanSu()
        {
            return (from food in qlpn.TheUsers select new QuanLyPhongNet.DTO.User
            {
                UserID = food.UserID,
                UserName=food.UserName,
                GroupUserID=food.GroupUserID,
                PhoneNumber=food.PhoneNumber,
                Email=food.Email
            }).ToList();
        }
        //Lấy Mã tự động
        public string MaTuDong()
        {
            List<QuanLyPhongNet.DTO.User> dr = getNhanSu();
            int dem = 1;
            string ma = "STAFF0" + dem;
            foreach (DTO.User it in dr)
            {

                if (it.UserID.Trim() == ma)
                {

                    dem++;
                    if (dem < 10)
                    {
                        ma = "STAFF0" + dem;
                    }
                    else
                    {
                        ma = "STAFF" + dem;
                    }
                }
            }
            if (dem < 10)
            {
                return "STAFF0" + dem;
            }
            return "STAFF" + dem;
        }

    }
}
