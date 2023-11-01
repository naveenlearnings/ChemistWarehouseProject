using ChemistWarehousePizzeria.Controllers;
using ChemistWarehousePizzeria.Models.Dtos;
using ChemistWarehousePizzeria.Repositories;
using ChemistWarehousePizzeria.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ChemistWarehousePizzeria.Tests.ControllerTests
{
    public class PizzeriasControllerTests
    {
        [Fact]
        public void GetAllPizzerias()
        {
            //arrange
            var pizzeriaList = new List<PizzeriaDto> {
            new PizzeriaDto {
                Id = 1,
                Name = "First Pizzeria",
                LocationId = 1,
                Menu = new MenuDto
                {
                    Id = 1,
                    Name = "Main Menu",
                    Pizzas = new List<PizzaDto>
                    {
                        new PizzaDto{
                            Id= 1,
                            Name = "First Pizza",
                            LocationId = 1,
                            Price= 20,
                            Toppings = "dummy toppings"
                        },
                        new PizzaDto{
                            Id= 2,
                            Name = "2nd Pizza",
                            LocationId = 1,
                            Price= 25,
                            Toppings = "Mashroom toppings"
                        }
                    }
                }
            },
            new PizzeriaDto
            {
                Id = 1,
                Name = "second Pizzeria",
                LocationId = 1,
                Menu = new MenuDto
                {
                    Id = 1,
                    Name = "Lunch Menu",
                    Pizzas = new List<PizzaDto>
                    {
                        new PizzaDto{
                            Id= 1,
                            Name = "First Pizza",
                            LocationId = 2,
                            Price= 28,
                            Toppings = "Extra toppings"
                        },
                        new PizzaDto{
                            Id= 3,
                            Name = "Good Pizza",
                            LocationId = 2,
                            Price= 18,
                            Toppings = "Olive toppings"
                        }
                    }
                }
            } };
            
            // We can also mock the actual repository and return the data we want and we can assert it here.
            // just for simplicity I am just mocking the PizzeriaService.

            var pizzeriaService = new Mock<IPizzeriaService>();
            pizzeriaService.Setup(_ => _.GetPizzeriasAsync())
                .Returns(Task.FromResult(pizzeriaList));
            
            //act
            var sut = new PizzeriasController(pizzeriaService.Object);

            var actionResult = sut.Get().Result;
            var actualResult = ((OkObjectResult)actionResult.Result).Value as IEnumerable<PizzeriaDto>;

            //Assert
            Assert.Equal(2, actualResult.Count());
            var firstExpectedPizzeria = pizzeriaList[0];
            var actualFirstPizzeria = actualResult.First();

            Assert.Equal(firstExpectedPizzeria.Id, actualFirstPizzeria.Id);
            Assert.Equal(firstExpectedPizzeria.Name, actualFirstPizzeria.Name);
            Assert.Equal(firstExpectedPizzeria.LocationId, actualFirstPizzeria.LocationId);

            var firstExpectedPizza = firstExpectedPizzeria.Menu.Pizzas.First();
            var actualFirstPizza = actualFirstPizzeria.Menu.Pizzas.First();

            Assert.Equal(firstExpectedPizza.Id, actualFirstPizza.Id);
            Assert.Equal(firstExpectedPizza.Name, actualFirstPizza.Name);
            Assert.Equal(firstExpectedPizza.LocationId, actualFirstPizza.LocationId);
            Assert.Equal(firstExpectedPizza.Price, actualFirstPizza.Price);
            Assert.Equal(firstExpectedPizza.Toppings, actualFirstPizza.Toppings);

            var secondExpectedPizzeria = pizzeriaList[1];
            var actualSecondPizzeria = actualResult.Last();

            Assert.Equal(secondExpectedPizzeria.Id, actualSecondPizzeria.Id);
            Assert.Equal(secondExpectedPizzeria.Name, actualSecondPizzeria.Name);
            Assert.Equal(secondExpectedPizzeria.LocationId, actualSecondPizzeria.LocationId);

            var secondExpectedPizza = secondExpectedPizzeria.Menu.Pizzas.Last();
            var actualSecondPizza = actualSecondPizzeria.Menu.Pizzas.Last();

            Assert.Equal(secondExpectedPizza.Id, actualSecondPizza.Id);
            Assert.Equal(secondExpectedPizza.Name, actualSecondPizza.Name);
            Assert.Equal(secondExpectedPizza.LocationId, actualSecondPizza.LocationId);
            Assert.Equal(secondExpectedPizza.Price, actualSecondPizza.Price);
            Assert.Equal(secondExpectedPizza.Toppings, actualSecondPizza.Toppings);
        }
    }
}
