using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPieCore
{
    public class Class
    {
        private string nameOfClass;

        public Class(string nameOfClass)
        {
            this.nameOfClass = nameOfClass;
        }

        public string NameOfClass
        {
            get { return nameOfClass; }
        }
    }
}
