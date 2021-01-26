using PaymentAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Interfaces
{
	interface IExpensivePaymentGateway
	{
		void Add(PaymentEntitity paymentEntitity);

		
	}
}
