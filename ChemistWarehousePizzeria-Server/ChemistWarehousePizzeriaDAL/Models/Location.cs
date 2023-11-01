using System;
using System.Collections.Generic;

namespace ChemistWarehousePizzeria.Models;

public partial class Location
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Pizzeria> Pizzeria { get; } = new List<Pizzeria>();

    public virtual ICollection<Price> Prices { get; } = new List<Price>();
}
