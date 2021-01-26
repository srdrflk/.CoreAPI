using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Constant;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers
{
	[Route("ProcessPayment")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
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
					string sss = Enums.Status.Processed.ToString();

					// call ICheapPaymentGateway
					// db güncelle
				}
				else if (value.Amount >= 21 && value.Amount <= 500)
				{
					// call IExpensivePaymentGateway if exist
				}
				else
				{
					//call PremiumPaymentService 3times 
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
