using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Employee
{
    public long EmployeeId { get; set; }

    public long PersonId { get; set; }

    public long JobId { get; set; }

    public long DepartamentId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public long SalaryId { get; set; }

    public long ProjectId { get; set; }

    public virtual Departament Departament { get; set; } = null!;

    public virtual Job Job { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual Salary Salary { get; set; } = null!;
}
