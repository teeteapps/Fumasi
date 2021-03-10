using DBL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private string connString;
        private bool _disposed;

        private ISecurityRepository securityRepository;
        private IStationRepository stationRepository;
        private ICustomerRepository customerRepository;
        private IAgreementRepository agreementRepository;
        //private IShoppingCartRepository shoppingCartRepository;
        //private IProductRepository productRepository;

        public UnitOfWork(string connectionString)
        {
            connString = connectionString;
        }
        public ISecurityRepository SecurityRepository
        {
            get { return securityRepository ?? (securityRepository = new SecurityRepository(connString)); }
        }
        public IStationRepository StationRepository
        {
            get { return stationRepository ?? (stationRepository = new StationRepository(connString)); }
        }
        public ICustomerRepository CustomerRepository
        {
            get { return customerRepository ?? (customerRepository = new CustomerRepository(connString)); }
        }
        public IAgreementRepository AgreementRepository
        {
            get { return agreementRepository ?? (agreementRepository = new AgreementRepository(connString)); }
        }
        //public IProductRepository ProductRepository
        //{
        //    get { return productRepository ?? (productRepository = new ProductRepository(connString)); }
        //}

        //public IShoppingCartRepository ShoppingCartRepository
        //{
        //    get { return shoppingCartRepository ?? (shoppingCartRepository = new ShoppingCartRepository(connString)); }
        //}
        public void Reset()
        {
            securityRepository = null;
            stationRepository = null;
            customerRepository = null;
            agreementRepository = null;
            //productRepository = null;
            //shoppingCartRepository = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
