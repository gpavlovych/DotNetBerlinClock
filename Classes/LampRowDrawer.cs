using System;
using System.Text;

namespace BerlinClock
{
    public sealed class LampRowDrawer : ILampRowDrawer
    {
        private readonly Func<int, char> colorOn;
        private readonly char colorOff;
        private readonly int maximumNumber;
        private readonly int increment;
        private readonly Func<ITime, int> getValue;

        public LampRowDrawer(int maximumValue, int increment, Func<int, char> colorOn, Func<ITime, int> getValue)
        {
            if (maximumValue <= 1)
            {
                throw new ArgumentNullException(nameof(maximumValue), "maximumValue should be at least 2 or more");
            }

            if (increment <= 0 || increment >= maximumValue)
            {
                throw new ArgumentOutOfRangeException(nameof(increment),
                    $"Increment should be between 1 and {maximumValue - 1}");
            }

            this.increment = increment;
            this.maximumNumber = (maximumValue - 1) / increment;
            this.colorOn = colorOn ?? throw new ArgumentNullException(nameof(colorOn));
            this.colorOff = 'O';
            this.getValue = getValue ?? throw new ArgumentNullException(nameof(getValue));
        }

        public void Build(StringBuilder builder, ITime time)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (time == null)
            {
                throw new ArgumentNullException(nameof(time));
            }

            var onNumber = this.getValue(time) / increment;

            for (var currentValue = 0; currentValue < Math.Min(onNumber, maximumNumber); currentValue++)
            {
                builder.Append(this.colorOn(currentValue * increment));
            }

            for (var currentValue = onNumber; currentValue < maximumNumber; currentValue++)
            {
                builder.Append(this.colorOff);
            }
        }
    }
}