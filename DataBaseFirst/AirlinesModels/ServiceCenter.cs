using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class ServiceCenter
{
    public long ServiceCenterId { get; set; }

    public string ServiceCenterName { get; set; } = null!;

    public long AdresId { get; set; }

    public int WorkingHour { get; set; }

    public long AutoId { get; set; }

    public virtual Adre Adres { get; set; } = null!;

    public virtual Auto Auto { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
