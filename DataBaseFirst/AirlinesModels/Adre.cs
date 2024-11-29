﻿using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Adre
{
    public long AdresId { get; set; }

    public long CityId { get; set; }

    public long DistrictId { get; set; }

    public long StreetId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual District District { get; set; } = null!;

    public virtual ICollection<ServiceCenter> ServiceCenters { get; set; } = new List<ServiceCenter>();

    public virtual Street Street { get; set; } = null!;
}
