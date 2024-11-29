using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Inspection
{
    public long InspectionId { get; set; }

    public DateTime InspectionDate { get; set; }

    public string InspectionType { get; set; } = null!;

    public virtual ICollection<Auto> Autos { get; set; } = new List<Auto>();
}
