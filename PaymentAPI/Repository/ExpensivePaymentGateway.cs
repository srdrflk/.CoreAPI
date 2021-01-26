﻿using PaymentAPI.DataBaseContext;
using PaymentAPI.Interfaces;
using PaymentAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Repository
{
	public class ExpensivePaymentGateway : IExpensivePaymentGateway
	{
		private readonly DatabaseContext _db;
		public ExpensivePaymentGateway(DatabaseContext db)
		{
			_db = db;
		}

		public void Add(PaymentEntitity paymentEntitity)
		{
			_db.Add(paymentEntitity);
		}
	}
}
