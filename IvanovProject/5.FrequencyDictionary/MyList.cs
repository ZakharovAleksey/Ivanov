using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.FrequencyDictionary
{
    class Node<T> where T : class
    {
        public T Value { get; set; } = null;
        public int Count { get; set; } = 1;

        public Node<T> Next { get; set; } = null;

        public override string ToString()
            => string.Format("Value: {0}, count = {1}", Value, Count);
    }

    class MyLinkedList<T> : IListInterface<T> where T : class
    {

        #region Methods

        public void Add(T value)
        {
            if (root == null)
            {
                root = new Node<T>();
                root.Value = value;
            }
            else
            {
                Node<T> currentNode = root;
                while (currentNode.Next != null)
                {
                    // If current value alreary in text then increment it's count
                    if (currentNode.Value == value)
                    {
                        ++currentNode.Count;
                        return;
                    }
                    else
                        currentNode = currentNode.Next;
                }
                currentNode.Next = new Node<T>();
                currentNode.Next.Value = value;
            }
        }


        public void Insert(T value, int position)
        {
            Node<T> currentNode = root;
            int curNodeID = -1;
            while (currentNode.Next != null)
            {
                if (curNodeID + 1 == position)
                {
                    Node<T> insNode = new Node<T>();
                    insNode.Value = value;
                    insNode.Next = currentNode.Next;
                    currentNode.Next = insNode;
                }
                currentNode = currentNode.Next;
                ++curNodeID;
            }
        }

        public void Display()
        {
            Node<T> currentNode = root;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode);
                currentNode = currentNode.Next;
            }
        }

        public int Count()
        {
            Node<T> currentNode = root;
            int elemCount = 0;
            while (currentNode != null)
            {
                currentNode = currentNode.Next;
                ++elemCount;
            }

            return elemCount;
        }

        #endregion

        #region Fields

        private Node<T> root = null;

        #endregion
    }
}
