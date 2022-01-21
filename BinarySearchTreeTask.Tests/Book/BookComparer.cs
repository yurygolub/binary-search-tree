using System;
using System.Collections.Generic;

namespace BinarySearchTreeTask.Tests
{
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x is null)
            {
                throw new ArgumentException($"{nameof(x)} can not be null.");
            }

            if (y is null)
            {
                throw new ArgumentException($"{nameof(y)} can not be null.");
            }

            if (string.Compare(x.Author, y.Author, StringComparison.InvariantCulture) != 0)
            {
                return string.Compare(x.Author, y.Author, StringComparison.InvariantCulture);
            }
            else if (x.Pages.CompareTo(y.Pages) != 0)
            {
                return x.Pages.CompareTo(y.Pages);
            }
            else if (x.Price.CompareTo(y.Price) != 0)
            {
                return x.Price.CompareTo(y.Price);
            }

            return 0;
        }
    }
}
