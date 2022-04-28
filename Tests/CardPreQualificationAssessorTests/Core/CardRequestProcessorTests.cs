using System;
using System.Collections.Generic;
using System.Linq;

using CardPreQualificationAssessor.Core;
using CardPreQualificationAssessor.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardPreQualificationAssessorTests.Core
{
	/// <summary>
	/// Contains test methods for the <see cref="CardRequestProcessor"/> class
	/// </summary>
	[TestClass]
	public class CardRequestProcessorTests
	{
		#region Tests

		[TestMethod]
		public void Applicant_Under_18_Should_Return_Null()
		{
			var applicant = new Applicant
			{
				DateOfBirth = DateTime.Now,
			};

			var cards = GetCards().ToArray();

			Assert.IsNull(CardRequestProcessor.ProcessCardRequestForApplicant(applicant, cards));
		}

		[TestMethod]
		public void Applicant_Under_18_With_Income_Over_32000_Should_Return_Barclays()
		{
			var applicant = new Applicant
			{
				DateOfBirth = new DateTime(1990, 1, 1),
				AnnualIncome = 40000.0,
			};

			var cards = GetCards().ToArray();

			Assert.IsTrue(CardRequestProcessor.ProcessCardRequestForApplicant(applicant, cards).SuitableCards.First().Name == "Barclays");
		}

		[TestMethod]
		public void Applicant_Under_18_With_Income_Under_32000_Should_Return_Vanquis()
		{
			var applicant = new Applicant
			{
				DateOfBirth = new DateTime(1990, 1, 1),
				AnnualIncome = 20000.0,
			};

			var cards = GetCards().ToArray();

			Assert.IsTrue(CardRequestProcessor.ProcessCardRequestForApplicant(applicant, cards).SuitableCards.First().Name == "Vanquis");
		}

		#endregion

		#region Helpers

		// Some simple card data for testing. Not the most complete dataset but enough for the purposes of these tests. In reality a test DB should be used
		// Could also do this in the setup/initialize method (depending on test framework)
		private static IEnumerable<Card> GetCards()
		{
			yield return new Card { Id = 1, Name = "Barclays" };
			yield return new Card { Id = 2, Name = "Vanquis" };
			yield return new Card { Id = 3, Name = "Santander" };
		}

		#endregion
	}
}
