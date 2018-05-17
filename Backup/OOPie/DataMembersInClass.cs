using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPieCore
{
    public class DataMembersInClass
    {
        private string nameOfDataMember;
        private string dataTypeOfDataMember;
        private string accessTypeOfDataMember;
        private int lineNumber;

        public DataMembersInClass(string name, string dataType, string accessType, int lineNumber)
        {
            nameOfDataMember = name;
            dataTypeOfDataMember = dataType;
            accessTypeOfDataMember = accessType;
            this.lineNumber = lineNumber;
        }

        public DataMembersInClass(string name, int lineNumber)
            : this(name, "", "", lineNumber)
        {
        }

        public override string ToString()
        {
            return AccessTypeOfDataMember + " " + DataTypeOfDataMember + " " + NameOfDataMember;
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

        public int LineNumber
        {
            get { return lineNumber; }
            set { lineNumber = value; }
        }

        public override bool Equals(object obj)
        {
            var other = obj as DataMembersInClass;
            if (other == null)
            {
                return false;
            }
            return this.accessTypeOfDataMember == other.accessTypeOfDataMember &&
                this.dataTypeOfDataMember == other.dataTypeOfDataMember &&
                this.lineNumber == other.lineNumber &&
                this.nameOfDataMember == other.nameOfDataMember;

        }

        public override int GetHashCode()
        {
            return (accessTypeOfDataMember + dataTypeOfDataMember + lineNumber + nameOfDataMember).GetHashCode();

        }
    }
}
