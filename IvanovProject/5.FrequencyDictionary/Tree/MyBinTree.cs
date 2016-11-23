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
        public int Count { get; set; } = 0;

        public MyNode<T> Right { get; set; } = null;
        public MyNode<T> Left { get; set; } = null;
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
                ++Root.Count;
            }
            else
            {
                MyNode<T> curNode = Root;
                while (curNode != null)
                {
                    if (curNode.Value.CompareTo(curValue) > 0)
                        curNode = curNode.Left;
                    else if (curNode.Value.CompareTo(curValue) < 0)
                        curNode = curNode.Right;
                    else if (curNode.Value.CompareTo(curValue) == 0)
                    {
                        ++curNode.Count;
                        return;
                    }
                }
                

            }

            /*
                void BinarySearchTree::insert(int d)
                {
                   tree_node* t = new tree_node;
                   tree_node* parent;
                   t->data = d;
                   t->left = NULL;
                   t->right = NULL;
                   parent = NULL;

                   // is this a new tree?
                   if(isEmpty()) root = t;
                   else
                   {
                      //Note: ALL insertions are as leaf nodes
                      tree_node* curr;
                      curr = root;
                      // Find the Node's parent
                      while(curr)
                      {
                         parent = curr;
                         if(t->data > curr->data) curr = curr->right;
                         else curr = curr->left;
                      }

                      if(t->data < parent->data)
                      {
                         parent->left = t;
                      }
                      else
                      {
                      parent->right = t;
                      }
                    }
                }
            */

        }


        public void Display(MyNode<T> node)
        {
            if (node != null)
            {
                if (node.Left != null)
                    Display(node.Left);
                if (node.Right != null)
                    Display(node.Right);
                Console.WriteLine(" {0} ", node.Value);
            }

        }

        #endregion

        #region Fields

        public MyNode<T> Root { get; set; } = null;

        #endregion
    }
}
