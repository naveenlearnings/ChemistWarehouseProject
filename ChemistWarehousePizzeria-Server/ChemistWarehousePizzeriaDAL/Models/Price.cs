using System;
using System.Collections.Generic;

namespace ChemistWarehousePizzeria.Models;

public partial class Price
{
    public int Id { get; set; }

    public decimal? Value { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public int? LocationId { get; set; }

    public int? PizzaId { get; set; }

    public virtual Location? Location { get; set; }

    public virtual Pizza? Pizza { get; set; }
}
