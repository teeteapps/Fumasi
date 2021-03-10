using DBL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Models
{
    public class UserModel
    {
        public long Subcode { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public int profilecode { get; set; }
        public UserLoginStatus UserStatus { get; set; }
        public int Loginstatus { get; set; }
        public string connId { get; set; }
        public string connKey { get; set; }
        public string connData { get; set; }
        public int RespStatus { get; set; }
        public string RespMessage { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string Extra5 { get; set; }
    }
}
