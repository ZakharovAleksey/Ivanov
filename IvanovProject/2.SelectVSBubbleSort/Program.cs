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

        public static void BubbleSort(MyArray Array)
        {
            MyArray array = new MyArray(Array);

            for (int i = 0; i < array.Count - 1; ++i)
                for (int j = i + 1; j < array.Count; ++j)
                    if (array[i] > array[j])
                    {
                        MyInt temp = new MyInt(array[i]);
                        array[i].Assigment(array[j]);
                        array[j].Assigment(temp);
                    }

            //Console.WriteLine("AFTER : {0}", array);

            Console.WriteLine("Bubble assigmnet = {0}", MyInt.AssigmentCount);
            Console.WriteLine("Bubble compare = {0}", MyInt.CompareCount);

            MyInt.AssigmentCount = 0;
            MyInt.CompareCount = 0;
        }


        public static void  SelectionSort(MyArray array)
        {
            MyInt min = new MyInt(array[0]);
            int minID = 0;

            for (int i = 0; i < array.Count - 1; ++i)
            {
                // Update minimum element value and ID
                min.Assigment(array[i]);
                minID = i;

                // Search minimum element in array
                for (int j = i + 1; j < array.Count; ++j)
                    // Change here for determ sequense order
                    if (array[j] > min)
                    {
                        min.Assigment(array[j]);
                        minID = j;
                    }
                // Swap current and minimum element

                if (array[minID] != array[i])
                {
                    MyInt temp = new MyInt(array[minID]);
                    array[minID].Assigment(array[i]);
                    array[i].Assigment(temp);
                }
            }

            Console.WriteLine("INSIDE SELECT array = {0}", array);

            Console.WriteLine("Bubble assigmnet = {0}", MyInt.AssigmentCount);
            Console.WriteLine("Bubble compare = {0}", MyInt.CompareCount);

            MyInt.AssigmentCount = 0;
            MyInt.CompareCount = 0;
        }

        public static void Solver(MyArray array)
        {
            //MyArray bubbleArray = new MyArray(array);
            //MyArray selectArray = new MyArray(array);
            BubbleSort(array);
            Console.WriteLine("INITIAL = {0}", array);
            //Console.WriteLine("bubble array = {0}", bubbleArray);
            //Console.WriteLine("select array = {0}", selectArray);

            for (int i = 0; i < array.Count - 1; ++i)
            {
                Console.WriteLine("Step {0}!!!",i);
                // One Bubble sort step
                for (int j = i + 1; j < array.Count; ++j)
                    if (array[i] < array[j])
                    {
                        MyInt temp = new MyInt(array[i]);
                        array[i].Assigment(array[j]);
                        array[j].Assigment(temp);
                    }

                MyInt.AssigmentCount = 0;
                MyInt.CompareCount = 0;

                MyArray bubbleArray = new MyArray(array);
                Console.WriteLine("BEFORE: {0}", bubbleArray);
                BubbleSort(bubbleArray);

            }

            //BubbleSort(bubbleArray);
            //SelectionSort(selectArray);




            //Console.WriteLine("array = {0}", array);
            //Console.WriteLine("bubble array = {0}", bubbleArray);
            //Console.WriteLine("select array = {0}", selectArray);
        }

        static void Main(string[] args)
        {
            MyArray array = new MyArray(10);
            for (int i = 0; i < 10; ++i)
                array[i] = new MyInt(i);

            //array.fillArrayWithRandomValues(ref rand, 0, 10);
            Solver(array);
        }

            
    }
}
