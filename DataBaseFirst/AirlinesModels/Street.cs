using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Street
{
    public long StreetId { get; set; }

    public long DistrictId { get; set; }

    public string StreetName { get; set; } = null!;

    public virtual ICollection<Adre> Adres { get; set; } = new List<Adre>();

    public virtual District District { get; set; } = null!;
}
