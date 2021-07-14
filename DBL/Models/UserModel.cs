using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Models
{
    public class UserModel
    {
        public long Subcode { get; set; }
        public long Acccode { get; set; }
        public string connstring { get; set; }
        public string Reportstring { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public int profilecode { get; set; }
        public long Parentcode { get; set; }
        public int Loginstatus { get; set; }
        public int RespStatus { get; set; }
        public string RespMessage { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string Extra5 { get; set; }
    }
}
