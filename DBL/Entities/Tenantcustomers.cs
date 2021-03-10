using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBL.Entities
{
    [Table("Tenantcustomers")]
    public class Tenantcustomers
    {
        [NotMapped]
        public static string TableName { get { return "Tenantcustomers"; } }
        public long Customercode { get; set; }
        public long Tenantcode { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Emailaddress { get; set; }
        public string Customerpass { get; set; }
        public string Customerpin { get; set; }
        public long Station { get; set; }
        public bool Canaccessprtal { get; set; }
        public int Customergrouping { get; set; }
        public int Customertype { get; set; }
        public double Postpaidlimit { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
    [Table("Vwtenantcustomers")]
    public class Vwtenantcustomers
    {
        [NotMapped]
        public static string TableName { get { return "Vwtenantcustomers"; } }
        public long Customercode { get; set; }
        public long Tenantcode { get; set; }
        public string Fullname { get; set; }
        public string Phonenumber { get; set; }
        public string Emailaddress { get; set; }
        public string Stationname { get; set; }
        public string Customergouping { get; set; }
        public string Customertype { get; set; }
        public string Customerstatus { get; set; }
        public string Canaccessprtal { get; set; }
        public double Postpaidlimit { get; set; }
    }

    public class Customerandagreementdetails
    {
        public Vwtenantcustomers customers { get; set; }
        public IEnumerable<Customerprepaidagreementdata> prepaidagreement { get; set; }
    }
}
