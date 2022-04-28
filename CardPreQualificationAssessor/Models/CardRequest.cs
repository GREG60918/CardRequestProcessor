namespace CardPreQualificationAssessor.Models
{
	/// <summary>
	/// Contains the data for a card request
	/// </summary>
	public class CardRequest
	{
		#region Constructors

		/// <summary>
		/// Constructs a new instance of the <see cref="CardRequest"/> class and sets the date requested
		/// </summary>
		public CardRequest()
		{
			DateRequested = DateTime.Now;
		}

		#endregion

		#region Properties

		public int Id { get; set; }

		public Applicant Applicant { get; set; }

		public ICollection<Card> SuitableCards { get; set; }

		public DateTime DateRequested { get; }

		#endregion
	}
}
