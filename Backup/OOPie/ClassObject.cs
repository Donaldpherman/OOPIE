using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPieCore
{
    public class ClassObject
    {
        private string nameOfClass;
        private string nameOfParentClass = null;
        string testStrinfDataMember;
        private HashSet<DataMembersInClass> listOfDataMembers = new HashSet<DataMembersInClass>();
        private Stack<MethodMembersInClass> stackOfMethodMembers = new Stack<MethodMembersInClass>();
        private List<Instance> listOfInstances = new List<Instance>();


        private List<string> listOfChildClasses = new List<string>();

        Dictionary<string, int> d = new Dictionary<string, int>();

        byte[] testArray = new byte[5];

        // for testing OO Pie
        ClassObject testReturnOfObject(string test)
        {
            return new ClassObject(test);
        }

        static ClassObject testReturnOfObjectstatic(string test)
        {
            return new ClassObject(test);
        }

        public ClassObject testReturnOfObjectPublic(string test)
        {
            return new ClassObject(test);
        }

        public static ClassObject testReturnOfObjectPublicStatic(string test)
        {
            return new ClassObject(test);
        }

        public List<Instance> ListOfInstances
        {
            get { return listOfInstances; }
            set { listOfInstances = value; }
        }

        void testNoAccessReturnVoid(bool testing)
        {
            int test = 1 + 1;
        }

        public void testNoAccessReturnVoidPublic(bool testing)
        {
            int test = 1 + 1;
        }

        static void testNoAccessReturnVoidStatic(bool testing)
        {
            int test = 1 + 1;
        }

        public static void testNoAccessReturnVoidPublicStatic(bool testing)
        {
            int test = 1 + 1;
        }

        public ClassObject(string nameOfClass)
        {
            this.nameOfClass = nameOfClass;
        }

        public string NameOfClass
        {
            get { return nameOfClass; }
        }

        public HashSet<DataMembersInClass> ListOfDataMembers
        {
            get { return listOfDataMembers; }
        }

        public Stack<MethodMembersInClass> StackOfMethodMembers
        {
            get { return stackOfMethodMembers; }
        }

        public string NameOfParentClass
        {
            get { return nameOfParentClass; }
            set { nameOfParentClass = value; }
        }

        public List<string> ListOfChildClasses
        {
            get { return listOfChildClasses; }
            set { listOfChildClasses = value; }
        }

        /*
        public void addDataMember(string name, string dataType, string accessType)
        {
            if (accessType == "public" || accessType == "private" || accessType == "internal" ||
                accessType == "protected")
                ListOfDataMembers.Add(new DataMembersInClass(name, dataType, accessType));
            else
                ListOfDataMembers.Add(new DataMembersInClass(name, dataType, ""));
        }
         * 
         * */

        public void addDataMember(string name, string dataType, string accessType, string lineNumber)
        {
            if (accessType == "public" || accessType == "private" || accessType == "internal" ||
                accessType == "protected")
                ListOfDataMembers.Add(new DataMembersInClass(name, dataType, accessType, int.Parse(lineNumber)));
            else
                ListOfDataMembers.Add(new DataMembersInClass(name, dataType, "", int.Parse(lineNumber)));
        }


        public void addMethodMember(string name, string accessType, string dataType)
        {
            if (accessType == "public" || accessType == "private" || accessType == "internal" ||
                accessType == "protected")
            {
                if (dataType == "")
                    StackOfMethodMembers.Push(new MethodMembersInClass(name, accessType, "void"));
                else StackOfMethodMembers.Push(new MethodMembersInClass(name, accessType, dataType));
            }
            else if (dataType == "public" || dataType == "private" || dataType == "internal" ||
                dataType == "protected")
                StackOfMethodMembers.Push(new MethodMembersInClass(name, dataType, accessType));
            else if (accessType == "void")
                StackOfMethodMembers.Push(new MethodMembersInClass(name, "void", ""));
            else if (dataType == "static")
                StackOfMethodMembers.Push(new MethodMembersInClass(name, "", accessType));
            else if (accessType == "static")
                StackOfMethodMembers.Push(new MethodMembersInClass(name, "", "void"));
            else
                StackOfMethodMembers.Push(new MethodMembersInClass(name, "", dataType));
        }
    }
}
