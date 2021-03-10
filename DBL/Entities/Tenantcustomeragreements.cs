using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBL.Entities
{
	public class Customeroneoffagreement
	{
		public long Agreementcode { get; set; }
		public long Customercode { get; set; }
		public long Agreementtype { get; set; }
		public long Loyaltygrouping { get; set; }
		public string Agreementdesc { get; set; }
		public double Limitvalue { get; set; }
		public long Graceperiod { get; set; }
		public DateTime Startdate { get; set; }
		public DateTime Enddate { get; set; }
		public string Billingbasis { get; set; }
		public long Pricelistcode { get; set; }
		public long Discountcode { get; set; }
		public string Agreementdoc { get; set; }
		public string Notes { get; set; }
		public DateTime Datecreated { get; set; }
		public DateTime Datemodified { get; set; }
		public string Createdby { get; set; }
		public string Modifiedby { get; set; }
	}
	public class Customerrecurrentagreement
	{
		public long Agreementcode { get; set; }
		public long Customercode { get; set; }
		public long Agreementtype { get; set; }
		public long Loyaltygrouping { get; set; }
		public string Agreementdesc { get; set; }
		public double Limitvalue { get; set; }
		public string Billingbasis { get; set; }
		public string Billingcycle { get; set; }
		public long Bilingday { get; set; }
		public long Graceperiod { get; set; }
		public DateTime Startdate { get; set; }
		public long Pricelistcode { get; set; }
		public long Discountcode { get; set; }
		public string Agreementdoc { get; set; }
		public string Notes { get; set; }
		public DateTime Datecreated { get; set; }
		public DateTime Datemodified { get; set; }
		public string Createdby { get; set; }
		public string Modifiedby { get; set; }
	}
	[Table("Customerprepaidagreement")]
	public class Customerprepaidagreement
	{
		[NotMapped]
		public static string TableName { get { return "Customerprepaidagreement"; } }
		public long Agreementcode { get; set; }
		public long Customercode { get; set; }
		public long Custcode { get; set; }
		public long Agreementtype { get; set; }
		public string Agreementdesc { get; set; }
		public IFormFile Agreementdocfile { get; set; }
		public string Agreementdoc { get; set; }
		public string Notes { get; set; }
		public DateTime Datecreated { get; set; }
		public DateTime Datemodified { get; set; }
		public string Createdby { get; set; }
		public string Modifiedby { get; set; }
	}

	[Table("Customerprepaidagreementdata")]
	public class Customerprepaidagreementdata
	{
		[NotMapped]
		public static string TableName { get { return "Customerprepaidagreementdata"; } }
		public long Agreementcode { get; set; }
		public long Customercode { get; set; }
		public long Accountcode { get; set; }
		public int Numberofaccounts { get; set; }
		public string Agreementtype { get; set; }
		public string Agreementdesc { get; set; }
		public string Agreementdoc { get; set; }
		public string Notes { get; set; }
		public long Accountnumber { get; set; }
		public bool Hasdrivercode { get; set; }
		public string Isactive { get; set; }
		public string Isdelete { get; set; }
		public string Identifiersno { get; set; }
		public string Identifieruid { get; set; }
		public string Typename { get; set; }
	}


	[Table("Vwagreementaccounts")]
	public class Vwagreementaccounts
	{
		[NotMapped]
		public static string TableName { get { return "Vwagreementaccounts"; } }
		public long Accountcode { get; set; }
		public long Accountnumber { get; set; }
		public long Agreementcode { get; set; }
		public string Identifiersno { get; set; }
		public string Identifieruid { get; set; }

	}

}
