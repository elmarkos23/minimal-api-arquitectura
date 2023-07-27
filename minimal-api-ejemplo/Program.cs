using Microsoft.EntityFrameworkCore;
using minimal_api_ejemplo.Context;
using minimal_api_ejemplo.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<PersonDb>(opt => opt.UseInMemoryDatabase("PersonList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// todoV1 endpoints
app.MapGroup("/Person/v1")
    .MapPersonEndPoint()
    .WithTags("Todo Endpoints");


app.Run();
