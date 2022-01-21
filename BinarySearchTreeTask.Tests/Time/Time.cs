#pragma warning disable CA1815

namespace BinarySearchTreeTask.Tests
{
    public struct Time
    {
        public Time(int minutes)
            : this(default, minutes)
        {
        }

        public Time(int hours, int minutes)
        {
            const int minuteCylce = 60, hourCycle = 24;

            hours += RemoveFullCycles(ref minutes, minuteCylce);
            RemoveFullCycles(ref hours, hourCycle);

            this.Hours = hours;
            this.Minutes = minutes;

            int RemoveFullCycles(ref int value, int cycle)
            {
                int countOfCylces = value / cycle, result = 0;
                value -= countOfCylces * cycle;
                if (value < 0)
                {
                    value += cycle;
                    result--;
                }

                return result + countOfCylces;
            }
        }

        public readonly int Hours { get; }

        public readonly int Minutes { get; }

        public new string ToString()
        {
            return $"{this.Hours:d2}:{this.Minutes:d2}";
        }

        public void Deconstruct(out int hours, out int minutes)
        {
            hours = this.Hours;
            minutes = this.Minutes;
        }
    }
}
