using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.FrequencyDictionary.Tree
{
    class MyNode<T> where T : class
    {
        public MyNode() { }

        public T Value { get; set; } = null;
        public int Count { get; set; } = 1;

        public MyNode<T> Right { get; set; } = null;
        public MyNode<T> Left { get; set; } = null;


        public override string ToString()
        => string.Format("{0}: count: {1}", Value, Count);
    }

    class MyBinTree<T> where T : class, IComparable
    {

        #region Constructor

        public MyBinTree() { }

        #endregion


        #region Methods

        public void Add(T curValue)
        {
            if (Root == null)
            {
                Root = new MyNode<T>();
                Root.Value = curValue;

            }
            else
            {
                MyNode<T> insNode = new MyNode<T>();
                insNode.Value = curValue;

                MyNode<T> parentNode = new MyNode<T>();

                MyNode<T> curNode = Root;
                while (curNode != null)
                {
                    parentNode = curNode;

                    if (curNode.Value.CompareTo(curValue) > 0)
                        curNode = curNode.Right;
                    else if (curNode.Value.CompareTo(curValue) < 0)
                        curNode = curNode.Left;
                    else if (curNode.Value.CompareTo(curValue) == 0)
                    {
                        ++curNode.Count;
                        return;
                    }
                }

                if (parentNode.Value.CompareTo(curValue) < 0)
                {
                    parentNode.Left = insNode;
                }
                else
                {
                    parentNode.Right = insNode;
                }  
            }
        }


        public void Display(MyNode<T> node, int level = 0)
        {
            if (node != null)
            {
                if (node.Left != null)
                    Display(node.Left, level + 1);
                for(int i = 0; i < level; ++i)
                    Console.Write("\t");
                Console.WriteLine(node);

                if (node.Right != null)
                    Display(node.Right, level + 1);
                
            }

        }

        #endregion

        #region Fields

        public MyNode<T> Root { get; set; } = null;

        #endregion
    }
}
