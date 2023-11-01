using ChemistWarehousePizzeria.Models;
using ChemistWarehousePizzeria.Models.Dtos;
using ChemistWarehousePizzeria.Repositories.Interfaces;
using ChemistWarehousePizzeria.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ChemistWarehousePizzeria.Services
{
    public class PizzeriaService : IPizzeriaService
    {
        private readonly IPizzeriaRepository _pizzeriaRepository;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IPriceRepository _priceRepository;

        public PizzeriaService(IPizzeriaRepository pizzeriaRepository, IPizzaRepository pizzaRepository, IPriceRepository priceRepository)
        {
            _pizzeriaRepository = pizzeriaRepository;
            _pizzaRepository = pizzaRepository;
            _priceRepository = priceRepository;
        }

        public async Task<List<PizzeriaDto>> GetPizzeriasAsync()
        {
            var pizzeriaList = new List<PizzeriaDto>();
            var pizzerias = await _pizzeriaRepository.GetPizzeriasAsync();
            foreach (var p in pizzerias)
            {
                pizzeriaList.Add(this.GetPizzeriaDto(p));
            }

            return pizzeriaList;
        }

        public async Task<PizzeriaDto?> GetPizzeriaByIdAsync(int pizzeriaId)
        {
            var pizzeria = await _pizzeriaRepository.GetPizzeriaByIdAsync(pizzeriaId);
            if(pizzeria == null)
            {
                return null;
            }
            return this.GetPizzeriaDto(pizzeria);
        }

        public async Task UpdatePizzeriaAsync(int id, PizzeriaDto pizzeria)
        {
            var pizzeriaEntity = await _pizzeriaRepository.GetPizzeriaByIdAsync(id);
            if (pizzeriaEntity == null)
            {
                //better to write own NotFoundException and throw it.
                throw new Exception("Not Found Exception");
            }

            var menu = pizzeriaEntity.Menus.FirstOrDefault();
            if (menu == null)
            {
                //better to write own NotFoundException and throw it.
                throw new Exception("Not Found Exception");
            }

            //In real app I will check for all null scenarios but here I am keeping it simple.

            if (pizzeria.Menu?.Pizzas != null)
            {
                foreach (var pizzaDto in pizzeria.Menu?.Pizzas)
                {
                    var pizzaToUpdate = menu.PizzaMenus.Where(x => x.MenuId == menu.Id && x.PizzaId == pizzaDto.Id).FirstOrDefault();
                    if(pizzaToUpdate != null)
                    {
                        pizzaToUpdate.Pizza.Name = pizzaDto.Name;
                        pizzaToUpdate.Pizza.Toppings = pizzaDto.Toppings;
                        await _pizzaRepository.UpdateAsync(pizzaToUpdate.Pizza);
                        //instead of loading all prices to the memory we should filter it in db.
                        var prices = await _priceRepository.GetAllAsync();
                        var priceToUpdate = prices.SingleOrDefault(x => x.LocationId == pizzaDto.LocationId && x.PizzaId == pizzaDto.Id);
                        if(priceToUpdate != null) 
                        {
                            priceToUpdate.Value = pizzaDto.Price;
                            await _priceRepository.UpdateAsync(priceToUpdate);
                        }
                    }
                }
            }
        }

        private PizzeriaDto GetPizzeriaDto(Pizzeria p)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));

            PizzeriaDto pDto = new PizzeriaDto();
            pDto.Name = p.Name;
            pDto.Id = p.Id;
            pDto.LocationId = p.LocationId;
            pDto.Location = new LocationDto { Id = p.Location.Id, Name = p.Location.Name };

            //In real app I will check for all null scenarios but here I am keeping it simple.

            pDto.Menu = p.Menus.Select(m => new MenuDto { Id = m.Id, Name = m.Name, }).FirstOrDefault();

            var menu = p.Menus.FirstOrDefault();
            if (menu != null)
            {
                var pizzas = menu.PizzaMenus.Select(x => new PizzaDto
                {
                    Id = x.Pizza.Id,
                    Name = x.Pizza.Name,
                    Toppings = x.Pizza.Toppings,
                    LocationId = pDto.Location.Id,
                    Price = x.Pizza.Prices.Where(x => x.LocationId == pDto.LocationId).First().Value
                }).ToList();

                if (pDto.Menu != null)
                {
                    pDto.Menu.Pizzas = pizzas;
                }
            }

            return pDto;
        }
    }
}
