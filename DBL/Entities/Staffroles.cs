using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBL.Entities
{
    [Table("Staffroles")]
    public class Staffroles
    {
        [NotMapped]
        public static string TableName { get { return "Staffroles"; } }
        public long Rolecode { get; set; }
        public string Rolename { get; set; }
        public string Roledescription { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public IEnumerable<Permisions> permissions { get; set; }
    }
    [Table("Permisions")]
    public class Permisions
    {
        [NotMapped]
        public static string TableName { get { return "Permisions"; } }
        public long Permisioncode { get; set; }
        public string Permisionname { get; set; }
        public string Permisiondesc { get; set; }

    }
}
