using ChemistWarehousePizzeria.Models;

namespace ChemistWarehousePizzeria.Repositories.Interfaces
{
    public interface IPriceRepository
    {
        Task<IEnumerable<Price>> GetAllAsync();
        Task<Price?> GetByIdAsync(int id);
        Task AddAsync(Price pizza);
        Task UpdateAsync(Price pizza);
        Task DeleteAsync(Price pizza);
    }
}
