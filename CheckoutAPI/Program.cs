using CheckoutBL.DataRepository;
using CheckoutBL.DiscountCalculator;
using CheckoutBL.Services.CheckoutService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register impl. of IDataRepository
builder.Services.AddSingleton<IDataRepository, DummyDataRepository>();

// Register impl. of IDiscountCalculator
builder.Services.AddSingleton<IDiscountCalculator, NaiveDiscountCalculator>();

// Register impl. of ICheckoutService
builder.Services.AddSingleton<ICheckoutService, CheckoutService>();

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
