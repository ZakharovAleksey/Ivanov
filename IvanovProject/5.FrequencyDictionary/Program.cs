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
            Tree.MyBinTree<string> tree = new Tree.MyBinTree<string>();
            Random rand = new Random();

            for (int i = 0; i < 10; ++i)
            {
                tree.Add(rand.Next(0, 3).ToString());
            }

            Console.WriteLine();
            tree.Display(tree.Root);
    }
  }
}
