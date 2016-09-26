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
        // Count of compare operations for this Array
        int compareCount = 0;
        // Count of assigment operations for this Array
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

        public MyArray(MyArray array) : this(array.count)
        {
            for (int i = 0; i < count; ++i)
                body[i] = array.body[i];
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
        /// Bubble Sort implementation method
        /// </summary>
        public void Sort()
        {
            for (int i = 0; i < count - 1; ++i)
                for (int j = i + 1; j < count; ++j)
                    if (body[i] > body[j])
                    {
                        MyInt temp = new MyInt(body[i]);
                        body[i] = body[j];
                        body[j] = temp;
                    }

            MyInt.AssigmentCount = 0;
            MyInt.CompareCount = 0;
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
