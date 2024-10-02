
using FlightsBooking.Domain.Common.Models;

namespace FlightsBooking.Domain.Flights.ValueObjects
{
    public sealed class Schedule : ValueObject
    {
        private Schedule(TimeOnly time, DayOfWeek[] daysOfWeek)
        {
            Time = time;
            DaysOfWeek = daysOfWeek;
        }

        public TimeOnly Time { get; }
        public DayOfWeek[] DaysOfWeek { get; }

        public static Schedule Create(TimeOnly time, DayOfWeek[] daysOfWeek)
        {
            if (daysOfWeek == null || daysOfWeek.Length == 0) throw new ArgumentNullException(nameof(daysOfWeek));
            return new Schedule(time, daysOfWeek);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Time;
            foreach (var day in DaysOfWeek)
            {
                yield return day;
            }
        }

    }
}
