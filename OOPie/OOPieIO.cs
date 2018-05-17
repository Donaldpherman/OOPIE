using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OOPieCore
{
    public static class OOPieIO
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        public static void Save(string path, string text)
        {
            StreamWriter save = new StreamWriter(File.Create(path));
            save.Write(text);
            save.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string Load(string path)
        {
            StreamReader s = new StreamReader(path);
            string program = "";
            program = s.ReadToEnd();;
            s.Close();
            return program;
        }
    }
}
