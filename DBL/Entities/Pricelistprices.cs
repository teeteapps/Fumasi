using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBL.Entities
{
    [Table("Pricelistprices")]
    public class Pricelistprices
    {
        [NotMapped]
        public static string TableName { get { return "Pricelistprices"; } }
        public long Pricelistcode { get; set; }
        public long Pricecode { get; set; }
        public long Productcode { get; set; }
        public long Stationcode { get; set; }
    }
}
