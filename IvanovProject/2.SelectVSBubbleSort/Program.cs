using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectVSBubbleSort
{
    /// <summary>
    /// Author: Захаров Алексей
    /// Сравнение selection sort и bubble sort, для отчета необходимо предоставить:
    /// - График зависимости числа перестновок от номера колонки
    /// - График зависимости числа сравнений от номера колонки
    /// - График зависимости числа перестановок от длинны массива
    /// - График зависимости числа сравнений от длины массива
    /// - Время работы от номера колонки
    /// - Время работы от длины массива
    /// </summary>
    class Program
    {
        public static Random rand = new Random();

        public static void Swap(ref MyInt left, ref MyInt right)
        {
            MyInt.AssigmentCount += 2;
            MyInt temp = left;
            left = right;
            right = temp;
        }

        static void Main(string[] args)
        {

            //MyInt a = new MyInt(2);
            //MyInt b = new MyInt(3);

            //Console.WriteLine(a);
            //Console.WriteLine(b);

            //Console.WriteLine("a Assigment: {0}", MyInt.AssigmentCount);
            //Console.WriteLine("a Compare: {0}", MyInt.CompareCount);
            //Swap(ref a, ref b);
            //Console.WriteLine(a);
            //Console.WriteLine(b);
            //if(a < b)
            //    Console.WriteLine("lol");
            //if(a > b)
            //    Console.WriteLine("lol");
            //if(a == b)
            //    Console.WriteLine("lol");

            //if(a!= b)
            //    Console.WriteLine("lol");
            //a.Assigment(ref b);
            //Console.WriteLine(a);
            //Console.WriteLine(b);

            //Console.WriteLine("b Assigment: {0}", MyInt.AssigmentCount);
            //Console.WriteLine("b Compare: {0}", MyInt.CompareCount);


            MyArray array = new MyArray(10);
            array.fillArrayWithRandomValues(ref rand, 0, 100);
            //Console.WriteLine(array);
            //array.BubbleSort();
            //Console.WriteLine(array);

            //Console.WriteLine("Assigment: {0}", MyInt.AssigmentCount);
            //Console.WriteLine("Compare: {0}", MyInt.CompareCount);
            //Console.WriteLine("-------------------------");
            //MyArray array1 = new MyArray(10);
            //array1.fillArrayWithRandomValues(ref rand, 0, 100);
            //Console.WriteLine(array1);
            //array1.SelectSort();
            //Console.WriteLine(array1);

            //Console.WriteLine("Assigment: {0}", MyInt.AssigmentCount);
            //Console.WriteLine("Compare: {0}", MyInt.CompareCount);

            array.Solver();


        }
    }
}
