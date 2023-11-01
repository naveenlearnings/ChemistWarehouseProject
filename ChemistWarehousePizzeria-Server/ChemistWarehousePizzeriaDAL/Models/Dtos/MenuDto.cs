using System;
using System.Collections.Generic;

namespace ChemistWarehousePizzeria.Models.Dtos;

public partial class MenuDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? PizzeriaId { get; set; }

    public virtual List<PizzaDto> Pizzas { get; set; } = new List<PizzaDto>();
}
