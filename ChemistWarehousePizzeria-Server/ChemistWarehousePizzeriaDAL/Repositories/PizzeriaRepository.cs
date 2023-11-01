using Microsoft.EntityFrameworkCore;
using ChemistWarehousePizzeria.Models.Dtos;
using ChemistWarehousePizzeria.Models;
using ChemistWarehousePizzeria.Repositories.Interfaces;

namespace ChemistWarehousePizzeria.Repositories
{
    public class PizzeriaRepository : IPizzeriaRepository
    {
        private readonly PizzeriaDbContext _dbContext;

        public PizzeriaRepository(PizzeriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Pizzeria>> GetPizzeriasAsync()
        {
            return
            await _dbContext.Pizzeria
                .Include(l => l.Location)
                .Include(p => p.Menus)
                    .ThenInclude(m => m.PizzaMenus)
                        .ThenInclude(pm => pm.Pizza)
                            .ThenInclude(p => p.Prices)
                .ToListAsync();
        }

        public async Task<Pizzeria?> GetPizzeriaByIdAsync(int pizzeriaId)
        {
            var pizzerias = await _dbContext.Pizzeria.Where(x=>x.Id == pizzeriaId)
                .Include(l => l.Location)
                .Include(p => p.Menus)
                    .ThenInclude(m => m.PizzaMenus)
                        .ThenInclude(pm => pm.Pizza)
                            .ThenInclude(p => p.Prices)
                .ToListAsync();
            return pizzerias.SingleOrDefault();
        }
    }
}
