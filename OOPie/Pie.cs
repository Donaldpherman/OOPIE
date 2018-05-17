using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Antlr.Runtime.Debug;

namespace OOPieCore
{
    public static class Pie
    {
        private static Parse parser;
        //private static MyParser myParser;
        //private static string locationOfGrammerFile = @"C:\Users\Donald\Documents\Visual Studio 2008\Projects\CECS 547Project\OOPieGui\C-Sharp Grammers\C# 2.0 r7.cgt";

        static Pie()
        {
            parser = new Parse();
        }

        public static void LoadParser(string fileName)
        {
            int count = 0;
            parser.ParseFile(fileName, false, ref count);
            /*
            string searchPattern = Path.GetFileName(args[0]);
            string dir = string.Empty;

            dir = Path.GetDirectoryName(args[0]);
            if (dir == string.Empty)
                dir = Environment.CurrentDirectory;

            Parser.
            parser.ParseDirectory(dir, searchPattern, ref count, ref files_total);
             * */
        }
  
    }
}
