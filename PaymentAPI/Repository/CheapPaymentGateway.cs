using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.DataBaseContext;
using PaymentAPI.Interfaces;
using PaymentAPI.Models;
using PaymentAPI.Models.Entities;

namespace PaymentAPI.Repository
{
	public class CheapPaymentGateway : ICheapPaymentGateway
	{
		private readonly DatabaseContext _db;
		private readonly APIParameters _apiParameters;


		public CheapPaymentGateway(DatabaseContext db)
		{
			_db = db;
		}

		public void Add(PaymentEntitity paymentEntitity)
		{
			_db.Add(paymentEntitity);
			_db.SaveChanges();
			
		}

		public void Update(PaymentEntitity paymentEntitity)
		{
			_db.Entry(paymentEntitity).State = EntityState.Modified;
			_db.SaveChanges();
		}
	}
}
