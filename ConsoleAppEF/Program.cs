using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleAppEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    class AppContext : DbContext
    {

        //public AppContext(DbContextOptions<AppContext> options)
        //    : base(options)
        //{
        //}

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<User>().HasData(
                new User() { Id = Guid.NewGuid(), Email = "Mubeen@gmail.com", Name = "Mubeen", Age = 30, Password = "123123" },
                new User() { Id = Guid.NewGuid(), Email = "Tahir@gmail.com", Name = "Tahir", Age = 15, Password = "321321" },
                new User() { Id = Guid.NewGuid(), Email = "Cheema@gmail.com", Name = "Cheema", Age = 25, Password = "123321" }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=testDb; Trusted_Connection=True");
        }

        public DbSet<User> Users { get; set; }

    }
}
