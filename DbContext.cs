using Microsoft.EntityFrameworkCore;
using MoldesTicket;
using MoldesUser;
namespace BankDb
{
    public class Bank : DbContext
    {
        //DBSET
        public DbSet<User> Users {get;set;}
        public DbSet<Ticket> Tickets {get;set;}
        //PROTECTED OVERRIDER WITH STRIN CONNECTION
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // O nome do banco será "ProdutosDb"
		// Aqui dizemos QUAL banco de dados vamos usar e ONDE ele está.
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=ProAssist;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}