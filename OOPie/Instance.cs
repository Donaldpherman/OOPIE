using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPieCore
{
    public class Instance
    {
        private string nameOfClass;

        private List<string> nameOfVariable = new List<string>();

        private HashSet<int> lineNumberWhereObjectIsUsed = new HashSet<int>();

        public Instance(string nameOfClass, string nameOfVariable)
        {
            this.nameOfClass = nameOfClass;
            this.nameOfVariable.Add(nameOfVariable);
        }

        public HashSet<int> LineNumberWhereObjectIsUsed
        {
            get { return lineNumberWhereObjectIsUsed; }
            set { lineNumberWhereObjectIsUsed = value; }
        }

        public string NameOfClass
        {
            get { return nameOfClass; }
            set { nameOfClass = value; }
        }

        public List<string> NameOfVariable
        {
            get { return nameOfVariable; }
            set { nameOfVariable = value; }
        }
    }
}
