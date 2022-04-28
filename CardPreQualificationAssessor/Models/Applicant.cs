using System.ComponentModel.DataAnnotations;

namespace CardPreQualificationAssessor.Models
{
	/// <summary>
	/// Contains the data for a card applicant
	/// </summary>
	public class Applicant
	{
		#region Properties

		// TODO: Add any necessary validation to these, cosnider extracting to a DTO if necessary as well

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public DateTime? DateOfBirth { get; set; }

		[Required]
		public double? AnnualIncome { get; set; }

		#endregion
	}
}
