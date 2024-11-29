using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Category
{
    public long CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public int MaxWeight { get; set; }

    public int MaxPassengers { get; set; }

    public virtual ICollection<AutoModel> AutoModels { get; set; } = new List<AutoModel>();

    public virtual ICollection<Auto> Autos { get; set; } = new List<Auto>();
}
