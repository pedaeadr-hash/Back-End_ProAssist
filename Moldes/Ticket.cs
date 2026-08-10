using System.ComponentModel.DataAnnotations;

namespace MoldesTicket
{
    public class Ticket
    {
        [Key]
        public int Id {get;set;}

        public required string NameApplicant {get;set;}
        public required string Subject {get;set;}
        public required DateTime DateandTime {get;set;}
        public string? Department {get;set;}
        public required int Status {get;set;}
        public string? Comment {get;set;} //Only Admins
        public string? Responsible {get;set;}
        
    }
}