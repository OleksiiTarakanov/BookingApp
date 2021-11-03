using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Enums
{
    public enum Status
    {
        BookedPermanently = 0,
        BookedFullDay = 1,
        BookedFirstPartOfDay = 2,
        BookedSecondPartOfDay = 3,
        AvailableForBooking = 4
    }
}
