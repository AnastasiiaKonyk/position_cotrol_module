using backend.Position.Module.BLL;
using backend.Position.Module.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1. Реєструємо сервіси DAL (База даних, Репозиторії)
builder.Services.AddDataAccess(builder.Configuration);

// 2. Реєструємо сервіси BLL (Мапінг, Бізнес-логіка)
builder.Services.AddBusinessLogic();



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
