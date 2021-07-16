using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBL.Entities
{
    [Table("Pricelists")]
    public class Pricelists
    {
        [NotMapped]
        public static string TableName { get { return "Pricelists"; } }
        public long Pricecode { get; set; }
        public string Pricename { get; set; }
        public string Pricedescription { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public bool Isdefault { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
