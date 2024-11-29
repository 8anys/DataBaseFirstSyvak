using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class AutoFine
{
    public long FineId { get; set; }

    public long AutoId { get; set; }

    public long ViolationId { get; set; }

    public DateTime FineDate { get; set; }

    public decimal Amount { get; set; }

    public virtual Auto Auto { get; set; } = null!;

    public virtual Violation Violation { get; set; } = null!;
}
