using DBL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Repositories
{
    public interface ICustomerRepository
    {
        #region Customers
        IEnumerable<Vwtenantcustomers> Getcustomersdata();
        GenericModel AddnewCustomers(Customers entity);
        Vwtenantcustomers Gettenantcustomerdata(long Customercode);
        #endregion

    }
}
