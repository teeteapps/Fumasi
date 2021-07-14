using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repositories
{
    public class SecurityRepository:BaseRepository,ISecurityRepository
    {
        public SecurityRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
