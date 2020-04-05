using System;

namespace BerlinClock.Classes
{
    public class LampRowBuilder
    {
        private int maximumValue;
        private int increment = 1;
        private Func<int, char> charOnFunc;
        private Func<ITime, int> valueFunc;

        public LampRowBuilder WithMaximumValue(int value)
        {
            this.maximumValue = value;
            return this;
        }

        public LampRowBuilder WithIncrement(int value)
        {
            this.increment = value;
            return this;
        }

        public LampRowBuilder WithRedOnCharacter()
        {
            this.charOnFunc = val => 'R';
            return this;
        }

        public LampRowBuilder WithYellowOnCharacter()
        {
            this.charOnFunc = val => 'Y';
            return this;
        }

        public LampRowBuilder WithCustomOnCharacter(Func<int, char> valueFunc)
        {
            this.charOnFunc = valueFunc;
            return this;
        }

        public LampRowBuilder WithValue(Func<ITime, int> valueFunc)
        {
            this.valueFunc = valueFunc;
            return this;
        }

        public ILampRowDrawer Build()
        {
            return new LampRowDrawer(this.maximumValue, this.increment, this.charOnFunc, this.valueFunc);
        }
    }
}
