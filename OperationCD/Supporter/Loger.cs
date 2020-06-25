using OperationCD.UserConstructor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationCD.Supporter
{
    /// <summary>
    /// 负责Log文件的写入与读取
    /// </summary>
    class Loger
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="info"></param>
        public static void Write(string info,User u)
        {
            string user = "管理员";
            if (u != null) user = u.GetName();
            StreamWriter sw = new StreamWriter("./Log.txt",true);
            sw.Write(user + ":" + DateTime.Now.ToString() + "---" + info+"\n");
            sw.Flush();
            sw.Close();
        }
        /// <summary>
        /// 读取日志
        /// </summary>
        /// <returns></returns>
        public static string Read()
        {
            StreamReader sr = new StreamReader("./Log.txt");
            string info = sr.ReadToEnd();
            sr.Close();
            return info;
        }
    }
}
