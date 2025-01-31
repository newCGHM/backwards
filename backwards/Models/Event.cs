using System;
using System.Collections.Generic;

namespace backwards.Models;

public partial class Event
{
    public long Id { get; set; }

    public string Description { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<EventItem> EventItems { get; set; } = new List<EventItem>();

    public virtual ICollection<EventUser> EventUsers { get; set; } = new List<EventUser>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
