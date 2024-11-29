using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class PersonContact
{
    public long PersonContactId { get; set; }

    public long ContactTypeId { get; set; }

    public long PersonId { get; set; }

    public virtual ContactType ContactType { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
