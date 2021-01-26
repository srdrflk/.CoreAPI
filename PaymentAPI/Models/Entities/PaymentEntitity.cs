using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models.Entities
{
	public class PaymentEntitity
	{
		public int ID { get; set; }

		public int StatusID { get; set; }

		public PaymentStatusEntities PaymentStatusEntities { get; set; }
		
		public string CreditCardNumber { get; set; }

		public string CardHolder { get; set; }

		public DateTime ExpirationDate { get; set; }

		public string SecurityCode { get; set; }

		public decimal Amount { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime UpdatedDate { get; set; }

		
	}
}
