using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fumasi.Models
{
    public class UserDataModel
    {
        public long UserCode { get; set; }
        public long Acccode { get; set; }
        public string connstring { get; set; }
        public string Reportstring { get; set; }
        public string Fullname { get; set; }
        public string UserName { get; set; }
        public string Phonenumber { get; set; }
        public int ProfileCode { get; set; }
        public long Parentcode { get; set; }
       
    }
}
