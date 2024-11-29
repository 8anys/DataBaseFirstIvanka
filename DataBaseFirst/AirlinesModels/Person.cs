using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Person
{
    public long PersonId { get; set; }

    public string Fname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Sname { get; set; } = null!;

    public DateTime WhenBorn { get; set; }

    public short Sex { get; set; }

    public long EducationLevelId { get; set; }

    public long SpecialityId { get; set; }

    public virtual EducationLevel EducationLevel { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<PersonContact> PersonContacts { get; set; } = new List<PersonContact>();

    public virtual Speciality Speciality { get; set; } = null!;
}
