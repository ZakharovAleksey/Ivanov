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
            // TIME_FROM_ID = 2,
            // TIME_FROM_LENGTH = 3
        }

        #region StreamWriter Region

        // Output stream writer objectss for ID dependancy
        public static StreamWriter bubbleSWComparefromID;
        public static StreamWriter bubbleSWAssigmentfromID;

        public static StreamWriter selectionSWComparefromID;
        public static StreamWriter selectionSWAssigmentfromID;

        // Output stream writer objectss for Length dependancy
        public static StreamWriter bubbleSWCompareFromLength;
        public static StreamWriter bubbleSWAssigmentFromLength;

        public static StreamWriter selectSWCompareFromLength;
        public static StreamWriter selectSWAssigmentFromLength;

        #endregion

        // Random object
        public static Random rand = new Random();


        /// <summary>
        /// Bubble sort implementation
        /// </summary>
        /// <param name="array"> Input array </param>
        /// <param name="taskType"> Type of current task </param>
        /// <param name="currentExecutionStepsCount"> Column ID</param>
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
                case (int)TaskType.COMPARE_ASSIGMENT_FROM_LENGTH:
                    bubbleSWCompareFromLength.WriteLine("{0} {1}", array.Count, MyInt.CompareCount);
                    bubbleSWAssigmentFromLength.WriteLine("{0} {1}", array.Count, MyInt.AssigmentCount);
                    break;
            }
            

            MyInt.AssigmentCount = 0;
            MyInt.CompareCount = 0;
        }

        /// <summary>
        /// Selection sort implementation
        /// </summary>
        /// <param name="array"> Input array </param>
        /// <param name="taskType"> Type of current task </param>
        /// <param name="currentExecutionStepsCount"> Column ID</param>
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
                case (int)TaskType.COMPARE_ASSIGMENT_FROM_LENGTH:
                    selectSWCompareFromLength.WriteLine("{0} {1}", array.Count, MyInt.CompareCount);
                    selectSWAssigmentFromLength.WriteLine("{0} {1}", array.Count, MyInt.AssigmentCount);
                    break;
            }

            MyInt.AssigmentCount = 0;
            MyInt.CompareCount = 0;
        }

        /// <summary>
        /// Single Bubble Sort step implementation
        /// </summary>
        /// <param name="array"> Input array for prosedure </param>
        /// <param name="executionStepCount"> Count of steps for bubble sort </param>
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

        /// <summary>
        /// Calculate Assigment and Compare count depends on choosen sorting type (Bubble/Selection)
        /// </summary>
        /// <param name="array"> Input array for sorting prosedure </param>
        /// <param name="currentSortType"> Type of sorting prosedure </param>
        public static void IDSolver(MyArray array, int currentSortType)
        {
            // Sort randomly generated array in apropriate order
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

            // Current column ID
            int currentExecutionStepsCount = 1;

            while (currentExecutionStepsCount != array.Count)
            {
                // Make single bubble sort step
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

        /// <summary>
        /// Calculate Assigment and Compare dependancy from array Length
        /// </summary>
        /// <param name="arrayCurrentSize"> Input initial array size </param>
        /// <param name="arrayMaxSize"> Maximum array size</param>
        public static void SolverForLength(int arrayCurrentSize, int arrayMaxSize)
        {
            // Initilize output files
            bubbleSWCompareFromLength = new StreamWriter(@"Data\Bubble Sort Compare Length.txt");
            bubbleSWAssigmentFromLength = new StreamWriter(@"Data\Buble Sort Assigment Length.txt");

            selectSWCompareFromLength = new StreamWriter(@"Data\Select Sort Compare Length.txt");
            selectSWAssigmentFromLength = new StreamWriter(@"Data\Select Sort Assigment Length.txt");

            // Iterative array size update
            while (arrayCurrentSize <= arrayMaxSize)
            {
                Console.WriteLine("Current array size = {0}", arrayCurrentSize);

                // Bubble sort implementation
                MyArray bubbleArray = new MyArray(arrayCurrentSize);
                bubbleArray.fillArrayWithRandomValues(ref rand, int.MinValue, int.MaxValue);
                BubbleSort(bubbleArray, (int)TaskType.COMPARE_ASSIGMENT_FROM_LENGTH);

                // Selection sort implementation
                MyArray selectionArray = new MyArray(arrayCurrentSize);
                selectionArray.fillArrayWithRandomValues(ref rand, int.MinValue, int.MaxValue);
                SelectionSort(selectionArray, (int)TaskType.COMPARE_ASSIGMENT_FROM_LENGTH);

                //if (arrayCurrentSize < 2000)
                    //arrayCurrentSize += 10;
                //else
                    arrayCurrentSize += 5000;
            }

            // Close output files

            bubbleSWCompareFromLength.Close();
            bubbleSWAssigmentFromLength.Close();

            selectSWCompareFromLength.Close();
            selectSWAssigmentFromLength.Close();
        }

        /// <summary>
        /// Calculate Assigment and Compare dependancy from column ID
        /// </summary>
        /// <param name="arraySize"> Array size </param>
        public static void SolverForID(int arraySize)
        {
            // Initilize output files
            bubbleSWComparefromID = new StreamWriter(@"Data\Bubble Sort Compare ID.txt");
            bubbleSWAssigmentfromID = new StreamWriter(@"Data\Buble Sort Assigment ID.txt");

            selectionSWComparefromID = new StreamWriter(@"Data\Select Sort Compare ID.txt");
            selectionSWAssigmentfromID = new StreamWriter(@"Data\Select Sort Assigment ID.txt");

            // Initilize array
            MyArray array = new MyArray(arraySize);
            array.fillArrayWithRandomValues(ref rand, int.MinValue, int.MaxValue);
            //Console.WriteLine(array);

            // Calculate Assigment and Compare dependancy
            IDSolver(array, (int)SortType.BUBBLE_SORT);
            array.fillArrayWithRandomValues(ref rand, int.MinValue, int.MaxValue);
            //Console.WriteLine(array);
            IDSolver(array, (int)SortType.SELECTION_SORT);


            // Close output files
            bubbleSWComparefromID.Close();
            bubbleSWAssigmentfromID.Close();

            selectionSWComparefromID.Close();
            selectionSWAssigmentfromID.Close();

        }

        static void Main(string[] args)
        {
            // Calculate Compare/Assigment(ID) dependancy
            SolverForID(150);

            // Calculate Compare/Assigment(Length) dependancy
            // Не плохо от 10 до 1000 прибаляя по 10
            //SolverForLength(10000, 100000);

            Console.WriteLine("Calculations finished successfully!");
        }

            
    }
}
