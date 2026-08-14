using Microsoft.EntityFrameworkCore;
using BankDb;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//ADD BANK
builder.Services.AddDbContext<Bank>();
//JWT 
var key = Encoding.ASCII.GetBytes("ASDASDASDAD1312DA2131JE12H3OI12JP");
builder.Services.AddAuthentication(options =>
{
options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
options.TokenValidationParameters = new TokenValidationParameters
{
ValidateIssuerSigningKey = true,
IssuerSigningKey = new SymmetricSecurityKey(key),
ValidateIssuer = false,
ValidateAudience = false
};
});




var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization(); 
app.MapControllers();

app.Run();

