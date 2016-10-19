using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace _3.QuickVSSelectSort
{
    class Program
    {
        public enum SortType
        {
            Q_SORT = 0,
            MERGE_SORT = 1
        }

        static public Random rand = new Random();

        #region Quick Sort

        /// <summary>
        /// Partition for QSort algorithm: separate array in to two parts [ x < </PRIVOT>] [privot] [x > </PRIVOT>]
        /// </summary>
        /// <param name="array"> Input array referense </param>
        /// <param name="left"> Left border of partition procedure </param>
        /// <param name="right"> Right border of partition procedure </param>
        /// <returns> Index of privot position in array after procedure execution </returns>
        static int Partition(ref MyArray array, int left, int right)
        {
            // Determine privot index and value
            int privotID = rand.Next(left, right);//(left + right) >> 1;
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

        // READ ME: 
        // Индексов присваивания постоянное число в задаче на ID так как всегда присваиваем ВСЕ значения частией массиву temp - не зависит от меры упорядоченности массива.

        /// <summary>
        /// Merge Procedure for MergeSort algorithm inplamentation: merge two parts in one 
        /// </summary>
        /// <param name="array"> Reference on array </param>
        /// <param name="left"> Begin index of first part </param>
        /// <param name="separator"> End of first part and in the same time begin for second part </param>
        /// <param name="right"> End of the second part </param>
        static void Merge(ref MyArray array, int left, int separator, int right)
        {
            // Indexes of left and right part respectively
            int curFirstPos = left;
            int curSecondPos = separator + 1;

            // Index in temp array
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

        public static void SingleIDSolver(MyArray array, int sortType, StreamWriter swAssigment, StreamWriter swCompare, StreamWriter swTime, Stopwatch timer)
        {
            int curID = 0;
            Stack<MyArray> stack = new Stack<MyArray>();

            #region Calculation in sorted in descending order part

            for (int i = 1; i < array.Size; ++i)
            {
                MyArray temp = (MyArray)array.Clone();
                temp.BubbleSortStep(i, true);
                stack.Push(temp);
            }

            while (stack.Count != 0)
            {
                MyInt.AssigmentCount = 0;
                MyInt.CompareCount = 0;

                MyArray topArray = stack.Peek();

                timer.Reset();
                timer.Start();

                switch (sortType)
                {
                    case (int)SortType.Q_SORT:
                        QuickSort(ref topArray, 0, topArray.Size -1);
                        break;
                    case (int)SortType.MERGE_SORT:
                        MergeSort(ref topArray, 0, topArray.Size - 1);
                        break;
                    default:
                        throw new InvalidDataException("There is no such type of sorting");
                }

                timer.Stop();

                if (curID % 10 == 0)
                {
                    swAssigment.WriteLine("{0} {1}", curID, MyInt.AssigmentCount);
                    swCompare.WriteLine("{0} {1}", curID, MyInt.CompareCount);
                    swTime.WriteLine("{0} {1}", curID, timer.ElapsedMilliseconds);
                }
                ++curID;

                stack.Pop();
            }

            #endregion

            #region  Calculation in sorted in ascending part

            for (int i = 1; i < array.Size; ++i)
            {
                MyArray temp = (MyArray)array.Clone();
                temp.BubbleSortStep(i, false);

                MyInt.AssigmentCount = 0;
                MyInt.CompareCount = 0;

                switch (sortType)
                {
                    case (int)SortType.Q_SORT:
                        QuickSort(ref temp, 0, temp.Size - 1);
                        break;
                    case (int)SortType.MERGE_SORT:
                        MergeSort(ref temp, 0, temp.Size - 1);
                        break;
                    default:
                        throw new InvalidDataException("There is no such type of sorting");
                }

                if (curID % 10 == 0)
                {
                    swAssigment.WriteLine("{0} {1}", curID, MyInt.AssigmentCount);
                    swCompare.WriteLine("{0} {1}", curID, MyInt.CompareCount);
                }
                ++curID;
            }

            #endregion
        }

        public static void SolverID(int arraySize)
        {
            #region StreamWriter Initilize

            StreamWriter swQSortAssigment = new StreamWriter("IDQSortAssigmentID.txt");
            StreamWriter swQSortCompare = new StreamWriter("IDQSortCompareID.txt");

            StreamWriter swMergeSortAssigment = new StreamWriter("IDMergeSortAssigmentID.txt");
            StreamWriter swMergewSortCompare = new StreamWriter("IDMergeSortCompareID.txt");

            StreamWriter swQSortTime = new StreamWriter("LenQSortTime.txt");
            StreamWriter swMergeSortTime = new StreamWriter("LenMergeSortTime.txt");

            #endregion

            Stopwatch qSortTime = new Stopwatch();
            Stopwatch mergeSortTime = new Stopwatch();


            MyArray array = new MyArray(arraySize);
            array.fillWithRandomValues(int.MinValue, int.MaxValue);

            MyArray qSortArray = (MyArray)array.Clone();
            MyArray mergeSortArray = (MyArray)array.Clone();

            MyInt.AssigmentCount = 0;
            MyInt.CompareCount = 0;

            SingleIDSolver(mergeSortArray, (int)SortType.MERGE_SORT, swMergeSortAssigment, swMergewSortCompare, swMergeSortTime, mergeSortTime);
            SingleIDSolver(qSortArray, (int)SortType.Q_SORT, swQSortAssigment, swQSortCompare, swQSortTime, qSortTime);
            
            #region StreamWriter Close

            swQSortAssigment.Close();
            swQSortCompare.Close();

            swMergeSortAssigment.Close();
            swMergewSortCompare.Close();

            swQSortTime.Close();
            swMergeSortTime.Close();

            #endregion
        }

        #endregion

        #region Solver depending on Length

        public static void SolverLenght(int minLenght, int maxLenght, int step)
        {
            MyInt.AssigmentCount = 0;
            MyInt.CompareCount = 0;

            #region StreamWriter prepare

            StreamWriter qSortSWAssigment = new StreamWriter(@"LenQSortAssigment.txt");
            StreamWriter qSortSWCompare = new StreamWriter(@"LenQSortCompare.txt");

            StreamWriter mergeSortSWAssigment = new StreamWriter(@"LenMergeSortAssigment.txt");
            StreamWriter mergeSortSWCompare = new StreamWriter(@"LenMergeSortCompare.txt");

            StreamWriter qSortTimeSW = new StreamWriter("LenQSortTime.txt");
            StreamWriter mergeSortTimeSW = new StreamWriter("LenMergeSortTime.txt");

            #endregion

            Stopwatch qSortTime = new Stopwatch();
            Stopwatch mergeSortTime = new Stopwatch();

            for (int curLenght = minLenght; curLenght <= maxLenght; curLenght += step)
            {
                #region Initilize arays

                MyArray qSortArray = new MyArray(curLenght);
                qSortArray.fillWithRandomValues(int.MinValue, int.MaxValue);

                MyArray mergeSortArray = (MyArray)qSortArray.Clone();

                MyInt.AssigmentCount = 0;
                MyInt.CompareCount = 0;

                #endregion

                #region QSort

                qSortTime.Reset();
                qSortTime.Start();
                QuickSort(ref qSortArray, 0, qSortArray.Size - 1);
                qSortTime.Stop();

                #region Write Data

                qSortTimeSW.WriteLine("{0} {1}", qSortArray.Size, qSortTime.Elapsed.Milliseconds);
                qSortSWAssigment.WriteLine("{0} {1}", qSortArray.Size, MyInt.AssigmentCount);
                qSortSWCompare.WriteLine("{0} {1}", qSortArray.Size, MyInt.CompareCount);

                #endregion

                MyInt.AssigmentCount = 0;
                MyInt.CompareCount = 0;

                #endregion

                #region MergeSort

                mergeSortTime.Reset();
                mergeSortTime.Start();
                MergeSort(ref mergeSortArray, 0, mergeSortArray.Size - 1);
                mergeSortTime.Stop();

                #region Write Data

                mergeSortTimeSW.WriteLine("{0} {1}", qSortArray.Size, mergeSortTime.ElapsedMilliseconds);
                mergeSortSWAssigment.WriteLine("{0} {1}", mergeSortArray.Size, MyInt.AssigmentCount);
                mergeSortSWCompare.WriteLine("{0} {1}", mergeSortArray.Size, MyInt.CompareCount);

                #endregion

                MyInt.AssigmentCount = 0;
                MyInt.CompareCount = 0;

                #endregion
            }

            #region StreamWriter close

            qSortSWAssigment.Close();
            qSortSWCompare.Close();

            mergeSortSWAssigment.Close();
            mergeSortSWCompare.Close();

            qSortTimeSW.Close();
            mergeSortTimeSW.Close();

            #endregion
        }

        #endregion

        static void Main(string[] args)
        {
            try
            {
                //SolverID(1000);
                SolverLenght(1000, 100000, 1000);
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
