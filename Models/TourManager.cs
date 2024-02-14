using System;
using System.Collections.Generic;

namespace Bliss_Travels___Tours.Models;

public partial class TourManager
{
    public int TourId { get; set; }

    public string StartingPosition { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public string DepartureDate { get; set; } = null!;

    public string ReturnDate { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Tourist> Tourists { get; set; } = new List<Tourist>();
}
