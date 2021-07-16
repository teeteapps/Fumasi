using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBL.Entities
{
    [Table("Discountlist")]
    public  class Discountlist
    {
        [NotMapped]
        public static string TableName { get { return "Discountlist"; } }
    }
}
