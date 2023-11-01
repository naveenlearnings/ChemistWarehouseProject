using ChemistWarehousePizzeria.Models;

namespace ChemistWarehousePizzeria.Services.Interfaces
{
    public interface IMenuService
    {
        // Adds a new menu to a pizzeria
        Task AddMenuAsync(int pizzeriaId, Menu menu);

        // Updates an existing menu of a pizzeria
        Task UpdateMenuAsync(int pizzeriaId, Menu menu);

        // Deletes a menu from a pizzeria
        Task DeleteMenuAsync(int pizzeriaId, int menuId);

        // Retrieves a list of all menus available in a pizzeria
        Task<List<Menu>> GetMenusAsync(int pizzeriaId);

        Task<Menu> GetMenuByIdAsync(int menuId);
    }

}
