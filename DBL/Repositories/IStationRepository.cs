using DBL.Entities;
using DBL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Repositories
{
    public interface IStationRepository
    {
        #region Tenant Stations
        IEnumerable<Tenanttationdata> Gettenenatstationslist();
        GenericModel Addnewtenantstation(Stations entity);
        Stations GetStationdetaildata(long stationcode);
        #endregion
    }
}
