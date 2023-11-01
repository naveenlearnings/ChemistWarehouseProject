using ChemistWarehousePizzeria.Models;
using ChemistWarehousePizzeria.Models.Dtos;
using ChemistWarehousePizzeria.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChemistWarehousePizzeria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzeriasController : ControllerBase
    {
        private readonly IPizzeriaService _pizzeriaService;

        public PizzeriasController(IPizzeriaService pizzeriaService)
        {
            _pizzeriaService = pizzeriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzeriaDto>>> Get()
        {
            try
            {
                IEnumerable<PizzeriaDto> pizzerias = await _pizzeriaService.GetPizzeriasAsync();
                return Ok(pizzerias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{pizzeriaId}")]
        public async Task<IActionResult> Get(int pizzeriaId)
        {
            try
            {
                PizzeriaDto? pizzeria = await _pizzeriaService.GetPizzeriaByIdAsync(pizzeriaId);
                if (pizzeria == null)
                {
                    return NotFound();
                }
                return Ok(pizzeria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{pizzeriaId}")]
        public async Task<IActionResult> Put(int pizzeriaId, [FromBody] PizzeriaDto pizzeriaDto)
        {
            try
            {
                await _pizzeriaService.UpdatePizzeriaAsync(pizzeriaId, pizzeriaDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

}
