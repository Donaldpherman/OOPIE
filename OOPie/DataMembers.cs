using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPieCore
{
    public class DataMember
    {
        private string nameOfDataMember;
        private string dataTypeOfDataMember;
        private string accessTypeOfDataMember;

        public DataMember(string name, string dataType, string accessType)
        {
            nameOfDataMember = name;
            dataTypeOfDataMember = dataType;
            accessTypeOfDataMember = accessType;
        }

        public DataMember(string name)
        {
            DataMember(name, "", "");
        }

        // Properties
        public string NameOfDataMember
        {
            get { return nameOfDataMember; }
            set { nameOfDataMember = value; }
        }

        public string DataTypeOfDataMember
        {
            get { return dataTypeOfDataMember; }
            set { dataTypeOfDataMember = value; }
        }

        public string AccessTypeOfDataMember
        {
            get { return accessTypeOfDataMember; }
            set { accessTypeOfDataMember = value; }
        }


    }
}
