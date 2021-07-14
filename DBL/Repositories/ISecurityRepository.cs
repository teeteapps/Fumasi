using DBL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repositories
{
    public interface ISecurityRepository
    {
        #region Login
        GenericModel Login(string userName);
        #endregion
    }
}
