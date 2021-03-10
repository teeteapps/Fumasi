using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.Entities
{
	public class Customeragreementaccount
	{
		public long Accountcode { get; set; }
		public long Customercode { get; set; }
		public long Accountnumber { get; set; }
		public bool Hasdrivercode { get; set; }
		public long Agreementcode { get; set; }
		public long Identifiercode { get; set; }
		public DateTime Datecreated { get; set; }
		public DateTime Datemodified { get; set; }
		public string Createdby { get; set; }
		public string Modifiedby { get; set; }
	}
}
