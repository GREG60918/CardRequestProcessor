using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardPreQualificationAssessor.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Applicant_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Applicant_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Applicant_DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Applicant_AnnualIncome = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APR = table.Column<double>(type: "float", nullable: false),
                    PromotionalMessage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardCardRequest",
                columns: table => new
                {
                    CardRequestsId = table.Column<int>(type: "int", nullable: false),
                    SuitableCardsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardCardRequest", x => new { x.CardRequestsId, x.SuitableCardsId });
                    table.ForeignKey(
                        name: "FK_CardCardRequest_CardRequests_CardRequestsId",
                        column: x => x.CardRequestsId,
                        principalTable: "CardRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardCardRequest_Cards_SuitableCardsId",
                        column: x => x.SuitableCardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "APR", "Name", "PromotionalMessage" },
                values: new object[] { 1, 6.2000000000000002, "Barclays", "Hello" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "APR", "Name", "PromotionalMessage" },
                values: new object[] { 2, 12.699999999999999, "Santander", "Goodbye" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "APR", "Name", "PromotionalMessage" },
                values: new object[] { 3, 0.80000000000000004, "Vanquis", "Wow" });

            migrationBuilder.CreateIndex(
                name: "IX_CardCardRequest_SuitableCardsId",
                table: "CardCardRequest",
                column: "SuitableCardsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardCardRequest");

            migrationBuilder.DropTable(
                name: "CardRequests");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
