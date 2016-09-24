using System;
using System.Collections.Generic;
using System.IO;
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
    /// - Время работы от номера колонки (НЕ НАДО)
    /// - Время работы от длины массива (НЕ НАДО)
    /// </summary>
    class Program
    {
        enum SortType
        {
            BUBBLE_SORT = 0,
            SELECTION_SORT = 1
        }

        enum TaskType
        {
            COMPARE_ASSIGMENT_FROM_ID = 0,
            COMPARE_ASSIGMENT_FROM_LENGTH = 1,
            TIME_FROM_ID = 2,
            TIME_FROM_LENGTH = 3
        }

        public static StreamWriter bubbleSWComparefromID;
        public static StreamWriter bubbleSWAssigmentfromID;

        public static StreamWriter selectionSWComparefromID;
        public static StreamWriter selectionSWAssigmentfromID;

        public static Random rand = new Random();



        public static void BubbleSort(MyArray Array, int taskType, int currentExecutionStepsCount = 0)
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

            //Console.WriteLine("Bubble assigmnet = {0}", MyInt.AssigmentCount);
            //Console.WriteLine("Bubble compare = {0}", MyInt.CompareCount);

            switch (taskType)
            {
                case (int)TaskType.COMPARE_ASSIGMENT_FROM_ID:
                    bubbleSWComparefromID.WriteLine("{0} {1}", currentExecutionStepsCount, MyInt.CompareCount);
                    bubbleSWAssigmentfromID.WriteLine("{0} {1}", currentExecutionStepsCount, MyInt.AssigmentCount);
                    break;
            }
            

            MyInt.AssigmentCount = 0;
            MyInt.CompareCount = 0;
        }

        public static void SelectionSort(MyArray array, int taskType, int currentExecutionStepsCount = 0)
        {
            MyInt minID = new MyInt(0);

            for (int i = 0; i < array.Count - 1; ++i)
            {
                // Set Minimum element ID equal to current element ID
                minID.Assigment(new MyInt(i));

                // Search minimum element in array
                for (int j = i + 1; j < array.Count; ++j)
                    if (array[j] < array[minID.Value])
                    {
                        minID.Assigment(new MyInt(j));
                    }
                // Swap current and minimum element
                MyInt temp = new MyInt(array[minID.Value]);
                array[minID.Value].Assigment(array[i]);
                array[i].Assigment(temp);
            }

            //Console.WriteLine("Selection assigmnet = {0}", MyInt.AssigmentCount);
            //Console.WriteLine("Selection compare = {0}", MyInt.CompareCount);

            switch (taskType)
            {
                case (int)TaskType.COMPARE_ASSIGMENT_FROM_ID:
                    selectionSWComparefromID.WriteLine("{0} {1}", currentExecutionStepsCount, MyInt.CompareCount);
                    selectionSWAssigmentfromID.WriteLine("{0} {1}", currentExecutionStepsCount, MyInt.AssigmentCount);
                    break;
            }

            MyInt.AssigmentCount = 0;
            MyInt.CompareCount = 0;
        }

        public static void bubbleSortStep(ref MyArray array, int executionStepCount)
        {
            for (int i = 0; i < executionStepCount; ++i)
                for (int j = i + 1; j < array.Count; ++j)
                    if (array[i] < array[j])
                    {
                        MyInt temp = new MyInt(array[i]);
                        array[i].Assigment(array[j]);
                        array[j].Assigment(temp);
                    }

            MyInt.AssigmentCount = 0;
            MyInt.CompareCount = 0;


        }

        public static void Solver(MyArray array, int currentSortType)
        {

            array.Sort();

            switch (currentSortType)
            {
                case (int)SortType.BUBBLE_SORT:
                    BubbleSort(array, (int)TaskType.COMPARE_ASSIGMENT_FROM_ID, 0);
                    break;
                case (int)SortType.SELECTION_SORT:
                    SelectionSort(array, (int)TaskType.COMPARE_ASSIGMENT_FROM_ID, 0);
                    break;
                default:
                    throw  new ArgumentException("Wrong ID input");
            }

            int currentExecutionStepsCount = 1;

            while (currentExecutionStepsCount != array.Count)
            {
                bubbleSortStep(ref array, currentExecutionStepsCount);

                switch (currentSortType)
                {
                    case (int)SortType.BUBBLE_SORT:
                        BubbleSort(array, (int)TaskType.COMPARE_ASSIGMENT_FROM_ID, currentExecutionStepsCount);
                        break;
                    case (int)SortType.SELECTION_SORT:
                        SelectionSort(array, (int)TaskType.COMPARE_ASSIGMENT_FROM_ID, currentExecutionStepsCount);
                        break;
                    default:
                        throw new ArgumentException("Wrong ID input");
                }

                ++currentExecutionStepsCount;
            }
        }


        static void Main(string[] args)
        {
            int size = 1000;
            MyArray array = new MyArray(size);


            bubbleSWComparefromID = new StreamWriter(@"Data/bubleCompareFromID(length_" + size.ToString() + ").txt");
            bubbleSWAssigmentfromID = new StreamWriter(@"Data/bubleAssigmentFromID(length_" + size.ToString() + ").txt");

            selectionSWComparefromID = new StreamWriter(@"Data/selectCompareFromID(length_" + size.ToString() + ").txt");
            selectionSWAssigmentfromID = new StreamWriter(@"Data/selectAssigmentFromID(length_" + size.ToString() + ").txt");


            array.fillArrayWithRandomValues(ref rand, int.MinValue, int.MaxValue);

            
            Solver(array, (int)SortType.BUBBLE_SORT);
            Solver(array, (int)SortType.SELECTION_SORT);



            bubbleSWComparefromID.Close();
            bubbleSWAssigmentfromID.Close();
            selectionSWComparefromID.Close();
            selectionSWAssigmentfromID.Close();

            Console.WriteLine("Calculations finished successfully!");
        }

            
    }
}
