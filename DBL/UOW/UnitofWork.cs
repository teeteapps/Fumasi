using DBL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.UOW
{
    public class UnitofWork:IUnitofWork
    {
        private string connString;
        private bool _disposed;

        private ISecurityRepository securityRepository;
        public UnitofWork(string connectionString)
        {
            connString = connectionString;
        }
        public ISecurityRepository SecurityRepository
        {
            get { return securityRepository ?? (securityRepository = new SecurityRepository(connString)); }
        }


        public void Reset()
        {
            securityRepository = null;
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

        ~UnitofWork()
        {
            dispose(false);
        }
    }
}
