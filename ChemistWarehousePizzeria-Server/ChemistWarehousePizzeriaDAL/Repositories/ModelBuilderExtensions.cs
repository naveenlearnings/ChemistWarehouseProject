using ChemistWarehousePizzeria.Models;
using Microsoft.EntityFrameworkCore;

namespace ChemistWarehousePizzeria.Repositories
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    Name = "WyndhamVale",
                },
                new Location
                {
                    Id = 2,
                    Name = "Docklands",
                });

            modelBuilder.Entity<Pizzeria>().HasData(
                new Pizzeria
                {
                    Id = 1,
                    Name = "PizzaHouse Wyndhamvale",
                    LocationId = 1,
                },
                new Pizzeria
                {
                    Id = 2,
                    Name = "PizzaHouse Docklands",
                    LocationId = 2,
                });

            modelBuilder.Entity<Menu>().HasData(
                new Menu
                {
                    Id = 1,
                    Name = "Main Menu",
                    PizzeriaId = 1,
                },
                 new Menu
                 {
                     Id = 2,
                     Name = "Main Menu",
                     PizzeriaId = 2,
                 });

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza
                {
                    Id = 1,
                    Name = "Veg-SpicyPanner",
                    Toppings = "Cheese, Capsicum, Panner, Olives,Cherry Tomatoes"
                },
                new Pizza
                {
                    Id = 2,
                    Name = "VegManorama",
                    Toppings = "Cheese, Capsicum, Chilli"
                },
                new Pizza
                {
                    Id = 3,
                    Name = "Margherita",
                    Toppings = "Cheese, Spinach, Cherry Tomatoes"
                },
                new Pizza
                {
                    Id = 4,
                    Name = "Mushroom",
                    Toppings = "Cheese, Mushrooms, Capsicum, Onion, Olives"
                });

            modelBuilder.Entity<PizzaMenu>().HasData(
                new PizzaMenu
                {
                    Id = 1,
                    MenuId = 1,
                    PizzaId = 1,
                },
                new PizzaMenu
                {
                    Id = 2,
                    MenuId = 1,
                    PizzaId = 2,
                },
                new PizzaMenu
                {
                    Id = 3,
                    MenuId = 1,
                    PizzaId = 3,
                },
                new PizzaMenu
                {
                    Id = 4,
                    MenuId = 2,
                    PizzaId = 1,
                },
                new PizzaMenu
                {
                    Id = 5,
                    MenuId = 2,
                    PizzaId = 4,
                });

            modelBuilder.Entity<Price>().HasData(
                new Price
                {
                    Id = 1,
                    Value = 20,
                    LocationId = 1,
                    PizzaId = 1,
                },
                new Price
                {
                    Id = 2,
                    Value = 18,
                    LocationId = 1,
                    PizzaId = 2,
                },
                new Price
                {
                    Id = 3,
                    Value = 22,
                    LocationId = 1,
                    PizzaId = 3,
                },
                new Price
                {
                    Id = 4,
                    Value = 25,
                    LocationId = 2,
                    PizzaId = 1,
                },
                new Price
                {
                    Id = 5,
                    Value = 17,
                    LocationId = 2,
                    PizzaId = 4,
                });
        }
    }
}
