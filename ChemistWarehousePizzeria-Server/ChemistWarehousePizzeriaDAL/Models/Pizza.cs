using System;
using System.Collections.Generic;

namespace ChemistWarehousePizzeria.Models;

public partial class Pizza
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Toppings { get; set; }

    public virtual ICollection<PizzaMenu> PizzaMenus { get; } = new List<PizzaMenu>();

    public virtual ICollection<Price> Prices { get; } = new List<Price>();
}
