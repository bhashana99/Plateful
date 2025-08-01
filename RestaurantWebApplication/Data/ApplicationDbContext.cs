﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantWebApplication.Models;

namespace RestaurantWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<ProductIngredient> ProductIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the many-to-many relationship between Product and Ingredient
            modelBuilder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });
            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);
            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);


            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { CategoryId = 1, Name = "Appetizers" },
                    new Category { CategoryId = 2, Name = "Entree" },
                    new Category { CategoryId = 3, Name = "Side Dish" },
                    new Category { CategoryId = 4, Name = "Dessert" },
                    new Category { CategoryId = 5, Name = "Beverage" }
                );

            modelBuilder.Entity<Ingredient>()
                .HasData(
                    new Ingredient { IngredientId = 1, Name = "Beef" },
                    new Ingredient { IngredientId = 2, Name = "Chicken" },
                    new Ingredient { IngredientId = 3, Name = "Fish" },
                    new Ingredient { IngredientId = 4, Name = "Tortilla" },
                    new Ingredient { IngredientId = 5, Name = "Lettuce" },
                    new Ingredient { IngredientId = 6, Name = "Tomato" }
                );
        }
    }

    
}
