using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Auto
{
    public long AutoId { get; set; }

    public long AutoModelId { get; set; }

    public string AutoName { get; set; } = null!;

    public string Color { get; set; } = null!;

    public long RegistrationId { get; set; }

    public long InsuranceId { get; set; }

    public long InspectionsId { get; set; }

    public long CategoryId { get; set; }

    public long PersonId { get; set; }

    public virtual ICollection<AutoFine> AutoFines { get; set; } = new List<AutoFine>();

    public virtual AutoModel AutoModel { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual Inspection Inspections { get; set; } = null!;

    public virtual Insurance Insurance { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual Registration Registration { get; set; } = null!;

    public virtual ICollection<ServiceCenter> ServiceCenters { get; set; } = new List<ServiceCenter>();
}
