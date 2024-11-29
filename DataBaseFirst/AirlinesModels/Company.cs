using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Company
{
    public long CompanyId { get; set; }

    public string CompanyFullName { get; set; } = null!;

    public string CompanyShortName { get; set; } = null!;

    public virtual ICollection<Departament> Departaments { get; set; } = new List<Departament>();
}
