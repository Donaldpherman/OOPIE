using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApplication
{

// Summary description for Class1.

        public class Class1
        {
            private bool myBool;
            public int myInt;
            protected double myDouble;

            public Class1(bool mb)
            {
                myBool = mb;
                myInt = 0;
                myDouble = 0.0;
            }
            public void myFunc1(int A, int B)
            {
                myInt = A + B + getmyInt();
            }
            public int getmyInt()
            {
                return myInt;
            }
            public double getmyDouble()
            {
                return myDouble;
            }
            public bool getmyBool()
            {
                return myBool;
            }
        }
}
