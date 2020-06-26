using EnglishDictionary.Models;

using Microsoft.EntityFrameworkCore;


namespace EnglishDictionary.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
