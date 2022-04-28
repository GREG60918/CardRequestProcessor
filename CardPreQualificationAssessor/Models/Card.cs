namespace CardPreQualificationAssessor.Models
{
	/// <summary>
	/// Contains the data for a card
	/// </summary>
	public class Card
	{
		#region Properties

		public int Id { get; set; }

		public string Name { get; set; }

		public double APR { get; set; }

		public string PromotionalMessage { get; set; }

		public ICollection<CardRequest> CardRequests { get; set; }

		#endregion
	}
}
