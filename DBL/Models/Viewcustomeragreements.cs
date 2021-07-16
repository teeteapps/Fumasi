using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBL.Models
{
    [Table("Viewcustomeragreements")]
    public class Viewcustomeragreements
    {
        [NotMapped]
        public static string TableName { get { return "Viewcustomeragreements"; } }
        public long Customercode { get; set; }
        public long Accountcode { get; set; }
        public string Fullname { get; set; }
        public string Phonenumber { get; set; }
        public string Emailaddress { get; set; }
        public string Customertype { get; set; }
        public long Agreementcode { get; set; }
        public long Loyaltycode { get; set; }
        public long Credittype { get; set; }
        public string AgreementDesc { get; set; }
        public long Agreementtypecode { get; set; }
        public string Billingbasis { get; set; }
        public string Agreementname { get; set; }
        public long Mainccounts { get; set; }
        public int Noofaccounts { get; set; }
    }
}
