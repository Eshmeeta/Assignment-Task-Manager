using Microsoft.EntityFrameworkCore;
namespace Assignment_Eshmeeta.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>().HasData(
                new Tasks() { Id =1, Title = "Requirements Gathering", Description= "Collect the PRD from the client", Status = "Completed"},
                new Tasks() { Id =2, Title = "Requirements Analysis", Description= "Discuss the requirements with the team", Status = "Completed"},
                new Tasks() { Id =3, Title = "Provide Timeline", Description= "Provide a suitable timeline to the client", Status = "Completed"},
                new Tasks() { Id =4, Title = "Development", Description= "Develop the product", Status = "In-Progress"},
                new Tasks() { Id =5, Title = "Testing", Description= "Test the product", Status = "Incomplete"}
                
                );
        }

        public DbSet<Tasks> Tasks { get; set; }
    }
}
