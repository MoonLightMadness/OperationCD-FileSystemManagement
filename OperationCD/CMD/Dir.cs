using OperationCD.PathParser;
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
            string Path = TruepathParser.parse(u);
            //画出开头
            Console.WriteLine("Name" + GetSpaces("Name") + "Type" + GetSpaces("Type") + "Size");
            Console.WriteLine("------------------------------------------------------------------");
            //先获取文件夹
            DirectoryInfo info;
            string[] directories = Directory.GetDirectories(Path);
            foreach(string directory in directories)
            {
                info = new DirectoryInfo(directory);
                Console.WriteLine(info.Name+@"\" + GetSpaces(info.Name+@"\") + "Directory" + GetSpaces("Directory") + @"\");
            }
            //再获取文件列表
            string[] files = Directory.GetFiles(Path);
            FileInfo finfo;
            foreach (string file in files)
            {
                finfo = new FileInfo(file);
                Console.WriteLine(finfo.Name  + GetSpaces(finfo.Name ) + "File" + GetSpaces("File") + finfo.Length);
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
