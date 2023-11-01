using ChemistWarehousePizzeria.Models;
using ChemistWarehousePizzeria.Repositories.Interfaces;

namespace ChemistWarehousePizzeria.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzeriaDbContext _dbContext;

        public PizzaRepository(PizzeriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Pizza>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Pizza?> GetByIdAsync(int id)
        {
            return await _dbContext.Pizzas.FindAsync(id);
        }

        public async Task AddAsync(Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Pizza pizza)
        {
            _dbContext.Set<Pizza>().Update(pizza);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pizza pizza)
        {
            throw new NotImplementedException();
        }
    }

}
