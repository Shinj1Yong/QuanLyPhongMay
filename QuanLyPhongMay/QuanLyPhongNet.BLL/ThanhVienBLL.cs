﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongNet.DAL;
using QuanLyPhongNet.DTO;
namespace QuanLyPhongNet.BLL
{
    public class ThanhVienBLL
    {
        ThanhVienDAL _thanhVien = new ThanhVienDAL();

        public ThanhVienBLL()
        {

        }
        //Load toàn bộ
        public List<QuanLyPhongNet.DTO.Member> getALLThanhVien()
        {
            return _thanhVien.getMember();
        }
        //Hàm Insert
        public void InsertToMember(string _PhoneNumber, string _Account, string _Password, string _groupUser, string _currentTime, string _currentMoney, string _statusAcc)
        {
            _thanhVien.InsertMember(_PhoneNumber,_Account,_Password,_groupUser,_currentTime,_currentMoney,Convert.ToBoolean(_statusAcc));
        }

        //Hàm Update
        public void UpdateMember(string _PhoneNumber, string _Password, string _groupUser, string _currentTime, string _currentMoney, string _statusAcc)
        {
            _thanhVien.UpdateMember(_PhoneNumber,_Password, _groupUser, _currentTime, _currentMoney, Convert.ToBoolean(_statusAcc));
        }

        //Hàm Delete
        public void DeleteMember(string _PhoneNumber)
        {
            _thanhVien.DeleteMember(_PhoneNumber);
        }

        public bool KT_TK(string _sdt)
        {
            return _thanhVien.KT_TK(_sdt);
        }
        public List<DTO.Member>timTheoTen(string _tenMember)
        {
           return _thanhVien.getMemBerOfID(_tenMember);
        }
    }
}
