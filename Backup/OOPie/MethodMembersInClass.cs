using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPieCore
{
    public class MethodMembersInClass
    {
        private string name;
        private string accessType;
        private string dataType;

        private List<MethodParameter> listOfMethodParameters = new List<MethodParameter>();

        public MethodMembersInClass(string name, string accessType, string dataType)
        {
            this.name = name;
            this.accessType = accessType;
            this.dataType = dataType;
        }

        public override string ToString()
        {
            string stringToReturn = AccessType + " " + DataType + " " + Name + "( ";
            for (int i = 0; i < listOfMethodParameters.Count; ++i)
            {
                if (i != 0)
                    stringToReturn = stringToReturn + " , ";

                stringToReturn = stringToReturn + listOfMethodParameters[i].Type + " " + listOfMethodParameters[i].Name;
            }
                stringToReturn = stringToReturn + ")";

                return stringToReturn;
        }

        public void addMethodParameter(string name, string type)
        {
            listOfMethodParameters.Add(new MethodParameter(name, type));
        }

        public string AccessType
        {
            get { return accessType; }
            set { accessType = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }

    }

    class MethodParameter
    {
        private string name;
        private string type;

        public MethodParameter(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public string Name
        {
            get { return name; }
        }

        public string Type
        {
            get { return type; }
        }
    }
}
