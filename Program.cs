using Microsoft.EntityFrameworkCore;
using BankDb;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//ADD BANK
builder.Services.AddDbContext<Bank>();

var app = builder.Build();
app.MapControllers();
app.Run();

