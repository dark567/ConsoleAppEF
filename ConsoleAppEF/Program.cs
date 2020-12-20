using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ConsoleAppEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            AddItems();
            ShowItems();
            DelItems("Tahir");
            ShowItems();
            AddRange();
            ShowItems();

            UpdateItem("Dark");
            ShowItems();

            Console.WriteLine("Stop");
            Console.ReadKey();
        }

        private static void UpdateItem(string name)
        {
            using (AppContext context = new AppContext())
            {
                var users = context.Users.Where(a => a.Name == name).ToArray();
                if (users != null)
                {
                    foreach (var user in users)
                    {
                        user.Email = "321";
                    }

                    context.UpdateRange(users);
                    context.SaveChanges();
                }

            }
        }

        private static void AddRange()
        {
            using (AppContext context = new AppContext())
            {
                User user1 = new User
                {
                    Email = "Mubeen1@gmail.com",
                    Name = "Dark123",
                    Age = 999,
                    Password = "123123"
                };

                User user2 = new User
                {
                    Email = "Mubeen1123@gmail.com",
                    Name = "123Dark",
                    Age = 999,
                    Password = "123123"
                };

                if (!context.Users.Where(a => a.Name == user1.Name).Where(b => b.Email == user1.Email).Any())
                    context.Add(user1);

                if (!context.Users.Where(a => a.Name == user2.Name).Where(b => b.Email == user2.Email).Any())
                    context.Add(user2);

                context.SaveChanges();
            }
        }

        private static void ShowItems()
        {
            using (AppContext context = new AppContext())
            {
                foreach (var user in context.Users)
                {
                    Console.WriteLine($"{user.Id}\t{user.Name}\t{user.Age}\t{user.Email}\t{user.Password}");
                }
            }
            Console.WriteLine();
        }

        private static void DelItems(string name)
        {
            using (AppContext context = new AppContext())
            {
                var user = context.Users.Where(a => a.Name == name).FirstOrDefault();
                if (user != null)
                {
                    context.Remove(user);
                }
                else Console.WriteLine($"Item {name} not found");
                context.SaveChanges();
            }
        }

        private static void AddItems()
        {
            using (AppContext context = new AppContext())
            {
                User user = new User
                {
                    Email = "Mubeen1@gmail.com",
                    Name = "Dark123",
                    Age = 999,
                    Password = "123123"
                };

                if (!context.Users.Where(a => a.Name == user.Name).Where(b => b.Email == user.Email).Any())
                    context.Add(user);
                context.SaveChanges();
            }
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

            mb.Entity<User>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            //mb.Entity<User>(b =>
            //{
            //    b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
            //});

            //mb.Entity<User>()
            //        .Property(e => e.Id)
            //        .HasDefaultValueSql("newid()");

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
