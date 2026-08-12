using Microsoft.AspNetCore.Mvc;
using BankDb;
using MoldesTicket;
namespace  ControllerTicket
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ControllTicket : ControllerBase
    {
        public Bank DB;
        public ControllTicket (Bank BB)
        {
            DB = BB;
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody]Ticket Tck)
        {
            Tck.NameApplicant = Tck.NameApplicant.Trim();
            Tck.Subject = Tck.Subject.Trim();
            DateTime DateandTime = Tck.DateandTime;
            if (Tck.Department == null) {} else {Tck.Department=Tck.Department.Trim();}
            if (Tck.Status is not (0 or 1 or 2) ) {return BadRequest();}
            if (Tck.Comment == null) {} else {Tck.Department=Tck.Comment.Trim();}
            if (Tck.Responsible == null) {} else {Tck.Department=Tck.Responsible.Trim();}
            await DB.Tickets.AddAsync(Tck);
            await DB.SaveChangesAsync();
            return Ok();
        }
    }
}