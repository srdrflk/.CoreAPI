using Microsoft.EntityFrameworkCore;
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

			modelBuilder.Entity<PaymentEntitity>().HasData(
				new PaymentEntitity
				{
					ID = 1,
					CreditCardNumber = "4938410184689511",
					CardHolder = "Serdar Filik",
					ExpirationDate = Convert.ToDateTime("01-05-2025"),
					SecurityCode = "123",
					Amount = 200,
					CreatedDate = DateTime.Now,
					UpdatedDate = DateTime.Now
				}
			);

			modelBuilder.Entity<PaymentStatusEntities>().HasData(
				new PaymentStatusEntities
				{
					ID = 1
				}
			);
		}
	}


}
