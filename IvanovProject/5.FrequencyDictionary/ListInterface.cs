using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.FrequencyDictionary
{
    interface IListInterface<T> where T : class
    {
        void Add(T value);

        void Insert(T value, int position);

        void Display();

        int Count();
    }
}
