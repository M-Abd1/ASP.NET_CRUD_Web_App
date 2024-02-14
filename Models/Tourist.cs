using System;
using System.Collections.Generic;

namespace Bliss_Travels___Tours.Models;

public partial class Tourist
{
    public string TouristId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int TourId { get; set; }

    public virtual TourManager Tour { get; set; } = null!;
}
