using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Registration
{
    public long RegistrationId { get; set; }

    public int RegistrationNumber { get; set; }

    public DateTime RegistrationDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    public string RegistrationType { get; set; } = null!;

    public virtual ICollection<Auto> Autos { get; set; } = new List<Auto>();
}
