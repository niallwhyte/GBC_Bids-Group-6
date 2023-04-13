using Microsoft.EntityFrameworkCore;

namespace GBC_Bids_Group_6.Models
{
    public class ItemContext : DbContext
    {
        internal readonly object Category;

        public ItemContext(DbContextOptions<ItemContext> options)
            : base(options)
        {

        }

        // DbSets
        public DbSet<ItemAsset> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Automotive" },
                new Category { Id = 2, Name = "Beauty" },
                new Category { Id = 3, Name = "Books" },
                new Category { Id = 4, Name = "Collectablies" },
                new Category { Id = 5, Name = "Electronics" },
                new Category { Id = 6, Name = "Entertainment" },
                new Category { Id = 7, Name = "Health" },
                new Category { Id = 8, Name = "Garden" },
                new Category { Id = 9, Name = "Home" },
                new Category { Id = 10, Name = "Music" },
                new Category { Id = 11, Name = "Office" },
                new Category { Id = 12, Name = "Pets" },
                new Category { Id = 13, Name = "Sports" },
                new Category { Id = 14, Name = "Tools" },
                new Category { Id = 15, Name = "Misc" }
                );

            modelBuilder.Entity<Condition>().HasData(
                new Condition { Id = 1, Name = "Poor" },
                new Condition { Id = 2, Name = "Okay" },
                new Condition { Id = 3, Name = "Good" },
                new Condition { Id = 4, Name = "Excellent" },
                new Condition { Id = 5, Name = "Mint" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { id = 1, userType = "Client", username = "buyer", email="", password = "buyer", verified = true },
                new User { id = 2, userType = "Client", username = "seller", email="", password = "seller", verified = true }
                );

        }
    }
}
