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
            tree.Add("lol");
            tree.Add("Hah");
            tree.Display(tree.Root);
    }
  }
}
