using DBL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Repositories
{
    public interface IDiscountlistRepository
    {
        IEnumerable<Discountlist> Gettenantdiscountlists();
    }
}
