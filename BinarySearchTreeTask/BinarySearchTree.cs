using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTreeTask
{
    /// <summary>
    /// Represents extendable collection of the specified type T.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the <see cref="BinarySearchTree{T}"/>.</typeparam>
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private readonly IComparer<T> comparer;
        private Node<T> root;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree()
            : this(Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="source">The collection to copy elements from.</param>
        public BinarySearchTree(IEnumerable<T> source)
            : this(source, Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">Comparer which will use for operations with tree.</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="source">The collection to copy elements from.</param>
        /// <param name="comparer">Comparer which will use for operations with tree.</param>
        public BinarySearchTree(IEnumerable<T> source, IComparer<T> comparer)
            : this(comparer)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            foreach (T item in source)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Adds an object at the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <param name="item">The object to add into the <see cref="BinarySearchTree{T}"/>.</param>
        public void Add(T item)
        {
            this.root = AddNode(item, this.root);
            this.Count++;

            Node<T> AddNode(T item, Node<T> node)
            {
                if (node is null)
                {
                    node = new Node<T>(item);
                }
                else
                {
                    if (this.comparer.Compare(item, node.Item) < 0)
                    {
                        node.Left = AddNode(item, node.Left);
                    }
                    else
                    {
                        node.Right = AddNode(item, node.Right);
                    }
                }

                return node;
            }
        }

        /// <summary>
        /// Removes one object from <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="BinarySearchTree{T}"/>.</param>
        public void Remove(T item)
        {
            if (this.root is null)
            {
                throw new InvalidOperationException("There are no elements in the tree.");
            }

            if (!this.Contains(item))
            {
                throw new InvalidOperationException("There is no element to remove in the tree.");
            }

            this.root = RemoveNode(this.root, item);
            this.Count--;

            Node<T> RemoveNode(Node<T> node, T item)
            {
                if (node is null)
                {
                    return null;
                }

                if (this.comparer.Compare(item, node.Item) < 0)
                {
                    node.Left = RemoveNode(node.Left, item);
                }
                else if (this.comparer.Compare(item, node.Item) > 0)
                {
                    node.Right = RemoveNode(node.Right, item);
                }
                else if (node.Left != null && node.Right != null)
                {
                    Node<T> tempNode = node, minNode = Min(node.Right);
                    node = new Node<T>(minNode.Item);
                    node.Left = tempNode.Left;
                    node.Right = RemoveNode(tempNode.Right, node.Item);
                }
                else if (node.Left != null)
                {
                    return node.Left;
                }
                else
                {
                    return node.Right;
                }

                return node;
            }

            Node<T> Min(Node<T> node)
            {
                if (node != null && node.Left != null)
                {
                    node = Min(node.Left);
                }

                return node;
            }
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="BinarySearchTree{T}"/>.</param>
        /// <returns>Return <see langword="true"/> if item is found in the <see cref="BinarySearchTree{T}"/>; otherwise, <see langword="false"/>.</returns>
        public bool Contains(T item)
        {
            return ContainItem(item, this.root);

            bool ContainItem(T item, Node<T> node)
            {
                if (node is null)
                {
                    return false;
                }

                if (this.comparer.Compare(item, node.Item) == 0)
                {
                    return true;
                }
                else if (this.comparer.Compare(item, node.Item) < 0)
                {
                    return ContainItem(item, node.Left);
                }
                else
                {
                    return ContainItem(item, node.Right);
                }
            }
        }

        /// <summary>
        /// Traverses the tree in pre order.
        /// </summary>
        /// <returns>Enumerable which contains elements in pre order.</returns>
        public IEnumerable<T> TraversePreOrder()
        {
            return PreOrder(this.root);

            IEnumerable<T> PreOrder(Node<T> node)
            {
                if (node == null)
                {
                    yield break;
                }

                yield return node.Item;
                foreach (T item in PreOrder(node.Left))
                {
                    yield return item;
                }

                foreach (T item in PreOrder(node.Right))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Traverses the tree in in order.
        /// </summary>
        /// <returns>Enumerable which contains elements in in order.</returns>
        public IEnumerable<T> TraverseInOrder()
        {
            return InOrder(this.root);

            IEnumerable<T> InOrder(Node<T> node)
            {
                if (node == null)
                {
                    yield break;
                }

                foreach (T item in InOrder(node.Left))
                {
                    yield return item;
                }

                yield return node.Item;
                foreach (T item in InOrder(node.Right))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Traverses the tree in postorder.
        /// </summary>
        /// <returns>Enumerable which contains elements in postorder.</returns>
        public IEnumerable<T> TraversePostOrder()
        {
            return PostOrder(this.root);

            IEnumerable<T> PostOrder(Node<T> node)
            {
                if (node == null)
                {
                    yield break;
                }

                foreach (T item in PostOrder(node.Left))
                {
                    yield return item;
                }

                foreach (T item in PostOrder(node.Right))
                {
                    yield return item;
                }

                yield return node.Item;
            }
        }

        /// <summary>
        /// Clears tree.
        /// </summary>
        public void Clear()
        {
            this.root = Clear(this.root);
            this.Count = 0;

            Node<T> Clear(Node<T> node)
            {
                if (node == null)
                {
                    return null;
                }

                if (node.Left != null)
                {
                    node.Left = Clear(node.Left);
                }

                if (node.Right != null)
                {
                    node.Right = Clear(node.Right);
                }

                return null;
            }
        }

        /// <summary>
        /// Returns an in order enumerator for the tree.
        /// </summary>
        /// <returns>In order enumerator object for the tree.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.TraverseInOrder().GetEnumerator();
        }

        /// <summary>
        /// Returns an in order enumerator for the tree.
        /// </summary>
        /// <returns>In order enumerator object for the tree.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class Node<Type>
        {
            public Node(Type item)
            {
                this.Item = item;
            }

            public Type Item { get; }

            public Node<Type> Left { get; set; }

            public Node<Type> Right { get; set; }
        }
    }
}
