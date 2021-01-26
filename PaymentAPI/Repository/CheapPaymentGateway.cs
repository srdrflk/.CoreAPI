using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentAPI.DataBaseContext;
using PaymentAPI.Interfaces;
using PaymentAPI.Models.Entities;

namespace PaymentAPI.Repository
{
	public class CheapPaymentGateway : ICheapPaymentGateway
	{
		private readonly DatabaseContext _db;

		public CheapPaymentGateway(DatabaseContext db)
		{
			_db = db;
		}

		public void Add(PaymentEntitity paymentEntitity)
		{
			_db.Add(paymentEntitity);
		}
		
	}
}
