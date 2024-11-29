using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class EducationLevel
{
    public long EducationLevelId { get; set; }

    public string EducationLevelFull { get; set; } = null!;

    public string EducationLevelShort { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
