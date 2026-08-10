using Microsoft.AspNetCore.Mvc;
using BankDb;
using DtoUser;
using BCrypt.Net;
using MoldesUser;
namespace ControllerUser
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ControllUser : ControllerBase
    {
        public Bank DB;
        public  ControllUser (Bank Bankdb) //INJECTION
        {
            DB = Bankdb;
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] UserDto UD)
        {
            UD.NameD=UD.NameD.Trim();
            if (string.IsNullOrWhiteSpace(UD.NameD))
            {
                return BadRequest();
            }
            if (string.IsNullOrWhiteSpace(UD.PasswordD))
            {
                return BadRequest();
            }
            if (UD.NameD.Length > 20)
            {
                return BadRequest();
            }
            string PasswordHash=BCrypt.Net.BCrypt.HashPassword(UD.PasswordD);
            User us = new User{Name=UD.NameD,Password=PasswordHash,Role=1};
            await DB.Users.AddAsync(us);
            await DB.SaveChangesAsync();
            return Ok();
        }
    }
}