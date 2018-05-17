using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;

namespace OOPieCore
{
    public static class Helper
    {
        private static Stack<ClassObject> stackOfClasses = new Stack<ClassObject>();
        private static Stack<string> lastTerminalTokenStack = new Stack<string>();
        private static Stack<string> geneticTokenStack = new Stack<string>();
        
        static byte[] testArray = new byte[5];

        private static bool insideParentheses = false;

        private static bool insideConstructor = false;

        private static bool insideMethodDeclaration = false;

        private static bool sameLine = false;

        // for testing OO Pie
        static ClassObject testReturnOfObject(string test)
        {
            return new ClassObject(test);
        }

        static void testNoAccessReturnVoid(bool testing)
        {
            int test = 1 + 1;
        }

        public static void clear()
        {
            stackOfClasses.Clear();
            lastTerminalTokenStack.Clear();
            geneticTokenStack.Clear();
        }

        public static void clearTerminalTokenStack()
        {
            lastTerminalTokenStack.Clear();
        }

        public static bool addIdentifier(string nameOfIdentifier, int lineNumber)
        {

            // add a class
            if (lastTerminalTokenStack.Count > 0 && lastTerminalTokenStack.Peek() == "class")
            {
                for (int i = 0; i < stackOfClasses.Count; ++i)
                {
                    if (stackOfClasses.ElementAt(i).NameOfClass == nameOfIdentifier)
                        return false;
                }

                stackOfClasses.Push(new ClassObject(nameOfIdentifier));
                lastTerminalTokenStack.Pop();
                return true;
            }
            // add a Method Parameter
            else if (InsideMethodDeclaration)
            {
                addMethodParameter(nameOfIdentifier);
                return true;
            }
            // add parent class
            else if (lastTerminalTokenStack.Count > 1 && lastTerminalTokenStack.ElementAt(1) == ":")
            {
                stackOfClasses.Peek().NameOfParentClass = nameOfIdentifier;
                lastTerminalTokenStack.Pop();
                lastTerminalTokenStack.Pop();
            }
            else if (sameLine && !(stackOfClasses.Peek().ListOfDataMembers.ElementAt(stackOfClasses.Peek().ListOfDataMembers.Count - 1).DataTypeOfDataMember.Substring(
            stackOfClasses.Peek().ListOfDataMembers.ElementAt(stackOfClasses.Peek().ListOfDataMembers.Count - 1).DataTypeOfDataMember.Length -1 ) == ">" ))
            {
                stackOfClasses.Peek().addDataMember(nameOfIdentifier,
                    stackOfClasses.Peek().ListOfDataMembers.ElementAt(stackOfClasses.Peek().ListOfDataMembers.Count - 1).DataTypeOfDataMember,
                    stackOfClasses.Peek().ListOfDataMembers.ElementAt(stackOfClasses.Peek().ListOfDataMembers.Count - 1).AccessTypeOfDataMember,
                    stackOfClasses.Peek().ListOfDataMembers.ElementAt(stackOfClasses.Peek().ListOfDataMembers.Count - 1).LineNumber.ToString());
            }
                /*
                // add a Data Member
            else if (stackOfClasses.Count > 0 && lastTerminalTokenStack.Count > 1 && !InsideParentheses)
            {
                stackOfClasses.Peek().addDataMember(nameOfIdentifier, lastTerminalTokenStack.Pop(), lastTerminalTokenStack.Pop());
            }
                 * */

            addInstanceOfObjectUse(nameOfIdentifier, lineNumber);

            return false;
        }

