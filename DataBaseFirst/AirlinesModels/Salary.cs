using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Salary
{
    public long SalaryId { get; set; }

    public long SalaryInUsd { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
