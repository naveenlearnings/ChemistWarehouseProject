namespace ChemistWarehousePizzeria.Models.Dtos
{
    public class PizzaDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int LocationId { get; set; }
        public string? Toppings { get; set; }
        public int Quentity { get; set; }
        public decimal? Price { get; set;}
    }
}