        public static void addDataMember(string dataMember, string lineNumber)
        {
            // Single parameter generic.
            if (stackOfClasses.Count > 0 && lastTerminalTokenStack.Count > 3  && !InsideParentheses &&
                lastTerminalTokenStack.ElementAt(1) == "<")
            {
                lastTerminalTokenStack.Pop();
                lastTerminalTokenStack.Pop();
                string dataType = lastTerminalTokenStack.Pop();
                string symbol = lastTerminalTokenStack.Pop();
                stackOfClasses.Peek().addDataMember(dataMember, lastTerminalTokenStack.Pop() + symbol + dataType + ">", lastTerminalTokenStack.Pop(), lineNumber);
            }
            else if (stackOfClasses.Count > 0 && lastTerminalTokenStack.Count > 3 && !InsideParentheses &&
                lastTerminalTokenStack.ElementAt(2) == "<")
            {
                lastTerminalTokenStack.Pop();
                lastTerminalTokenStack.Pop();
                lastTerminalTokenStack.Pop();
                string dataType = lastTerminalTokenStack.Pop();
                string dataTypeTwo = lastTerminalTokenStack.Pop();
                string symbol = lastTerminalTokenStack.Pop();
                stackOfClasses.Peek().addDataMember(dataMember, lastTerminalTokenStack.Pop() + symbol + dataType + "," + dataTypeTwo + ">", lastTerminalTokenStack.Pop(), lineNumber);
            
            }
            else if (stackOfClasses.Count > 0 && lastTerminalTokenStack.Count > 0 && !InsideParentheses)
            {
                stackOfClasses.Peek().addDataMember(dataMember, lastTerminalTokenStack.Pop(), lastTerminalTokenStack.Pop(), lineNumber);
            }
        }

        public static void addMethodMember(string methodMember)
        {
            if (lastTerminalTokenStack.Count > 1)
            stackOfClasses.Peek().addMethodMember(methodMember, lastTerminalTokenStack.Pop(), lastTerminalTokenStack.Pop());
            else stackOfClasses.Peek().addMethodMember(methodMember, lastTerminalTokenStack.Pop(), "");


            /*
            if (stackOfClasses.Count > 0 && !InsideParentheses && lastTerminalTokenStack.Count <= (lastTerminalTokenStack.Count - 2) &&

                lastTerminalTokenStack.ElementAt(lastTerminalTokenStack.Count - 2) == "public" )
            {
                stackOfClasses.Peek().addMethodMember(methodMember, lastTerminalTokenStack.Pop(), lastTerminalTokenStack.Pop());
            }
             * */
                /*
            else if (stackOfClasses.Count > 0 && lastTerminalTokenStack.Count > 0 && !InsideParentheses)
            {
                stackOfClasses.Peek().addMethodMember(methodMember, lastTerminalTokenStack.Pop(), "void");
            }
                 * */
        }

        public static void addMethodParameter(string methodParameterName)
        {
            if (stackOfClasses.Count > 0 && lastTerminalTokenStack.Count > 0 && !InsideParentheses)
            {
                stackOfClasses.Peek().StackOfMethodMembers.Peek().addMethodParameter(methodParameterName, lastTerminalTokenStack.Pop());
                //stackOfClasses.Peek().StackOfMethodMembers.Peek().addMethodParameter(methodParameterName, "" );

            }
        }

        public static void addTerminalTokenOnStack(string termindalToken)
        {
                lastTerminalTokenStack.Push(termindalToken);
        }

        public static void addInstanceOfObjectUse(string nameOfInstance, int lineNumber)
        {
            if (stackOfClasses.Count < 1)
                return;


            if (stackOfClasses.Peek().ListOfInstances.Exists(delegate(Instance instance)
            {
                return instance.NameOfVariable.Exists(delegate(string name)
                {
                    return name == nameOfInstance;
                });
            }) )
            {
                stackOfClasses.Peek().ListOfInstances.Find(delegate(Instance instance)
                {
                    return instance.NameOfVariable.Exists(delegate(string name)
                    {
                        return name == nameOfInstance;
                    });
                }
                ).LineNumberWhereObjectIsUsed.Add(lineNumber);

            }
        }

