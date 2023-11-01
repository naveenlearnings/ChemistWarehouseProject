using ChemistWarehousePizzeria.Models;
using ChemistWarehousePizzeria.Models.Dtos;

namespace ChemistWarehousePizzeria.Services.Interfaces
{
    public interface IPizzeriaService
    {
        Task<List<PizzeriaDto>> GetPizzeriasAsync();
        Task<PizzeriaDto?> GetPizzeriaByIdAsync(int pizzeriaId);
        Task UpdatePizzeriaAsync(int id, PizzeriaDto pizzeria);
    }
}
