using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBL.Entities
{
    [Table("Companydetails")]
    public class Companydetails
    {
        [NotMapped]
        public static string TableName { get { return "Companydetails"; } }

        public long Companycode { get; set; }
        public string Companyname { get; set; }
        public string companyaddress { get; set; }
        public long country { get; set; }
        public string City { get; set; }
        public long Currency { get; set; }
        public bool Isactive { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
}
