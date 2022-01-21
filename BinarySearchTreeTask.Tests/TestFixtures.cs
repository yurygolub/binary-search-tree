using System.Collections.Generic;
using NUnit.Framework;

namespace BinarySearchTreeTask.Tests
{
    public class TestFixtures
    {
        public static IEnumerable<TestFixtureData> Fixtures
        {
            get
            {
                yield return new TestFixtureData(typeof(int), new[] { 12, 3, 4, int.MinValue, -12, int.MaxValue, 45, 12 }, 67, 8, Comparer<int>.Default);
                yield return new TestFixtureData(typeof(int), new[] { 12, 3, 4, int.MinValue, -12, int.MaxValue, 45, 12 }, 67, 8, new IntComparer());
                yield return new TestFixtureData(typeof(string), new[] { "12", "Zero", "Test", "Hello" }, "Hello, world!", 4, Comparer<string>.Default);
                yield return new TestFixtureData(typeof(string), new[] { "12", "Zero", "Test", "Hello" }, "Hello, world!", 4, new StringComparer());
                
                yield return new TestFixtureData(typeof(Book),
                    new[]
                    {
                        new Book("author", "title", "publisher", "3-598-21508-8"),
                        new Book("abc", "", "", ""),
                        new Book("fgdg", "titleqwe", "asdsf", "3-598-21507-X"),
                    },
                    new Book("Jon Skeet", "C# in Depth", "Manning Publications", "978-0-901-69066-1"), 3, Comparer<Book>.Default);

                yield return new TestFixtureData(typeof(Book),
                    new[]
                    {
                        new Book("author", "title", "publisher", "3-598-21508-8"),
                        new Book("abc", "", "", ""),
                        new Book("fgdg", "titleqwe", "asdsf", "3-598-21507-X"),
                    },
                    new Book("Jon Skeet", "C# in Depth", "Manning Publications", "978-0-901-69066-1"), 3, new BookComparer());

                yield return new TestFixtureData(typeof(Time),
                    new[]
                    {
                        new Time(10, 30),
                        new Time(16, 34),
                        new Time(18, 53),
                        new Time(0, 0),
                    },
                    new Time(23, 5), 4, new TimeComparer());
            }
        }
    }
}
