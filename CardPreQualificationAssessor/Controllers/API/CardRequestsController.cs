using CardPreQualificationAssessor.Core;
using CardPreQualificationAssessor.Data;
using CardPreQualificationAssessor.Models;

using Microsoft.AspNetCore.Mvc;

namespace CardPreQualificationAssessor.Controllers.API
{
	[Route("api/cardrequests")]
	[ApiController]
	public class CardRequestsController : ControllerBase
	{
		#region Fields

		private readonly CardPreQualificationAssessorDbContext _cardPreQualificationAssessorDbContext;

		#endregion

		#region Constructors

		// DB Context is injected through the app services
		public CardRequestsController(CardPreQualificationAssessorDbContext cardPreQualificationAssessorDbContext)
		{
			_cardPreQualificationAssessorDbContext = cardPreQualificationAssessorDbContext;
		}

		#endregion

		#region Route Handlers

		[HttpPost]
		public IActionResult GetSuitableCards(Applicant applicant)
		{
			if (applicant == null)
				return NotFound();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			// Extract buisness logic to dedicated class, method set up in a functional manor to simplify unit testing
			var cardRequest = CardRequestProcessor.ProcessCardRequestForApplicant(applicant, _cardPreQualificationAssessorDbContext.Cards.ToArray());

			if (cardRequest == null)
				return BadRequest("No credit cards available");

			_cardPreQualificationAssessorDbContext.CardRequests.Add(cardRequest);

			_cardPreQualificationAssessorDbContext.SaveChanges();

			return Ok(cardRequest);
		}

		#endregion
	}
}
