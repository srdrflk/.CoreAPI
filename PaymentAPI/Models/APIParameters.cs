using PaymentAPI.Models.Validation;
using PaymentAPI.Resource;
using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models
{
	public class APIParameters
	{
		[ValidCreditCardNumber]
		public string CreditCardNumber { get; set; }


		[Required(ErrorMessageResourceName = "Valid_CardHolder", ErrorMessageResourceType = typeof(R))]
		public string CardHolder { get; set; }


		[ValidExpirationDate]
		[DataType(DataType.Date, ErrorMessageResourceName = "Valid_ExpirationDate", ErrorMessageResourceType = typeof(R))]
		public DateTime ExpirationDate { get; set; }


		[StringLength(3, MinimumLength = 3,
			ErrorMessageResourceName = "Valid_SecurityCode", ErrorMessageResourceType = typeof(R))]
		public string SecurityCode { get; set; }


		[Required(ErrorMessageResourceName = "Valid_Amount", ErrorMessageResourceType = typeof(R))]
		[Range(0, double.PositiveInfinity)]
		public decimal Amount { get; set; }

	}
}
