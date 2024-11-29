using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Speciality
{
    public long SpecialityId { get; set; }

    public string? SpecialityFullName { get; set; }

    public string? SpecialityShortName { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
