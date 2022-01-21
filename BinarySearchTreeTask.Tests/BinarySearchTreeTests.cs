using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BinarySearchTreeTask.Tests
{
    [TestFixtureSource(typeof(TestFixtures), nameof(TestFixtures.Fixtures))]
    public class BinarySearchTreeTests<T>
    {
        private readonly BinarySearchTree<T> tree;
        private readonly T[] array;
        private readonly T value;
        private readonly int initCount;
        private readonly IComparer<T> comparer;

        public BinarySearchTreeTests(T[] source, T value, int count, IComparer<T> comparer)
        {
            this.tree = new BinarySearchTree<T>(source, comparer);
            this.value = value;
            this.initCount = count;
            this.array = source;
            this.comparer = comparer;
        }

        [Test]
        public void Ctor_BasedOnComparer()
        {
            var tree = new BinarySearchTree<T>(this.comparer);
            tree.Add(this.value);
            CollectionAssert.Contains(tree, this.value);
        }

        [Test]
        [Order(0)]
        public void Ctor_BasedOnEnumerableSource()
        {
            Assert.That(this.tree.Count == this.initCount);
        }

        [Test]
        [Order(1)]
        public void DefaultIterator_Test()
        {
            int i = 0;
            T[] sortedArray = (T[])this.array.Clone();
            Array.Sort(sortedArray, this.comparer);
            foreach (T item in this.tree)
            {
                Assert.AreEqual(item, sortedArray[i++]);
            }
        }

        [Test]
        [Order(2)]
        public void Add_OneElement()
        {
            int count = this.tree.Count;
            this.tree.Add(this.value);
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(this.tree, this.value);
                Assert.That(this.tree.Count == count + 1);
            });
        }

        [Test]
        [Order(3)]
        public void Contains_Test()
        {
            Assert.IsTrue(this.tree.Contains(this.value));
        }

        [Test]
        [Order(4)]
        public void Remove_OneElement()
        {
            int count = this.tree.Count;
            this.tree.Remove(this.value);
            Assert.Multiple(() =>
            {
                CollectionAssert.DoesNotContain(this.tree, this.value);
                Assert.That(this.tree.Count == count - 1);
            });
        }

        [Test]
        [Order(5)]
        public void Remove_ItemIsNotExist_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.tree.Remove(this.value), "Invalid operation remove, item is not exist.");
        }

        [Test]
        [Order(6)]
        public void Clear_Test()
        {
            this.tree.Clear();
            Assert.Multiple(() =>
            {
                CollectionAssert.IsEmpty(this.tree);
                Assert.That(this.tree.Count == 0);
            });
        }

        [Test]
        [Order(7)]
        public void Remove_TreeIsEmpty_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.tree.Remove(this.value), "Invalid operation remove, tree is empty.");
        }
    }
}
