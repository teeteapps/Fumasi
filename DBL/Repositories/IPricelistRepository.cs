using DBL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Repositories
{
   public  interface IPricelistRepository
    {
        IEnumerable<Pricelists> Gettenantpricelists();
        GenericModel Addnewprice(Pricelists entity);
        Pricelists Gettenantpricedata(long Pricecode);
        GenericModel Editnewprice(Pricelists entity);
    }
}
