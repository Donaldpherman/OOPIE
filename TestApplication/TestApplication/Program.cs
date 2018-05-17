using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("OO-PIES validation code.");
            Class1 c1 = new Class1(true);

            c1.myFunc1(3, 4);
            if (c1.getmyBool())
                System.Console.WriteLine(c1.getmyInt());
            Class3 c3 = new Class3();
            c3.myFunc1();
            c3.gather();
        }
    }
}
