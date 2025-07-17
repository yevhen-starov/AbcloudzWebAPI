
using AbcloudzWebAPI.Application;
using AbcloudzWebAPI.Infrastructure;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services
     .AddApplication()
     .AddInfrastructure(builder.Configuration);

//builder.Services.AddFluentValidationAutoValidation();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
