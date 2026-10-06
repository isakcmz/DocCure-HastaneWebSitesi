using Doccure.MarketService.Context;
using Doccure.MarketService.Services.CartServices;
using Doccure.MarketService.Services.ProductServices;
using Doccure.MarketService.Services.RedisServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IRedisService, RedisService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<MarketContext>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICartService, CartService>();

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
