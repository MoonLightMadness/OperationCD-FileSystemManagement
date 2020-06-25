using OperationCD.PathParser;
using OperationCD.Supporter;
using OperationCD.UserConstructor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationCD.CMD
{
    /// <summary>
    /// 执行dir命令
    /// </summary>
    class Dir
    {
        public static void GetDir(User u)
        {
            StringBuilder sb = new StringBuilder();
            string pre = IndexTableReader.ReadToEnd(u);
            foreach(string s in pre.Split('\n'))
            {
                if (s == null || s == "") continue;
                sb.AppendLine(s);
            }
            string[] data = sb.ToString().Split('\n');
            sb.Clear();
            foreach(string s in data)
            {
                if (s.StartsWith(u.GetPath()))
                {
                    sb.AppendLine(s.Substring(s.IndexOf(u.GetPath()) + u.GetPath().Length+1));
                }
            }
            data = sb.ToString().Split('\n');
            sb.Clear();
            foreach(string s in data)
            {
                if (s == null || s == ""||s=="\n") continue;
                if (s.IndexOf('\\')>0) continue;
                Console.WriteLine(s.Split('\\')[0].Trim());
            }

        }

        private static string GetSpaces(string str)
        {
            int len = 30;
            int spa = len - str.Length;
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < spa; i++)
            {
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
