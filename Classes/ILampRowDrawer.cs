using System.Text;

namespace BerlinClock
{
    public interface ILampRowDrawer
    {
        void Build(StringBuilder builder, ITime time);
    }
}