using System;
using System.Collections.Generic;

namespace ChemistWarehousePizzeria.Models;

public partial class Menu
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? PizzeriaId { get; set; }

    public virtual ICollection<PizzaMenu> PizzaMenus { get; } = new List<PizzaMenu>();

    public virtual Pizzeria? Pizzeria { get; set; }
}
