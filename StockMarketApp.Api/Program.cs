using StockMarketApp.Api.Configurations;
using StockMarketApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.Configure<AlphaVantageSettings>(
    builder.Configuration.GetSection(AlphaVantageSettings.SectionName)
);

builder.Services.AddHttpClient<IStockDataService, StockDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();