        public static void addInstanceOfObject(string nameOfClass, int lineNumber)
        {
            string nameOfInstance;
            if ( lastTerminalTokenStack.Count > 0 && lastTerminalTokenStack.Peek() == nameOfClass )
            {
                lastTerminalTokenStack.Pop();
                // added 7:20 pm 5/08/2011
                if (lastTerminalTokenStack.Count > 0)
                    nameOfInstance = lastTerminalTokenStack.Pop();
                else
                    // return;
                    nameOfInstance = "";
            }
            else
                nameOfInstance = "";

            if (!CodeDomProvider.CreateProvider("C#").IsValidIdentifier(nameOfInstance))
                return;
 
            if (!stackOfClasses.Peek().ListOfInstances.Exists(delegate(Instance instance)
            {
                return instance.NameOfClass == nameOfClass;
            }
            ))
            {
                stackOfClasses.Peek().ListOfInstances.Add(new Instance(nameOfClass, nameOfInstance));
            }

            stackOfClasses.Peek().ListOfInstances.Find(delegate(Instance instance)
            {
                return instance.NameOfClass == nameOfClass;
            }
            ).NameOfVariable.Add(nameOfInstance);


            stackOfClasses.Peek().ListOfInstances.Find(delegate(Instance instance)
            {
                return instance.NameOfClass == nameOfClass;
            }).LineNumberWhereObjectIsUsed.Add(lineNumber);
        }

        public static void addLineNumberWhereInstanceIsUsed(string nameOfInstance, int lineNumber)
        {
            stackOfClasses.Peek().ListOfInstances.Find(delegate(Instance instance)
            {
                return instance.NameOfVariable.Equals(nameOfInstance);

            }).LineNumberWhereObjectIsUsed.Add(lineNumber);
        }

        public static string ToString()
        {
            buildClassHierarchy();

            removeVoidFromContructors();

            addDataMembersToClassInstanceList();

            string stringToReturn ="";
            for (int i = 0; i < stackOfClasses.Count; ++i)
            {
                stringToReturn = stringToReturn + "Class: ";
                stringToReturn = stringToReturn + stackOfClasses.ElementAt(i).NameOfClass;
                stringToReturn = stringToReturn + System.Environment.NewLine;

                stringToReturn = stringToReturn + "\t Data Members:" + System.Environment.NewLine;

                for (int j = 0; j < stackOfClasses.ElementAt(i).ListOfDataMembers.Count; ++j)
                {
                    stringToReturn = stringToReturn + "\t\t" + stackOfClasses.ElementAt(i).ListOfDataMembers.ElementAt(j).ToString() + 
                        System.Environment.NewLine;
                }

                stringToReturn = stringToReturn + "\t Method Members:" + System.Environment.NewLine;

                for (int j = 0; j < stackOfClasses.ElementAt(i).StackOfMethodMembers.Count; ++j)
                {
                    stringToReturn = stringToReturn + "\t\t" + stackOfClasses.ElementAt(i).StackOfMethodMembers.ElementAt(j).ToString() +
                        System.Environment.NewLine;
                }


                /*
                for (int j = stackOfClasses.ElementAt(i).StackOfMethodMembers.Count - 1 ; j < -1; --j)
                {
                    stringToReturn = stringToReturn + "\t\t" + stackOfClasses.ElementAt(i).StackOfMethodMembers.ElementAt(j).ToString() +
                        System.Environment.NewLine;
                }
                 * 
                 * */

                if (stackOfClasses.ElementAt(i).NameOfParentClass != null)
                {
                    stringToReturn = stringToReturn + "\t Ancestor:" + "\t" + stackOfClasses.ElementAt(i).NameOfParentClass + 
                        System.Environment.NewLine;
                }

                if (stackOfClasses.ElementAt(i).ListOfChildClasses.Count > 0)
                {
                    stringToReturn = stringToReturn + "\t Descendent Classes: " + System.Environment.NewLine;

                    for (int j = 0; j < stackOfClasses.ElementAt(i).ListOfChildClasses.Count; ++j)
                    {
                        stringToReturn = stringToReturn + "\t\t" + stackOfClasses.ElementAt(i).ListOfChildClasses.ElementAt(j) +
                            System.Environment.NewLine;
                    }
                }

                if (stackOfClasses.ElementAt(i).ListOfInstances.Count > 0)
                {
                    stringToReturn = stringToReturn + "\t Instances of Classes created and used and lineNumbers: ";

                    for (int j = 0; j < stackOfClasses.ElementAt(i).ListOfInstances.Count; ++j)
                    {
                        stringToReturn = stringToReturn + System.Environment.NewLine + "\t\t" + stackOfClasses.ElementAt(i).ListOfInstances.ElementAt(j)
                            .NameOfClass;

                        for (int indexThree = 0; indexThree < stackOfClasses.ElementAt(i).ListOfInstances.ElementAt(j).LineNumberWhereObjectIsUsed
                            .Count; ++indexThree)
                        {
                            stringToReturn = stringToReturn + " , " + stackOfClasses.ElementAt(i).ListOfInstances.ElementAt(j).LineNumberWhereObjectIsUsed
                                .ElementAt(indexThree);
                        }
                    }

                    stringToReturn = stringToReturn + System.Environment.NewLine;
                }


            }

            return stringToReturn;
        }

