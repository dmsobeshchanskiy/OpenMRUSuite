using OpenMRU.Core.View.Interfaces;
using System;

namespace CoreTests.Mocks
{
    public class MockDateProvider : IDateProvider
    {
        public DateTime Now
        {
            get; private set;
        }

        public DayOfWeek FirstDayOfWeek
        {
            get; private set;
        }

        public MockDateProvider (DateTime date, DayOfWeek firstDayOfWeek)
        {
            Now = date;
            FirstDayOfWeek = firstDayOfWeek;
        }

    }
}
