using ChemistWarehousePizzeria.Models.Dtos;
using ChemistWarehousePizzeria.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChemistWarehousePizzeria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        //// I will inject an OrderService here instead of PizzeriaService.
        //private readonly IPizzeriaService _pizzeriaService;

        //public OrdersController(IPizzeriaService pizzeriaService)
        //{
        //    _pizzeriaService = pizzeriaService;
        //}

        public OrdersController()
        {

        }

        [HttpPost]
        public IActionResult Post(OrderDto order)
        {
            //This orderDto object contains all the information including person's name, phone, address,
            //PizzaId, locationId, extra toppings etc. We can save this order in the database using OrderService and OrderRepository. 
            return Ok();
        }
    }
}
