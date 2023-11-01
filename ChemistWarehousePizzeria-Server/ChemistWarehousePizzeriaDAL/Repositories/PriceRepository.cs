using ChemistWarehousePizzeria.Models;
using ChemistWarehousePizzeria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChemistWarehousePizzeria.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        private readonly PizzeriaDbContext _dbContext;

        public PriceRepository(PizzeriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(Price pizza)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Price pizza)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Price>> GetAllAsync()
        {
            return await _dbContext.Prices.ToListAsync();
        }

        public async Task<Price?> GetByIdAsync(int id)
        {
            return await _dbContext.FindAsync<Price>(id);
        }

        public async Task UpdateAsync(Price price)
        {
            _dbContext.Set<Price>().Update(price);
            await _dbContext.SaveChangesAsync();
        }
    }
}
