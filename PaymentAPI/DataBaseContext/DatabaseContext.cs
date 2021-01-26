using Microsoft.EntityFrameworkCore;
using PaymentAPI.Constant;
using PaymentAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.DataBaseContext
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{

		}

		public DbSet<PaymentEntitity> PaymentEntities { get; set; }
		public DbSet<PaymentStatusEntities> PaymentStatusEntities { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PaymentEntitity>().HasAlternateKey(p => p.StatusID);
				
		}
	}


}
