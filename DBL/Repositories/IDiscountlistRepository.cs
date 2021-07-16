using DBL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Repositories
{
    public interface IDiscountlistRepository
    {
        IEnumerable<Discountlist> Gettenantdiscountlists();
        GenericModel Addnewdiscount(Discountlist entity);
        Discountlist Gettenantdiscountdata(long Discountcode);
        GenericModel Editnewdiscount(Discountlist entity);
    }
}
