using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Entities
{
	public class Customeragreementaccount
	{
		public long Accountcode { get; set; }
		public long Customercode { get; set; }
		public long Agreementcode { get; set; }
		public long Loyaltycode { get; set; }
		public long Parentcode { get; set; }
		public long Credittype { get; set; }
		public long Cardtypecode { get; set; }
		public string  Mask { get; set; }
		public decimal Limitvalue { get; set; }
		public string Limittype { get; set; }
		public DateTime Datecreated { get; set; }
		public DateTime Datemodified { get; set; }
		public long Createdby { get; set; }
		public long Modifiedby { get; set; }
	}
}
