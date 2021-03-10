using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Entities
{
    public class Customeragreementaccountidentifiers
    {
        public long identifiercode { get; set; }
        public long Accountcode { get; set; }
        public string Identifiersno { get; set; }
        public string Identifieruid { get; set; }
        public long Identifiertype { get; set; }
        public bool Isactive { get; set; }
        public bool Isdelete { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
    public class Customeragreementaccountemployees
    {
        public long Employeecode { get; set; }
        public long Accountcode { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Emailaddress { get; set; }
        public string Drivercode { get; set; }
        public bool Isactive { get; set; }
        public bool Isdelete { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
    public class Customeragreementaccountequipments
    {
        public long Equipmentcode { get; set; }
        public long Accountcode { get; set; }
        public string Equipmentregno { get; set; }
        public double Tankcapacity { get; set; }
        public long Productcode { get; set; }
        public double Odometerreading { get; set; }
        public long Vehiclemakecode { get; set; }
        public long Vehiclemmodelcode { get; set; }
        public bool Isactive { get; set; }
        public bool Isdelete { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
    public class Customeragreementaccountproductpolicy
    {
        public long Accountcode { get; set; }
        public long Productcode { get; set; }
        public double Productlimit { get; set; }
        public int Periodcode { get; set; }
        public bool Isactive { get; set; }
        public bool Isdelete { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
    public class Customeragreementaccountstationpolicy
    {
        public long Accountcode { get; set; }
        public long Stationcode { get; set; }
        public bool Isactive { get; set; }
        public bool Isdelete { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
    public class Customeragreementaccountfrequencypolicy
    {
        public long Accountcode { get; set; }
        public int Frequency { get; set; }
        public int Periodcode { get; set; }
        public bool Isactive { get; set; }
        public bool Isdelete { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
    public class Customeragreementaccountdayspolicy
    {
        public long Accountcode { get; set; }
        public int Dayscode { get; set; }
        public TimeSpan Starttime { get; set; }
        public TimeSpan Endtime { get; set; }
        public bool Isactive { get; set; }
        public bool Isdelete { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime Datemodified { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
    }
}
