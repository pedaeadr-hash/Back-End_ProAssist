using System.ComponentModel.DataAnnotations;

namespace MoldesUser
{
    public class User
    {
        [Key]
        public int Id {get;set;}
        public required string Name {get;set;} 
        public required string Password {get;set;}
        public required int Role {get;set;}
    }
}