using System;
using System.Collections.Generic;

namespace backwards.Models;

public partial class EventUser
{
    public long Id { get; set; }

    public long EventId { get; set; }

    public string? AspNetUserId { get; set; }

    public long EventUserId { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Event Event { get; set; } = null!;
}
