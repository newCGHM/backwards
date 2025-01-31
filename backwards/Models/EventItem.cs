using System;
using System.Collections.Generic;

namespace backwards.Models;

public partial class EventItem
{
    public long Id { get; set; }

    public long EventId { get; set; }

    public long EventUserId { get; set; }

    public string Description { get; set; } = null!;

    public byte? Quantity { get; set; }

    public string? UnitOfMeasure { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Event Event { get; set; } = null!;
}
