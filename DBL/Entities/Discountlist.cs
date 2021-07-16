using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBL.Entities
{
    [Table("Discountlists")]
    public  class Discountlist
    {
        [NotMapped]
        public static string TableName { get { return "Discountlists"; } }
        public long Discountcode { get; set; }
        public string Discountname { get; set; }
        public string Discountdescription { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public bool Isdefault { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
    }
}
