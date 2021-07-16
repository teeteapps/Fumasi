using Dapper;
using DBL.Entities;
using DBL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DBL.Repositories
{
    public class AgreementRepository:BaseRepository,IAgreementRepository
    {
        public AgreementRepository(string connectionString) : base(connectionString)
        {
        }
         

        #region One Off Agreement
        public GenericModel Addnewoneoffagreement(Customeroneoffagreement entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Tenantcode", entity.Custcode);
               
                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                return connection.Query<GenericModel>("Usp_AddnewCustomers", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Recurrent Agreement
        public GenericModel Addnewrecurrentagreement(Customerrecurrentagreement entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Tenantcode", entity.Custcode);

                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                return connection.Query<GenericModel>("Usp_AddnewCustomers", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Prepaid Agreement
        public GenericModel Addnewprepaidagreement(Customerprepaidagreement entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Customercode", entity.Customercode);
                parameters.Add("@Agreementdesc", entity.Agreementdesc);
                parameters.Add("@Agreementtypecode", entity.Typecode);
                parameters.Add("@Pricelistcode", entity.Pricelistcode);
                parameters.Add("@Discountlistcode", entity.Discountlistcode);
                parameters.Add("@Loyaltycode", entity.Loyoltycode);
                parameters.Add("@Billingbasis", entity.Billingbasis);
                parameters.Add("@Agreementdoc", entity.Agreementdoc);
                parameters.Add("@Notes", entity.Notes);
                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                return connection.Query<GenericModel>("Usp_Addnewprepaidagreement", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public Viewcustomeragreements Getagreementdata(long Agreementcode)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                return connection.Query<Viewcustomeragreements>(FindStatementraw(Viewcustomeragreements.TableName, "Agreementcode"), param: new { Id = Agreementcode }).FirstOrDefault();
            }
        }
        public IEnumerable<Viewcustomeragreements> Gettenantcustomerprepaidagreementdata(long Customercode)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                return connection.Query<Viewcustomeragreements>(FindStatementraw(Viewcustomeragreements.TableName, "Customercode"), param: new { Id = Customercode }).ToList();
            }
        }

        #endregion

        #region Agreement Accounts
        public GenericModel Addnewagreementaccount(Customeragreementaccount entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Agreementcode", entity.Agreementcode);
                parameters.Add("@Loyaltycode", entity.Loyaltycode);
                parameters.Add("@Parentcode", entity.Parentcode);
                parameters.Add("@Credittype", entity.Credittype);
                parameters.Add("@Cardtypecode", entity.Cardtypecode);
                parameters.Add("@Mask", entity.Mask);
                parameters.Add("@Limittype", entity.Limittype);
                parameters.Add("@Limitvalue", entity.Limitvalue);
                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                return connection.Query<GenericModel>("Usp_Addcustomeraccount", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public IEnumerable<Vwagreementaccounts> Getagreementaccountsdata(long Agreementcode)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                return connection.Query<Vwagreementaccounts>(FindStatementraw(Vwagreementaccounts.TableName, "Agreementcode"), param: new { Id = Agreementcode }).ToList();
            }
        }

        #endregion

        #region Agreement Account and Account Policies
        #region Account Identifiers
        public GenericModel Addnewaccountidentifier(Customeragreementaccountidentifiers entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Accountcode", entity.Accountcode);
                parameters.Add("@Identifiertype", entity.Identifiertype);
                parameters.Add("@Identifiersno", entity.Identifiersno);
                parameters.Add("@Identifieruid", entity.Identifieruid);
                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                return connection.Query<GenericModel>("Usp_Addnewaccountidentifier", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion
        #region Account Employee
        public GenericModel Addnewaccountemployee(Customeragreementaccountemployees entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Accountcode", entity.Accountcode);
                parameters.Add("@Firstname", entity.Firstname);
                parameters.Add("@Lastname", entity.Lastname);
                parameters.Add("@Phonenumber", entity.Phonenumber);
                parameters.Add("@Emailaddress", entity.Emailaddress);
                parameters.Add("@Drivercode", entity.Drivercode);
                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                return connection.Query<GenericModel>("Usp_Addnewaccountidemployee", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion
        #endregion
    }
}
