namespace BerlinClock
{
    public interface ITimeParser
    {
        ITime Parse(string value);
    }
}