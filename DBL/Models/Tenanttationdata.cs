using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBL.Models
{
    [Table("Stations")]
    public class Tenanttationdata
    {
        [NotMapped]
        public static string TableName { get { return "Stations"; } }
    }
}
