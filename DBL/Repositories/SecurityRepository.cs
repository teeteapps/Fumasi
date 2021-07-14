using Dapper;
using DBL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repositories
{
    public class SecurityRepository:BaseRepository,ISecurityRepository
    {
        public SecurityRepository(string connectionString) : base(connectionString)
        {
        }
        #region Login User
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

    }
}
