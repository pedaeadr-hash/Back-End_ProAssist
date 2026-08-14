using Microsoft.EntityFrameworkCore;
using BankDb;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//ADD BANK
builder.Services.AddDbContext<Bank>();
builder.Services.AddJwtAuth();
var app = builder.Build();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();

