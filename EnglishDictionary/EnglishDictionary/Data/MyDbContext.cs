using EnglishDictionary.Models;

using Microsoft.EntityFrameworkCore;


namespace EnglishDictionary.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<EngRusDictionaryModel> EngRusDictionary { get; set; }
        public DbSet<RusEngDictionaryModel> RusEngDictionary { get; set; }
        public DbSet<EngExplanatoryDictionaryModel> EngExplanatoryDictionaries { get; set; }
        public DbSet<RusExplanatoryDictionaryModel> RusExplanatoryDictionaries { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {
            //Database.EnsureDeleted();   // удаляем бд со старой схемой
            Database.EnsureCreated();
        }
    }
}
