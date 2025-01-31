using System;
using System.Collections.Generic;

namespace backwards.Models;

public partial class EntityAttributeValue
{
    public long Id { get; set; }

    public string EntityName { get; set; } = null!;

    public string EntityAttribute { get; set; } = null!;

    public string EntityValue { get; set; } = null!;

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }
}
