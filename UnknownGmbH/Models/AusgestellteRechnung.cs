using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnknownGmbH.Models
{
	public class AusgestellteRechnung
	{
		public int AusgestellteRechnungId {get; set;}
		public int NeueRechnungId { get; set; }

		public virtual ICollection<NeueRechnung>NeueRechnungs { get; set; }
	}
}