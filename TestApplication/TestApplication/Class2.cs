using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApplication
{
    public class Class2 :  Class1
    {
        private int myInt2;
        public int AddMine2()
        {
            return myInt2 + base.getmyInt();
        }

        public Class2() :
            base(true)
        {
            myInt2 = 5;
        }
    }
}
