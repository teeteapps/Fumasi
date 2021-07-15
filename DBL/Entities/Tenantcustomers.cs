using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBL.Entities
{
    [Table("Customers")]
    public class Customers
    {
        [NotMapped]
        public static string TableName { get { return "Customers"; } }
        public long Customercode { get; set; }
        public long Tenantcode { get; set; }
        [Display(Name ="Firstname")]
        public string Firstname { get; set; }
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }
        public string Phoneprefix { get; set; }
        [Display(Name = "Phonenumber")]
        public string Phonenumber { get; set; }
        [Display(Name = "Emailaddress")]
        public string Emailaddress { get; set; }
        public string Customerpass { get; set; }
        [Display(Name = "Station")]
        public long Station { get; set; }
        [Display(Name = "Customer Portal Control")]
        public bool Canaccessprtal { get; set; }
        [Display(Name = "Customer Type")]
        public int Customertype { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
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
        public string Customertype { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public string Canaccessprtal { get; set; }
    }

    public class Customerandagreementdetails
    {
        public Vwtenantcustomers customers { get; set; }
        public IEnumerable<Customerprepaidagreementdata> prepaidagreement { get; set; }
    }
}
