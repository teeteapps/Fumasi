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
    public class StationRepository:BaseRepository,IStationRepository
    {
        public StationRepository(string connectionString) : base(connectionString)
        {
        }
        #region Tenant Stations
        public IEnumerable<Stations> Gettenenatstationslist()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Stations>(GetAllStatement(Stations.TableName)).ToList();
            }
        }
        public GenericModel Addnewtenantstation(Stations entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Tenantcode", entity.Tenantcode);
                parameters.Add("@Stationname", entity.Stationname);
                parameters.Add("@Stationref", entity.Stationreference);
                parameters.Add("@Stationaddress", entity.Stationaddress);
                parameters.Add("@Lng", entity.Lng);
                parameters.Add("@Lat", entity.Lat);
                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                return connection.Query<GenericModel>("Usp_Addnewtenantstation", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Stations GetStationdetaildata(long stationcode)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                return connection.Query<Stations>(FindStatementraw(Stations.TableName, "Stationcode"), param: new { Id = stationcode }).FirstOrDefault();
            }
        }

        #endregion
    }
}
