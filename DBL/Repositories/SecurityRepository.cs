using Dapper;
using DBL.Entities;
using DBL.Enum;
using DBL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DBL.Repositories
{
    public class SecurityRepository : BaseRepository, ISecurityRepository
    {
        public SecurityRepository(string connectionString) : base(connectionString)
        {
        }
        #region Login
        public GenericModel Login(string userName)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Emailaddress", userName);

                return connection.Query<GenericModel>("Usp_VerifyUser", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion
        #region Station Staffs
        public IEnumerable<Permisions> Getpermissionsdata()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Permisions>(GetAllStatement(Permisions.TableName)).ToList();
            }
        }
        public GenericModel Addnewtenantstaff(Tenantstaffs entity)
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
                parameters.Add("@Staffpass", entity.Staffpass);
                parameters.Add("@Staffpin", entity.Staffpin);
                parameters.Add("@Topuplimittype", entity.Topuplimittype);
                parameters.Add("@Topuplimitvalue", entity.Topuplimitvalue);
                parameters.Add("@Stationcode", entity.Stationcode);
                parameters.Add("@Rolecode", entity.Rolecode);
                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                return connection.Query<GenericModel>("Usp_Addnewtenantstaff", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion

        #region Dropdown List
        public IEnumerable<ListModel> GetListModel(ListModelType listType)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Type", (int)listType);

                return connection.Query<ListModel>("Usp_GetListModel", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        #endregion
    }
}
