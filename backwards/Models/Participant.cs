using System;
using System.Collections.Generic;

namespace backwards.Models;

public partial class Participant
{
    public long Id { get; set; }

    public long EventItemId { get; set; }

    public long EventUserId { get; set; }

    public byte? QtyContribution { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Event EventItem { get; set; } = null!;
}
