using System;
using System.Collections.Generic;

namespace ChemistWarehousePizzeria.Models.Dtos;

public partial class PizzeriaDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? LocationId { get; set; }

    public virtual LocationDto? Location { get; set; }

    public MenuDto? Menu { get; set; } = new MenuDto();
}
