using ChemistWarehousePizzeria.Models;
using ChemistWarehousePizzeria.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace ChemistWarehousePizzeria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMenusForPizzeria(int pizzeriaId)
        {
            try
            {
                IEnumerable<Menu> menus = await _menuService.GetMenusAsync(pizzeriaId);
                return Ok(menus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{menuId}")]
        public async Task<IActionResult> GetMenu(int menuId)
        {
            try
            {
                Menu menu = await _menuService.GetMenuByIdAsync(menuId);
                if (menu == null)
                {
                    return NotFound();
                }
                return Ok(menu);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Add additional endpoints for POST, PUT, and DELETE methods for creating, updating, and deleting menus for a specific pizzeria
    }
}
