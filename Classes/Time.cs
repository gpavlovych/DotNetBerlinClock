using System;

namespace BerlinClock
{
    public struct Time: ITime
    {
        public Time(int hours, int minutes, int seconds)
        {
            if (hours < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(hours), "Hours should not be negative");
            }

            Hours = hours;

            if (minutes < 0 || minutes >= 60)
            {
                throw new ArgumentOutOfRangeException(nameof(minutes), "Minutes should be between 0 and 59");
            }

            Minutes = minutes;

            if (seconds < 0 || seconds >= 60)
            {
                throw new ArgumentOutOfRangeException(nameof(seconds), "Seconds should be between 0 and 59");
            }

            Seconds = seconds;
        }

        public int Hours { get; }

        public int Minutes { get; }

        public int Seconds { get; }
    }
}