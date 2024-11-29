using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class ContactType
{
    public long ContactTypeId { get; set; }

    public string? ContactType1 { get; set; }

    public virtual ICollection<PersonContact> PersonContacts { get; set; } = new List<PersonContact>();
}
