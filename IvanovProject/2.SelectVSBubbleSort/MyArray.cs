using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectVSBubbleSort
{
    class MyArray
    {
        #region Fields
        // Count of compare operations
        int compareCount = 0;
        // Count of assigment operations
        int assigmentCount = 0;

        MyInt[] body;
        // Array size
        int count = 0;

        #endregion

        #region Constructor

        public MyArray(int count)
        {
            this.count = count;

            body = new MyInt[this.count];
            for (int i = 0; i < this.count; ++i)
                body[i] = new MyInt();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get array size
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Get or set current value of array
        /// </summary>
        /// <param name="currentID"> element index </param>
        /// <returns></returns>
        public MyInt this[int currentID]
        {
            get { return body[currentID]; }
            set { body[currentID] = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Fill array with random values in appropriate range
        /// </summary>
        /// <param name="rand"> Random object witch generate values </param>
        /// <param name="minValue"> Minimum value for random values generator </param>
        /// <param name="maxValue"> Maximum value for random values generator </param>
        public void fillArrayWithRandomValues(ref Random rand, int minValue, int maxValue)
        {
            for (int i = 0; i < count; ++i)
                body[i].Value = rand.Next(minValue, maxValue);           
        }

        /// <summary>
        /// Execute bubble sort
        /// </summary>
        public void BubbleSort()
        {
            for (int i = 0; i < count; ++i)
                for (int j = i; j < count; ++j)
                    if (body[i] < body[j])
                        body[i].Swap(ref body[j]);

            // Store total number of assigment and compare operations
            compareCount = MyInt.CompareCount;
            assigmentCount = MyInt.AssigmentCount;

            Console.WriteLine("Bubble: compare: {0}, assigment {1}", compareCount, assigmentCount);

            // Set total number of assigment and compare operations equal to zero
            MyInt.CompareCount = 0;
            MyInt.AssigmentCount = 0;
        }

        /// <summary>
        /// Execute select sort
        /// </summary>
        public void SelectSort()
        {
            // Set initial minimul value and it's own ID
            MyInt min = new MyInt();
            min.Assigment(ref body[0]);
            int minID = 0;

            for (int i = 0; i < count; ++i)
            {
                // Update minimum element value and ID
                min.Assigment(ref body[i]);
                minID = i;

                // Search minimum element in array
                for (int j = i; j < count; ++j)
                    if (body[j] < min)
                    {
                        min.Assigment(ref body[j]);
                        minID = j;
                    }
                // Swap current and minimum element
                body[i].Swap(ref body[minID]);
            }

            // Store total number of assigment and compare operations
            compareCount = MyInt.CompareCount;
            assigmentCount = MyInt.AssigmentCount;

            Console.WriteLine("Select: compare: {0}, assigment {1}", compareCount, assigmentCount);

            // Set total number of assigment and compare operations equal to zero
            MyInt.CompareCount = 0;
            MyInt.AssigmentCount = 0;
        }

        #endregion

        public override string ToString()
        {
            StringBuilder resultString = new StringBuilder();
            foreach (MyInt element in body)
                resultString.Append(element.ToString() + " ");
            return resultString.ToString();
        }
    }
}
