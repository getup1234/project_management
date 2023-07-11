using System;

namespace Project_management.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public TaskStatus Status { get; set; } = TaskStatus.CREATED;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ClosedAt { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;


        public enum TaskStatus
        {
            CREATED,
            ASSIGNED,
            ONGOING,
            INTEGRATED,
            CLOSED
        }
    }
}
