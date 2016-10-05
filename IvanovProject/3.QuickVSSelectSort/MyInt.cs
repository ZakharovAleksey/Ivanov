using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.QuickVSSelectSort
{

    /// <summary>
    /// Implementation my datatype int for good assignment and compare operations calculation
    /// </summary>
    class MyInt : ICloneable
    {
        public MyInt(int value)
        {
            Value = value;
        }

        public MyInt() : this(0) { }

        #region Overload operations

        public static bool operator <(MyInt left, MyInt right)
        {
            ++CompareCount;
            return (left.Value < right.Value);// ? true : false;
        }

        public static bool operator <=(MyInt left, MyInt right)
        {
            ++CompareCount;
            return (left.Value <= right.Value);// ? true : false;
        }

        public static bool operator >(MyInt left, MyInt right)
        {
            ++CompareCount;
            return (left.Value > right.Value);// ? true : false;
        }

        public static bool operator >=(MyInt left, MyInt right)
        {
            ++CompareCount;
            return (left.Value >= right.Value);// ? true : false;
        }

        public static bool operator==(MyInt left, MyInt right)
        {
            ++CompareCount;
            return (left.Value == right.Value);// ? true : false;
        }

        public static bool operator !=(MyInt left, MyInt right)
        {
            ++CompareCount;
            return (left.Value != right.Value);// ? true : false;
        }

        public void Assigment(MyInt other)
        {
            ++AssigmentCount;
            this.Value = other.Value;
        }


        public override string ToString()
        => string.Format("{0}", Value);

        #endregion

        public object Clone()
        {
            ++AssigmentCount;
            return new MyInt(this.Value);
            
        }

        public int Value { get; set; } = 0;

        public static int CompareCount { get; set; } = 0;
        public static int AssigmentCount { get; set; } = 0;
    }
}
