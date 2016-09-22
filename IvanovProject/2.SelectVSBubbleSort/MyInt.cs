using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectVSBubbleSort
{

    /// <summary>
    /// Implementation my datatype int for good assignment and compare operations calculation
    /// </summary>
    class MyInt
    {
        #region Fields

        static int compareCount = 0;
        static int assigmentCount = 0;

        int value = 0;

        #endregion

        #region Constructor

        public MyInt() { }

        public MyInt(int value)
        {
            this.value = value;
        }

        // Copy constructor
        public MyInt(MyInt other) : this(other.value)
        {
            ++assigmentCount;
        }

        #endregion

        #region Properties

        public static int CompareCount
        {
            get { return compareCount; }
            set { compareCount = value; }
        }

        public static int AssigmentCount
        {
            get { return assigmentCount; }
            set { assigmentCount = value; }
        }

        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }
        #endregion

        #region Overload operations

        #region Compare operators

        public static bool operator<(MyInt left, MyInt right)
        {
            ++compareCount;
            return (left.value < right.value) ? true : false;
        }

        public static bool operator >(MyInt left, MyInt right)
        {
            ++compareCount;
            return (left.value > right.value) ? true : false;
        }

        public static bool operator ==(MyInt left, MyInt right)
        {
            ++compareCount;
            return (left.value == right.value) ? true : false;
        }

        public static bool operator !=(MyInt left, MyInt right)
        {
            ++compareCount;
            return (left.value != right.value) ? true : false;
        }

        #endregion

        #region Assigment operator

        public void Assigment(MyInt other)
        {
            ++assigmentCount;
            this.value = other.value;
        }

        #endregion

        #endregion

        public override string ToString()
            => value.ToString();
    }
}
