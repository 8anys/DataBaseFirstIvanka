using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class City
{
    public long CityId { get; set; }

    public string CityName { get; set; } = null!;

    public virtual ICollection<Adre> Adres { get; set; } = new List<Adre>();

    public virtual ICollection<District> Districts { get; set; } = new List<District>();
}
