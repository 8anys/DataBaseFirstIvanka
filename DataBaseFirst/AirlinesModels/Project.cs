using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Project
{
    public long ProjectId { get; set; }

    public string ProjectFullName { get; set; } = null!;

    public string ProjectShortName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
