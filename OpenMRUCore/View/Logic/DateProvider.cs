using OpenMRU.Core.View.Interfaces;
using System;
using System.Threading;

namespace OpenMRU.Core.View.Logic
{
    internal class DateProvider : IDateProvider
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public DayOfWeek FirstDayOfWeek
        {
            get
            {
                return Thread.CurrentThread.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            }
        }
    }
}
