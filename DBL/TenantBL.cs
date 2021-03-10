using DBL.Entities;
using DBL.Enum;
using DBL.Helpers;
using DBL.Models;
using DBL.UOW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class TenantBL
    {
        private UnitOfWork db;
        private string _connString;
        private string _tenantconnString;
        Randomnumbergenerator random = new Randomnumbergenerator();
        public string LogFile { get; set; }
        EncryptDecrypt sec = new EncryptDecrypt();
        public TenantBL(string tenantconnString)
        {
            this._tenantconnString = tenantconnString;
            db = new UnitOfWork(tenantconnString);
        }

        #region Tenant stations
        public async Task<IEnumerable<Tenanttationdata>> Gettenenatstationslist()
        {
            return await Task.Run(() =>
            {
                var Resp = db.StationRepository.Gettenenatstationslist();
                return Resp;
            });
        }
        public async Task<GenericModel> Addnewtenantstation(Stations obj)
        {
            return await Task.Run(() =>
            {
                var Resp = db.StationRepository.Addnewtenantstation(obj);
                return Resp;
            });
        }
        public async Task<Stations> GetStationdetaildata(long stationcode)
        {
            return await Task.Run(() =>
            {
                var Resp = db.StationRepository.GetStationdetaildata(stationcode);
                return Resp;
            });
        }
        #endregion

        #region Customers
        public async Task<IEnumerable<Vwtenantcustomers>> Getcustomersdata()
        {
            return await Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Getcustomersdata();
                return Resp;
            });
        }
        public async Task<GenericModel> AddnewCustomers(Tenantcustomers obj)
        {
            return await Task.Run(() =>
            {
                obj.Customerpass = sec.Encrypt(random.GenerateRandomPass().ToString());
                obj.Customerpin = sec.Encrypt(random.GenerateRandomPin().ToString());
                var Resp = db.CustomerRepository.AddnewCustomers(obj);
                return Resp;
            });
        }
        public async Task<Vwtenantcustomers> Gettenantcustomerdata(long Customercode)
        {
            return await Task.Run(() =>
            {
                var Resp = db.CustomerRepository.Gettenantcustomerdata(Customercode);
                return Resp;
            });
        }
        #endregion

        #region Agreements
        #region Prepaid Agreement
        public async Task<GenericModel> Addnewprepaidagreement(Customerprepaidagreement obj)
        {
            return await Task.Run(() =>
            {
                var Resp = db.AgreementRepository.Addnewprepaidagreement(obj);
                return Resp;
            });
        }
        public async Task<IEnumerable<Customerprepaidagreementdata>> Gettenantcustomerprepaidagreementdata(long Customercode)
        {
            return await Task.Run(() =>
            {
                var Resp = db.AgreementRepository.Gettenantcustomerprepaidagreementdata(Customercode);
                return Resp;
            });
        }
        #endregion
        #endregion

        #region Agreement Accounts
        public async Task<GenericModel> Addnewagreementaccount(Customeragreementaccount obj)
        {
            return await Task.Run(() =>
            {
                var Resp = db.AgreementRepository.Addnewagreementaccount(obj);
                return Resp;
            });
        }
        public async Task<IEnumerable<Vwagreementaccounts>> Getagreementaccountsdata(long Agreementcode)
        {
            return await Task.Run(() =>
            {
                var Resp = db.AgreementRepository.Getagreementaccountsdata(Agreementcode);
                return Resp;
            });
        }
        #endregion

        #region Agreement account and Account policies
        #region Account Identifiers
        public async Task<GenericModel> Addnewaccountidentifier(Customeragreementaccountidentifiers obj)
        {
            return await Task.Run(() =>
            {
                var Resp = db.AgreementRepository.Addnewaccountidentifier(obj);
                return Resp;
            });
        }
        #endregion
        #region Account Employee
        public async Task<GenericModel> Addnewaccountemployee(Customeragreementaccountemployees obj)
        {
            return await Task.Run(() =>
            {
                obj.Drivercode = sec.Encrypt(random.GenerateRandomPin().ToString());
                var Resp = db.AgreementRepository.Addnewaccountemployee(obj);
                return Resp;
            });
        }
        #endregion
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