        private static void addDataMembersToClassInstanceList()
        {
            for (int i = 0; i < stackOfClasses.Count; ++i)
            {
                for (int j = 0; j < stackOfClasses.ElementAt(i).ListOfDataMembers.Count; ++j)
                {
                    if (!stackOfClasses.ElementAt(i).ListOfInstances.Exists(delegate(Instance instance)
                    {
                        return instance.NameOfClass.Equals(stackOfClasses.ElementAt(i).ListOfDataMembers.ElementAt(j).DataTypeOfDataMember);
                    }))
                        continue;

                    stackOfClasses.ElementAt(i).ListOfInstances.Find(delegate(Instance instance)
                    {
                        return instance.NameOfClass.Equals(stackOfClasses.ElementAt(i).ListOfDataMembers.ElementAt(j).DataTypeOfDataMember);
                    }).LineNumberWhereObjectIsUsed.Add(stackOfClasses.ElementAt(i).ListOfDataMembers.ElementAt(j).LineNumber);
                }
            }

        }

        private static void removeVoidFromContructors()
        {
            for (int i = 0; i < stackOfClasses.Count; ++i)
            {
                for (int j = 0; j < stackOfClasses.ElementAt(i).StackOfMethodMembers.Count; ++j)
                {
                    if (stackOfClasses.ElementAt(i).StackOfMethodMembers.ElementAt(j).Name == stackOfClasses.ElementAt(i).NameOfClass)
                        stackOfClasses.ElementAt(i).StackOfMethodMembers.ElementAt(j).DataType = "";
                }
            }
        }

        private static void buildClassHierarchy()
        {
            for (int i = 0; i < stackOfClasses.Count; ++i)
            {
                for (int j = 0; j < stackOfClasses.Count; ++j)
                {
                    if (stackOfClasses.ElementAt(i).NameOfClass == stackOfClasses.ElementAt(j).NameOfParentClass)
                    {
                        stackOfClasses.ElementAt(i).ListOfChildClasses.Add(stackOfClasses.ElementAt(j).NameOfClass);
                    }
                }
            }

        }

        public static bool InsideParentheses
        {
            get { return Helper.insideParentheses; }
            set { Helper.insideParentheses = value; }
        }

        public static bool InsideConstructor
        {
            get { return Helper.insideConstructor; }
            set { Helper.insideConstructor = value; }
        }

        public static bool InsideMethodDeclaration
        {
            get { return insideMethodDeclaration; }
            set { insideMethodDeclaration = value; }
        }

        public static bool SameLine
        {
            get { return Helper.sameLine; }
            set { Helper.sameLine = value; }
        }
    }
}
