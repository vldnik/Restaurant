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
                Weight = 1,
                Price = (decimal)1.5
            };
            var dish2 = new Dish
            {
                Id = 2,
                Name = "Slice of bread",
                PrepareTimeInMinutes = 3,
                Weight = 1,
                Price = (decimal)1
            };
            var dish3 = new Dish
            {
                Id = 3,
                Name = "Soup",
                PrepareTimeInMinutes = 7,
                Weight = 250,
                Price = (decimal)9.99
            };

            var dish4 = new Dish
            {
                Id = 4,
                Name = "Meat",
                PrepareTimeInMinutes = 10,
                Weight = 300,
                Price = (decimal)15.99
            };

            var dish5 = new Dish
            {
                Id = 5,
                Name = "Potato",
                PrepareTimeInMinutes = 8,
                Weight = 300,
                Price = (decimal)7.99
            };

            var ingredient1 = new Ingredient()
            {
                Id = 1,
                IsHard = false,
                Name = "Water",
                Quantity = 500
            };
            
            var ingredient2 = new Ingredient
            {
                Id = 2,
                IsHard = false,
                Name = "Bread",
                Quantity = 200
            };

            var ingredient3 = new Ingredient
            {
                Id = 3,
                IsHard = false,
                Name = "Potato",
                Quantity = 200
            };
            var ingredient4 = new Ingredient
            {
                Id = 4,
                IsHard = true,
                Name = "Meat",
                Quantity = 200
            };
            var dishIngredient1 = new DishIngredient()
            {
                DishId = 1,
                IngredientId = 1
            };

            var dishIngredient2 = new DishIngredient
            {
                DishId = 2,
                IngredientId = 2
            };
            var dishIngredient3 = new DishIngredient
            {
                DishId = 3,
                IngredientId = 3
            };
            var dishIngredient4 = new DishIngredient
            {
                DishId = 5,
                IngredientId = 3
            };
            
            var dishIngredient5 = new DishIngredient
            {
                DishId = 4,
                IngredientId = 4
            };

            modelBuilder.Entity<Dish>().HasData(dish1, dish2, dish3, dish4, dish5);
            modelBuilder.Entity<Ingredient>().HasData(ingredient1, ingredient2, ingredient3, ingredient4);
            modelBuilder.Entity<DishIngredient>().HasData(dishIngredient1, dishIngredient2, dishIngredient3, dishIngredient4, dishIngredient5);

            #endregion
        }
    }
}