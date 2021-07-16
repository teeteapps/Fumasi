using Dapper;
using DBL.Entities;
using System;
using System.Collections.Generic;
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
    }
}
