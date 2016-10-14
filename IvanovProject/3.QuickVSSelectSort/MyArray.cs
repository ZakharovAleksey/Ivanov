using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _3.QuickVSSelectSort
{
    class MyArray : ICloneable
    {
        static Random rand = new Random();

        public MyArray(int size)
        {
            Size = size;
            Body = new MyInt[Size];
            for (int i = 0; i < Size; ++i)
                Body[i] = new MyInt();
        }

        #region Methods

        public void fillWithRandomValues(int minValue, int maxValue)
        {
            for (int i = 0; i < Size; ++i)
                Body[i].Value = rand.Next(minValue, maxValue);
        }

        public object Clone()
        {
            MyArray res = new MyArray(Size);
            for (int i = 0; i < Size; ++i)
                res.Body[i] = (MyInt)this.Body[i].Clone();

            return res;
        }

        public void BubbleSortStep(int stepCount, bool less)
        {
            Debug.Assert(stepCount <= Size - 1, "Step Count index must be less then " + Size.ToString() + " !");

            for (int i = 0; i < stepCount; ++i)
            {
                for (int j = i + 1; j < Size; ++j)
                {
                    if (less)
                    {
                        if (Body[i] > Body[j])
                        {
                            MyInt temp = Body[i];
                            Body[i] = Body[j];
                            Body[j] = temp;
                        }
                    }
                    else
                    {
                        if (Body[i] < Body[j])
                        {
                            MyInt temp = Body[i];
                            Body[i] = Body[j];
                            Body[j] = temp;
                        }
                    }

                }
            }
            MyInt.AssigmentCount = 0;
            MyInt.CompareCount = 0;
        }

        #endregion



        #region Overloading

        public  MyInt this[int ID]
        {
            get { return Body[ID]; }
            set { Body[ID] = value; }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < Size; ++i)
                str.Append(Body[i] + " ");

            return str.ToString();
        }

        #endregion



        public int Size { get; set; } = 0;
        MyInt[] Body { get; set; } 
    }
}
