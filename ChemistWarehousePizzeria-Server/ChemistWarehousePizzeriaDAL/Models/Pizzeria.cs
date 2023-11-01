using System;
using System.Collections.Generic;

namespace ChemistWarehousePizzeria.Models;

public partial class Pizzeria
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? LocationId { get; set; }

    public virtual Location? Location { get; set; }

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
