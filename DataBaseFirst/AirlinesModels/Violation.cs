using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Violation
{
    public long ViolationId { get; set; }

    public string Description { get; set; } = null!;

    public decimal PenaltyAmount { get; set; }

    public DateTime ViolationDate { get; set; }

    public virtual ICollection<AutoFine> AutoFines { get; set; } = new List<AutoFine>();
}
