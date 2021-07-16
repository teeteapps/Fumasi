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
    public class PricelistRepository:BaseRepository,IPricelistRepository
    {
        public PricelistRepository(string connectionString) : base(connectionString)
        {
        }
        public IEnumerable<Pricelists> Gettenantpricelists()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Pricelists>(GetAllStatement(Pricelists.TableName)).ToList();
            }
        }
        public GenericModel Addnewprice(Pricelists entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Pricename", entity.Pricename);
                parameters.Add("@Pricedescription", entity.Pricedescription);
                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                return connection.Query<GenericModel>("Usp_Addnewprice", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Pricelists Gettenantpricedata(long Pricecode)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                return connection.Query<Pricelists>(FindStatementraw(Pricelists.TableName, "Pricecode"), param: new { Id = Pricecode }).FirstOrDefault();
            }
        }
        public GenericModel Editnewprice(Pricelists entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Pricecode", entity.Pricecode);
                parameters.Add("@Pricename", entity.Pricename);
                parameters.Add("@Pricedescription", entity.Pricedescription);
                parameters.Add("@Datemodified", entity.Datemodified);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                return connection.Query<GenericModel>("Usp_Editnewprice", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
