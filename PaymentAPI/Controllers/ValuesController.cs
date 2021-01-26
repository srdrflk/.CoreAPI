using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Constant;
using PaymentAPI.Interfaces;
using PaymentAPI.Models;
using PaymentAPI.Models.Entities;
using PaymentAPI.Repository;

namespace PaymentAPI.Controllers
{
	[Route("ProcessPayment")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly CheapPaymentGateway _cheapPaymentGateway;
		public ValuesController(CheapPaymentGateway cheapPaymentGateway)
		{
			_cheapPaymentGateway = cheapPaymentGateway;
		}

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "value1", "value2" };
		}

		[HttpPost]
		public IActionResult Post([FromBody]APIParameters value)
		{
			try
			{
				if (value.Amount <= 20)
				{
					
					string sss = Enums.Status.Processed.ToString();//use for state of payment.


					using (var scope = new TransactionScope())
					{
						//_cheapPaymentGateway.Add();
						scope.Complete();
						return CreatedAtAction(nameof(Get), new { id = value.Amount }, value);
					}
				}
				else if (value.Amount >= 21 && value.Amount <= 500)
				{
					// call IExpensivePaymentGateway 
				}
				else
				{
					//call PremiumPaymentService 
					//Route by Ocelot 
				}

				// save payment and status

				return StatusCode(200, new { Message = "OK" });
			}
			catch (Exception)
			{
				return StatusCode(500);
			}

		}

	}
}
