using DBL.Entities;
using DBL.Enum;
using DBL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Repositories
{
    public interface ISecurityRepository
    {
        #region Login
        GenericModel Login(string userName);
        #endregion

        #region Station Staffs
        IEnumerable<Permisions> Getpermissionsdata();
        GenericModel Addnewtenantstaff(Tenantstaffs entity);
        #endregion

        #region Dropdown Data
        IEnumerable<ListModel> GetListModel(ListModelType listType);
        #endregion
    }
}
