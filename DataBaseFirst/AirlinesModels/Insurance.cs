using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Insurance
{
    public long InsuranceId { get; set; }

    public long InsuranceCompanyId { get; set; }

    public int PolicyNumber { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    public virtual ICollection<Auto> Autos { get; set; } = new List<Auto>();

    public virtual InsuranceCompany InsuranceCompany { get; set; } = null!;
}
