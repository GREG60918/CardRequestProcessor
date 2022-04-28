using CardPreQualificationAssessor.Models;

using Microsoft.EntityFrameworkCore;

namespace CardPreQualificationAssessor.Data
{
	/// <summary>
	/// Contains the DB context for the application
	/// </summary>
	public class CardPreQualificationAssessorDbContext : DbContext
	{
		#region Constructors

		public CardPreQualificationAssessorDbContext()
		{
		}

		public CardPreQualificationAssessorDbContext(DbContextOptions options)
			: base(options)
		{
		}

		#endregion

		#region Properties

		public virtual DbSet<Card> Cards { get; set; }

		public virtual DbSet<CardRequest> CardRequests { get; set; }

		#endregion

		#region Methods

		/// <inheritdoc/>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Include the applicant as an owned entity of the card request object - in reality, the applicants would have their own table in the DB and this would be a nav property
			modelBuilder.Entity<CardRequest>().OwnsOne(c => c.Applicant);

			// Configure a many-many relationship between cards and card requests
			modelBuilder.Entity<CardRequest>()
				.HasMany<Card>(c => c.SuitableCards)
				.WithMany(c => c.CardRequests);

			modelBuilder.Entity<CardRequest>().ToTable("CardRequests");

			modelBuilder.Entity<Card>().ToTable("Cards");

			// Populate the DB with some test data
			SeedDatabase(modelBuilder);
		}

		/// <summary>
		/// Seeds the database with some initial card data
		/// </summary>
		/// <param name="modelBuilder"></param>
		private static void SeedDatabase(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Card>().HasData(
				new Card { Id = 1, Name = "Barclays", APR = 6.2, PromotionalMessage = "An exceptional offer!" },
				new Card { Id = 2, Name = "Santander", APR = 12.7, PromotionalMessage = "Once in a lifetime choice" },
				new Card { Id = 3, Name = "Vanquis", APR = 0.8, PromotionalMessage = "You literally won't beat this" });
		}

		#endregion
	}
}
