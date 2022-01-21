using System.Collections.Generic;

namespace BinarySearchTreeTask.Tests
{
    public class TimeComparer : IComparer<Time>
    {
        public int Compare(Time x, Time y)
        {
            if (x.Hours.CompareTo(y.Hours) != 0)
            {
                return x.Hours.CompareTo(y.Hours);
            }

            return x.Minutes.CompareTo(y.Minutes);
        }
    }
}
