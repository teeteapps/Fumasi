using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBL.Entities
{
    [Table("Stations")]
    public class Stations
    {
        [NotMapped]
        public static string TableName { get { return "Stations"; } }
        [Key]
        public long Stationcode { get; set; }
        public long Tenantcode { get; set; }
        [Display(Name = "Station Name")]
        [Required(ErrorMessage = "Station Name Required!")]
        public string Stationname { get; set; }
        [Display(Name = "Station Address")]
        public string Stationaddress { get; set; }
        [Display(Name = "Station Location")]
        public string Stationlocation { get; set; }
        [Display(Name = "Reference Code")]
        public string Stationreference { get; set; }
        public double Lng { get; set; }
        public double Lat { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
}
