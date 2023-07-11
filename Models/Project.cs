
namespace Project_management.Models

{
    public class Project
    {
        public int Id  { get; set; }
        public string? Name { get; set; }

        public ICollection<Ticket> Tickets { get;set; } = new List<Ticket>();
     

    }
}
