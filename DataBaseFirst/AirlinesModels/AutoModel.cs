using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class AutoModel
{
    public long AutoModelId { get; set; }

    public string Make { get; set; } = null!;

    public string Color { get; set; } = null!;

    public int YearOfManufacture { get; set; }

    public int EngineNumber { get; set; }

    public long CategoryId { get; set; }

    public virtual ICollection<Auto> Autos { get; set; } = new List<Auto>();

    public virtual Category Category { get; set; } = null!;
}
