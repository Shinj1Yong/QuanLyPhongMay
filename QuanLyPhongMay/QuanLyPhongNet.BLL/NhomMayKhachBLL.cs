using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DTO;
using QuanLyPhongNet.DAL;
namespace QuanLyPhongNet.BLL
{
    public class NhomMayKhachBLL
    {
        NhomMayKhachDAL _nhomMay = new NhomMayKhachDAL();
        public NhomMayKhachBLL()
        {

        }
        //Load toàn bộ
        public List<QuanLyPhongNet.DTO.GroupClient> getALLNhomMayKhach()
        {
            return _nhomMay.getNhomMayKhach();
        }
        //Hàm Insert
        public void InsertToNhomMay(string _groupID, string _groupClientName, string _description)
        {
            _nhomMay.InsertGClient(_groupID,  _groupClientName, _description);
        }

        //Hàm Update
        public void UpdateNhomMay(string _groupID, string _groupClientName, string _description)
        {
            _nhomMay.UpdateGClient(_groupID, _groupClientName, _description);
        }

        //Hàm Delete
        public void DeleteNhomMay(string _groupID)
        {
            _nhomMay.DeleteGClient(_groupID);
        }
        public bool kt_TK(string _id)
        {
            return _nhomMay.KT_TK(_id);
        }
    }
}
