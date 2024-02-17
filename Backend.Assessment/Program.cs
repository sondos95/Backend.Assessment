using Backend.Assessment.Infrastructure.IOC;
using Backend.Assessment.Application.IOC;
using FluentValidation.AspNetCore;
using System.Reflection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
#region Fluent Validation
builder.Services.AddControllers().AddFluentValidation(options =>
{
    // Validate child properties and root collection elements
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    options.AutomaticValidationEnabled = true;
});
#endregion

#region Logger
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
builder.Host.UseSerilog();
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region IOC for Unit of work and add ContextDb
builder.Services.AddInfrastructureServices(builder.Configuration);
#endregion
#region IOC for User Service
builder.Services.AddApplicationServices();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();
