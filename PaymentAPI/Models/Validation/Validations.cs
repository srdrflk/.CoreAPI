using PaymentAPI.Resource;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace PaymentAPI.Models.Validation
{
	public class ValidCreditCardNumber : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			APIParameters model = (APIParameters)validationContext.ObjectInstance;

			var regex = new Regex("^[0-9]{16}$");
			if (!regex.IsMatch(model.CreditCardNumber))
				return new ValidationResult(R.Valid_NotCCN);

			if (!luhnCCNCheck(model.CreditCardNumber))
				return new ValidationResult(R.Valid_CCN);

			return ValidationResult.Success;
		}

		private bool luhnCCNCheck(string val)
		{
			int sum = 0;
			for (int i = 0; i < val.Count(); i++)
			{
				int intVal = int.Parse(val.Substring(i, 1));
				if (i % 2 == 0)
				{
					intVal *= 2;
					if (intVal > 9) intVal = 1 + (intVal % 10);
				}
				sum += intVal;
			}
			return (sum % 10) == 0;
		}
	}

	public class ValidExpirationDate : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			APIParameters model = (APIParameters)validationContext.ObjectInstance;

			if (model.ExpirationDate < DateTime.Now)
				return new ValidationResult(R.Valid_Date);

			return ValidationResult.Success;
		}

	}
}
