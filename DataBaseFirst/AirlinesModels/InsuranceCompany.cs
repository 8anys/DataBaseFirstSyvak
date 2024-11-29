using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class InsuranceCompany
{
    public long InsuranceCompanyId { get; set; }

    public string InsuranceCompanyName { get; set; } = null!;

    public DateTime EstablishedDate { get; set; }

    public virtual ICollection<Insurance> Insurances { get; set; } = new List<Insurance>();
}
