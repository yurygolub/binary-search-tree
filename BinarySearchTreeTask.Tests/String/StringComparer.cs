using System;
using System.Collections.Generic;

namespace BinarySearchTreeTask.Tests
{
    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x is null)
            {
                throw new ArgumentNullException(nameof(x));
            }

            if (y is null)
            {
                throw new ArgumentNullException(nameof(y));
            }

            return x.Length.CompareTo(y.Length);
        }
    }
}
