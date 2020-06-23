using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationCD.PathParser
{
    class FDfiner
    {
        private static StringBuilder sb = new StringBuilder();
        /// <summary>
        /// 找到该目录下所有文件及文件夹
        /// </summary>
        /// <param name="prototype">源地址</param>
        /// <returns>返回的是真实路径</returns>
        public static string find(string prototype)
        {
            //先搜索文件
            string[] files = Directory.GetFiles(prototype);
            foreach(string file in files)
            {
                sb.AppendLine(file);
            }
            //再搜索文件夹
            string[] directorise = Directory.GetDirectories(prototype);
            foreach(string directory in directorise)
            {
                sb.AppendLine(directory);
                find(directory);
            }
            return sb.ToString().Trim();
        }
    }
}
