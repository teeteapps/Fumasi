using DBL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.UOW
{
    public interface IUnitOfWork
    {
        ISecurityRepository SecurityRepository { get; }
        IStationRepository StationRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IAgreementRepository AgreementRepository { get; }
        //IShoppingCartRepository ShoppingCartRepository { get; }
        //IProductRepository ProductRepository { get; }
        void Reset();
    }
}
