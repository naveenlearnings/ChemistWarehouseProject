using System;
using System.Collections.Generic;

namespace ChemistWarehousePizzeria.Models;

public partial class PizzaMenu
{
    public int Id { get; set; }

    public int MenuId { get; set; }

    public int PizzaId { get; set; }

    public virtual Menu Menu { get; set; } = null!;

    public virtual Pizza Pizza { get; set; } = null!;
}
