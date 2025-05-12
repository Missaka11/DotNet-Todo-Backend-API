using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TaskAPI.DataAccess
{
    public class TodoDBContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; } // Call to the tables we creted
        public DbSet<Author> Authors { get; set; } // Call to the tables we creted

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;database=MyTodoDB;user=root;password=<yourDatabasePassword>";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));

            optionsBuilder.UseMySql(connectionString, serverVersion)
            // The following three options help with debugging, but should
            // be changed or removed for production.
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]{
                new Author
                {
                    Id = 1,
                    FullName = "John Doe",
                    AddressNo = "789",
                    Street = "Smith St",
                    City = "California",
                    JobRole = "Software Engineer"
                },
                new Author
                {
                    Id = 2,
                    FullName = "Will Smith",
                    AddressNo = "456",
                    Street = "Johnson St",
                    City = "Los Angeles",
                    JobRole = "Actor"
                },
                new Author
                {
                    Id = 3,
                    FullName = "Robert Hendry",
                    AddressNo = "123",
                    Street = "Main St",
                    City = "New York",
                    JobRole = "Doctor"
                }
            });
            modelBuilder.Entity<Todo>().HasData(new Todo[]
            {
                new Todo
                {
                    Id = 1,
                    Title = "Get fruits",
                    Description = "Get some fruits for the week",
                    Created = DateTime.Now,
                    Due = DateTime.Now.AddDays(10),
                    Status = TodoStatus.New,
                    AuthorId = 3
                },
                new Todo
                {
                    Id = 2,
                    Title = "Get books for school - DB",
                    Description = "Get some text books for school",
                    Created = DateTime.Now,
                    Due = DateTime.Now.AddDays(7),
                    Status = TodoStatus.New,
                    AuthorId = 1
                },
                new Todo
                {
                    Id = 3,
                    Title = "Get vegetables",
                    Description = "Get some vegitables for the week",
                    Created = DateTime.Now,
                    Due = DateTime.Now.AddDays(5),
                    Status = TodoStatus.Completed,
                    AuthorId = 2
                }
            });
        }
    }
}