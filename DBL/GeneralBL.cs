using DBL.Entities;
using DBL.Enum;
using DBL.Helpers;
using DBL.Models;
using DBL.UOW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBL
{
    public class GeneralBL
    {
        private UnitOfWork db;
        private string _connString;
        Randomnumbergenerator random = new Randomnumbergenerator();
        public string LogFile { get; set; }
        EncryptDecrypt sec = new EncryptDecrypt();
        public GeneralBL(string connString)
        {
            this._connString = connString;
            db = new UnitOfWork(connString);
        }
        #region Login 
        public Task<UserModel> Login(string userName, string password)
        {
            return Task.Run(() =>
            {
                UserModel userModel = new UserModel { };
                var resp = db.SecurityRepository.Login(userName);
                if (resp.RespStatus == 0)
                {
                    EncryptDecrypt sec = new EncryptDecrypt();
                    string enccpass = sec.Encrypt(password);
                    string descpass = sec.Decrypt(resp.Data4);

                    if (password == descpass)
                    {
                        userModel = new UserModel
                        {
                            Subcode = Convert.ToInt64(resp.Data1),
                            Fullname = resp.Data2,
                            PhoneNo = resp.Data3,
                            Email = resp.Data6,
                            profilecode = Convert.ToInt32(resp.Data7),
                            Tenantcode = Convert.ToInt64(resp.Data11),
                            connId=resp.Data8,
                            connKey=resp.Data9,
                            connData=resp.Data10,
                        };
                        return userModel;
                    }
                    else
                    {
                        userModel.RespStatus = 1;
                        userModel.RespMessage = "Incorrect Password!";
                    }
                }
                else
                {
                    userModel.RespStatus = 1;
                    userModel.RespMessage = "Incorrect Password!";
                }

                return userModel;
            });
        }
        #endregion

        #region Station Staffs
        public async Task<IEnumerable<Permisions>> Getpermissionsdata()
        {
            return await Task.Run(() =>
            {
                var Resp = db.SecurityRepository.Getpermissionsdata();
                return Resp;
            });
        }
        public async Task<GenericModel> Addnewtenantstaff(Tenantstaffs obj)
        {
            return await Task.Run(() =>
            {
                obj.Staffpass = sec.Encrypt(random.GenerateRandomPass().ToString());
                obj.Staffpin = sec.Encrypt(random.GenerateRandomPin().ToString());
                var Resp = db.SecurityRepository.Addnewtenantstaff(obj);
                return Resp;
            });
        }
        #endregion

        #region DropDown Methods
        public Task<IEnumerable<ListModel>> GetListModel(ListModelType listType)
        {
            return Task.Run(() =>
            {
                return db.SecurityRepository.GetListModel(listType);
            });
        }
        #endregion



    }
}
