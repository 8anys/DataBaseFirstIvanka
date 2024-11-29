using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class District
{
    public long DistrictId { get; set; }

    public string DistrictName { get; set; } = null!;

    public long CityId { get; set; }

    public virtual ICollection<Adre> Adres { get; set; } = new List<Adre>();

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Street> Streets { get; set; } = new List<Street>();
}
