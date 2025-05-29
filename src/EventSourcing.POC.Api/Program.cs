using EventSourcing.POC.Api.Extensions;
using EventSourcing.POC.Data.Extensions;
using EventSourcing.POC.Data.Options;
using EventSourcing.POC.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Application/Api Services
builder.Services.AddApplicationServices();

// Infrastructure Layer Services
builder.Services.AddRepositories();
builder.Services.AddInfrastructureHelpers();

// Data Layer Services
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
