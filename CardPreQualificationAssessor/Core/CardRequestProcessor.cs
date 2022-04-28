using CardPreQualificationAssessor.Models;

namespace CardPreQualificationAssessor.Core
{
	/// <summary>
	/// Contains methods for processing card requests
	/// </summary>

	// This class could be made internal for security, and give the test projects access using the [InternalsVisibleTo] attribute
	public class CardRequestProcessor
	{
		#region Methods

		/// <summary>
		/// Processes a card request for the given applicant and sequence of cards
		/// </summary>
		/// <param name="applicant">The applicant</param>
		/// <param name="cards">The sequence of cards being checked for suitability</param>
		/// <returns>A card request if it is valid; null otherwise</returns>
		public static CardRequest ProcessCardRequestForApplicant(Applicant applicant, IEnumerable<Card> cards)
		{
			int age = DateTime.Now.Year - applicant.DateOfBirth.Value.Year;

			// Return null as the request isn't valid
			if (age < 18)
				return null;

			// simple logic for determining the appropriate card
			var suitableCard = applicant.AnnualIncome > 30000.0 ? cards.Single(c => c.Name == "Barclays") : cards.Single(c => c.Name == "Vanquis");

			return new CardRequest { Applicant = applicant, SuitableCards = new[] { suitableCard } };
		}

		#endregion
	}
}
