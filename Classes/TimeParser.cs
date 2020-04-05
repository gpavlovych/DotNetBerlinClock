using System;

namespace BerlinClock
{
    public sealed class TimeParser: ITimeParser
    {
        public ITime Parse(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var parsedValues = new[] {0, 0, 0};
            var currentPosition = 0;
            for(var valIndex = 0; valIndex < value.Length; valIndex++)
            {
                var val = value[valIndex];
                if (val == ':' && currentPosition < value.Length - 1)
                {
                    currentPosition++;
                    continue;
                }

                if (val >= '0' && val <= '9')
                {
                    parsedValues[currentPosition] *= 10;
                    parsedValues[currentPosition] += val - '0';
                    continue;
                }

                throw new ArgumentException($"Invalid character '{val}' at position {valIndex} in '{value}'", nameof(value));
            }

            if (currentPosition == 0)
            {
                throw new ArgumentException($"Invalid string format '{value}'", nameof(value));
            }

            return new Time(parsedValues[0], parsedValues[1], parsedValues[2]);
        }
    }
}