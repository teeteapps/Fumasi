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
    public class DiscountlistRepository:BaseRepository,IDiscountlistRepository
    {
        public DiscountlistRepository(string connectionString) : base(connectionString)
        {
        }
        public IEnumerable<Discountlist> Gettenantdiscountlists()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Discountlist>(GetAllStatement(Discountlist.TableName)).ToList();
            }
        }
        public GenericModel Addnewdiscount(Discountlist entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Discountname", entity.Discountname);
                parameters.Add("@Discountdescription", entity.Discountdescription);
                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                return connection.Query<GenericModel>("Usp_Addnewdiscount", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Discountlist Gettenantdiscountdata(long Discountcode)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                return connection.Query<Discountlist>(FindStatementraw(Discountlist.TableName, "Discountcode"), param: new { Id = Discountcode }).FirstOrDefault();
            }
        }
        public GenericModel Editnewdiscount(Discountlist entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Discountcode", entity.Discountcode);
                parameters.Add("@Discountname", entity.Discountname);
                parameters.Add("@Discountdescription", entity.Discountdescription);
                parameters.Add("@Datemodified", entity.Datemodified);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                return connection.Query<GenericModel>("Usp_Editnewdiscount", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
