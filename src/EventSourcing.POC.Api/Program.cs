using EventSourcing.POC.Data.Extensions;
using EventSourcing.POC.Data.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEventSourcingPOCData(() =>
{
    var options = builder.Configuration.GetSection(EventSourcingPOCPostgresDataOptions.SectionName)
        .Get<EventSourcingPOCPostgresDataOptions>();

    return options ?? throw new InvalidOperationException(
        $"Section {EventSourcingPOCPostgresDataOptions.SectionName} is required"
    );
});


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
