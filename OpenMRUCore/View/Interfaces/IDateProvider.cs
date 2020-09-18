using System;

namespace OpenMRU.Core.View.Interfaces
{
    internal interface IDateProvider
    {
        DateTime Now { get; }

        DayOfWeek FirstDayOfWeek { get; }
    }
}
