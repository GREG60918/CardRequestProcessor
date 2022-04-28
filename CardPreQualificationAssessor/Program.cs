using System.Text.Json.Serialization;

using CardPreQualificationAssessor.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Please update as necessary. In reality this would ne an enviroment config property
var connectionString = "Server=DESKTOP-C3KJ59F\\SQLEXPRESS;Database=CardPreQualificationAssessorDB;Trusted_Connection=True;";

builder.Services.AddDbContext<CardPreQualificationAssessorDbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.Run();