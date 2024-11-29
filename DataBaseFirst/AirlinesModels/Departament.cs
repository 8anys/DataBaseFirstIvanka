using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Departament
{
    public long DepartamentId { get; set; }

    public string DepartamentFullName { get; set; } = null!;

    public string DepartamentShortName { get; set; } = null!;

    public long AdresId { get; set; }

    public long NumberOfVacancies { get; set; }

    public long CompanyId { get; set; }

    public virtual Adre Adres { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
