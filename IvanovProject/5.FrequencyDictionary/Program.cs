using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.FrequencyDictionary
{
  class Program
  {
    static void Main(string[] args)
    {
            MyLinkedList<string> list = new MyLinkedList<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("2");
            list.Add("1");
            list.Insert("10", 1);

            list.Display();
            Console.WriteLine(list.Count());


    }
  }
}
