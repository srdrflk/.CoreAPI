using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models.Entities
{
	public class PaymentStatusEntities
	{
		public int ID { get; set; }

		public string PaymentState { get; set; }

		public ICollection<PaymentEntitity> paymentEntitities { get; set; }
		
		
	}
}
