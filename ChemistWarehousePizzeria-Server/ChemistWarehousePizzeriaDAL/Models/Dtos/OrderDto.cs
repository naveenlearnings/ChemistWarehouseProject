namespace ChemistWarehousePizzeria.Models.Dtos
{
    public class OrderDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public List<PizzaDto>? Pizzas { get; set; }
    }
}
