using System;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public RestaurantDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=Restaraunt;Trusted_Connection=True;");
        }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<DishIngredient> DishIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DishIngredient>()
                .HasKey(x => new {x.DishId, x.IngredientId});

            modelBuilder.Entity<DishIngredient>()
                .HasOne(x => x.Dish)
                .WithMany(x => x.Ingredients)
                .HasForeignKey(x => x.DishId);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(x => x.Ingredient)
                .WithMany(x => x.Dishes)
                .HasForeignKey(x => x.IngredientId);

            #region SeedData

            var dish1 = new Dish()
            {
                Id = 1,
                Name = "A cup of water",
                PrepareTimeInMinutes = 2,
                Weight = 1
            };

            var ingredient1 = new Ingredient()
            {
                Id = 1,
                IsHard = false,
                Name = "Water",
                Quantity = 500
            };
            
            var dishIngredient1 = new DishIngredient()
            {
                DishId = 1,
                IngredientId = 1
            };

            modelBuilder.Entity<Dish>().HasData(dish1);
            modelBuilder.Entity<Ingredient>().HasData(ingredient1);
            modelBuilder.Entity<DishIngredient>().HasData(dishIngredient1);

            #endregion
        }
    }
}