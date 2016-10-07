using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.QuickVSSelectSort
{
    class Program
    {
        static public Random rand = new Random();

        #region Quick Sort

        static int Partition(ref MyArray array, int left, int right)
        {
            // Determine privot index and value
            int privotID = (left + right) >> 1;
            MyInt privot = (MyInt)array[privotID].Clone();

            // Swap current privot and last element of array
            array[(left + right) / 2].Assigment(array[right]);
            array[right].Assigment(privot);

            // l - граница области для которой element < privot, r - граница для которой element >= privot
            int l = left, r = left;
            while (r != right)
            {
                // Можно на массиве: 3 5 4 2 1
                // Просто двигаем границу больших элементов
                if (array[r] > privot)
                    ++r;
                // То меняем течущий элемент с элеметом котроый сразу после области где element < privot
                else if (array[r] <= privot)
                {
                    MyInt temp = (MyInt)array[l].Clone();
                    array[l].Assigment(array[r]);
                    array[r].Assigment(temp);

                    ++l;
                    ++r;
                }
            }

            // Меняем Privot с элеметом котроый сразу после области где element < privot и таким образом: [меньше]PRIVOT[больше]
            MyInt temp1 = (MyInt)array[l].Clone();
            array[l].Assigment(array[right]);
            array[right].Assigment(temp1);

            return l;
        }

        static void QuickSort(ref MyArray array, int left , int right)
        {
            if (left >= right)
                return;

            int separater = Partition(ref array, left, right);

            QuickSort(ref array, left, separater - 1);
            QuickSort(ref array, separater + 1, right);
        }

        #endregion

        #region Merge Sort

        static void Merge(ref MyArray array, int left, int separator, int right)
        {
            int curFirstPos = left;
            int curSecondPos = separator + 1;

            int curTempPos = 0;
            MyArray temp = new MyArray(right - left + 1);

            while (curFirstPos <= separator && curSecondPos <= right)
            {
                if (array[curFirstPos] <= array[curSecondPos])
                    temp[curTempPos++] = (MyInt)array[curFirstPos++].Clone();
                else
                    temp[curTempPos++] = (MyInt)array[curSecondPos++].Clone();
            }

            while (curFirstPos <= separator)
                temp[curTempPos++] = (MyInt)array[curFirstPos++].Clone();
            
            while (curSecondPos <= right)
                temp[curTempPos++] = (MyInt)array[curSecondPos++].Clone();

            for (int i = 0; i < temp.Size; ++i)
                array[left + i] = (MyInt)temp[i].Clone();
        }

        static void MergeSort(ref MyArray array, int left, int right)
        {
            int split;

            if (left < right)
            {
                split = (left + right) / 2;

                MergeSort(ref array, left, split);
                MergeSort(ref array, split + 1, right);

                Merge(ref array, left, split, right);
            }
        }

        #endregion

        #region  Solver depending on ID


        #endregion


        #region Solver depending on Length

        void SolverLenght(MyArray array)
        {
            
            //lockal
        }

        #endregion

        static void Main(string[] args)
        {
            MyArray a = new MyArray(8);
            a.fillWithRandomValues(0, 100);
            Console.WriteLine(a);
            QuickSort(ref a, 0, a.Size - 1);
            Console.WriteLine(a);


            //MyArray a = new MyArray(8);
            //a.fillWithRandomValues(0, 100);
            //Console.WriteLine(a);
            ////Merge(ref a, 0, 1, a.Size - 1);
            //MergeSort(ref a, 0, a.Size - 1);
            //Console.WriteLine(a);

        }
    }
}
