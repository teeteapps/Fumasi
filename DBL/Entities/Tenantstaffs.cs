using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBL.Entities
{
    [Table("Tenantstaffs")]
    public class Tenantstaffs
    {
        [NotMapped]
        public static string TableName { get { return "Tenantstaffs"; } }
        public long Staffcode { get; set; }
        public long Tenantcode { get; set; }
        public long Rolecode { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Emailaddress { get; set; }
        public string Phonenumber { get; set; }
        public string Staffpass { get; set; }
        public string Staffpin { get; set; }
        public int Staffstatus { get; set; }
        public string Topuplimittype { get; set; }
        public double Topuplimitvalue { get; set; }
        public long Stationcode { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
}
