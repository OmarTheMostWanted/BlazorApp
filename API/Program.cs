using API.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IOperationProvider, OperationProvider>();
builder.Services.AddSingleton<ICalculator, Calculator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/calculator/add/{x , y}",
        (string x, string y, [FromServices] ICalculator calculator) =>
            calculator.Add(Convert.ToDouble(x), Convert.ToDouble(y)))
    .WithName("Add").WithTags("Operation");


app.MapPost("/calculator/sub/{x , y}",
        (string x, string y, [FromServices] ICalculator calculator) =>
            calculator.Sub(Convert.ToDouble(x), Convert.ToDouble(y)))
    .WithName("Sub").WithTags("Operation");


app.MapPost("/calculator/mul/{x , y}",
        (string x, string y, [FromServices] ICalculator calculator) =>
            calculator.Mul(Convert.ToDouble(x), Convert.ToDouble(y)))
    .WithName("Mul").WithTags("Operation");


app.MapPost("/calculator/div/{x , y}",
        (string x, string y, [FromServices] ICalculator calculator) =>
            calculator.Div(Convert.ToDouble(x), Convert.ToDouble(y)))
    .WithName("Div").WithTags("Operation");


app.MapPost("/calculator/pow/{x , y}",
        (string x, string y, [FromServices] ICalculator calculator) =>
            calculator.Pow(Convert.ToDouble(x), Convert.ToDouble(y)))
    .WithName("Pow").WithTags("Operation");


app.MapPost("/calculator/fak/{x , y}",
        (string x, string y, [FromServices] ICalculator calculator) =>
            calculator.Fak(Convert.ToDouble(x), Convert.ToDouble(y)))
    .WithName("Fak").WithTags("Operation");

app.Run();