using ChemistWarehousePizzeria.Models;
using ChemistWarehousePizzeria.Models.Dtos;
using ChemistWarehousePizzeria.Repositories.Interfaces;
using ChemistWarehousePizzeria.Services.Interfaces;

namespace ChemistWarehousePizzeria.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public async Task<PizzaDto?> GetPizzaByIdAsync(int id)
        {
            var pizza = await _pizzaRepository.GetByIdAsync(id);
            if(pizza != null) 
            {
                return new PizzaDto { Id = pizza.Id, Name = pizza.Name };
            }

            return null;
        }

        public Task<List<Pizza>> GetPizzasAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePizzaAsync(PizzaDto pizza)
        {
            throw new NotImplementedException();
        }
    }
}
