using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnknownGmbH.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace UnknownGmbH.HAK
{
	public class WorkContext : DbContext
	{
		public WorkContext() :base("WorkContext")
		{
		}

		public DbSet<NeueRechnung> NeueRechnungs { get; set; }
		public DbSet<AusgestellteRechnung> AusgestellteRechnungs { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}