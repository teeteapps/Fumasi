using Dapper;
using DBL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DBL.Repositories
{
    public class CustomerRepository:BaseRepository,ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {
        }
        #region Customers
        public IEnumerable<Vwtenantcustomers> Getcustomersdata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Vwtenantcustomers>(GetAllStatement(Vwtenantcustomers.TableName)).ToList();
            }
        }
        public GenericModel AddnewCustomers(Customers entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Tenantcode", entity.Tenantcode);
                parameters.Add("@Firstname", entity.Firstname);
                parameters.Add("@Lastname", entity.Lastname);
                parameters.Add("@Emailaddress", entity.Emailaddress);
                parameters.Add("@Phonenumber", entity.Phonenumber);
                parameters.Add("@Customerpass", entity.Customerpass);
                parameters.Add("@Customertype", entity.Customertype);
                parameters.Add("@Phoneprefix", entity.Phoneprefix);
                parameters.Add("@Stationcode", entity.Station);
                parameters.Add("@Canaccessprtal", entity.Canaccessprtal);
                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                return connection.Query<GenericModel>("Usp_AddnewCustomers", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Vwtenantcustomers Gettenantcustomerdata(long Customercode)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                return connection.Query<Vwtenantcustomers>(FindStatementraw(Vwtenantcustomers.TableName, "Customercode"), param: new { Id = Customercode }).FirstOrDefault();
            }
        }
        #endregion
    }
}
