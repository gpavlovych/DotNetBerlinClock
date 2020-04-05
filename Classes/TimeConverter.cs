using System.Text;
using BerlinClock.Classes;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly ILampRowDrawer[] builders;
        private readonly ITimeParser timeParser;
        public TimeConverter()
        {
            this.timeParser = new TimeParser();
            this.builders = new ILampRowDrawer[]
            {
                new LampRowBuilder().WithMaximumValue(2).WithYellowOnCharacter().WithValue(time => (time.Seconds+1) % 2).Build(),
                new LampRowBuilder().WithMaximumValue(24).WithIncrement(5).WithRedOnCharacter().WithValue(time => time.Hours).Build(),
                new LampRowBuilder().WithMaximumValue(5).WithRedOnCharacter().WithValue(time => time.Hours % 5).Build(),
                new LampRowBuilder().WithMaximumValue(60).WithIncrement(5).WithCustomOnCharacter(val => val % 15 == 10 ? 'R' : 'Y').WithValue(time => time.Minutes).Build(),
                new LampRowBuilder().WithMaximumValue(5).WithYellowOnCharacter().WithValue(time => time.Minutes % 5).Build(),
            };
        }

        public string convertTime(string aTime)
        {
            var parsedTime = timeParser.Parse(aTime);
            var clockBuilder = new StringBuilder();
            for (var builderIndex = 0; builderIndex < builders.Length; builderIndex++)
            {
                var builder = builders[builderIndex];
                builder.Build(clockBuilder, parsedTime);
                if (builderIndex < builders.Length - 1)
                {
                    clockBuilder.AppendLine();
                }
            }
            return clockBuilder.ToString();
        }
    }
}
