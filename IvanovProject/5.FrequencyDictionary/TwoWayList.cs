﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.FrequencyDictionary
{

  class NodeTW<T> where T : class
  {
    public T Value { get; set; } = null;
    public int Count { get; set; } = 1;

    public NodeTW<T> Next { get; set; } = null;
    public NodeTW<T> Prev { get; set; } = null;

    public override string ToString()
        => string.Format("Value: {0}, count = {1}", Value, Count);
  }

  class MyDoubleLinkedList<T> where T : class, IListInterface<T>
  {

    public MyDoubleLinkedList() { }

    #region Methods

    public void Add(T value)
    {
      if (root == null)
      {
        root = new NodeTW<T>();
        root.Value = value;
      }
      else if (root.Next == null)
      {
        root.Next = tale;
        tale.Value = value;
        
      }
    }

    public void Display()
    {
      NodeTW<T> curNode = root;
      while (curNode != null)
      {
        Console.WriteLine(curNode);
        curNode = curNode.Next;
      }
    }

    #endregion

    #region Fields

    NodeTW<T> root = null;
    NodeTW<T> tale = null;

    #endregion
  }
}
