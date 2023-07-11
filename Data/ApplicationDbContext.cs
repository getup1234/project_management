using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

using Project_management.Models;



namespace Project_management.Data

{

    public class ApplicationDbContext : IdentityDbContext

    {

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<IdentityUser> MyProperty { get; set; }




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)

            : base(options)

        {

        }

    }

}


