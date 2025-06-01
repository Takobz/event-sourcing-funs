using EventSourcing.POC.Api.Extensions;
using EventSourcing.POC.Data.Extensions;
using EventSourcing.POC.Data.Options;
using EventSourcing.POC.Infrastructure.Extensions;
using Asp.Versioning;

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

// Configure API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0); // Default version 1.0
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(), // /api/v1/users
        new QueryStringApiVersionReader("version"), // ?version=1.0
        new HeaderApiVersionReader("X-Version") // X-Version: 1.0
    );
});

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
