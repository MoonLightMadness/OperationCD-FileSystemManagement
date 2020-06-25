using OperationCD.PathParser;
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
    /// 获取该模拟系统信息
    /// </summary>
    class SystemInfo
    {
        string info;
        /// <summary>
        /// 获取系统信息
        /// </summary>
        /// <returns></returns>
        public static string GetSystemInfo(User u)
        {
            //计算剩余内存
            long size = 0;
            FileInfo fi;
            try
            {
                FDfiner.Clear();
                foreach (string path in FDfiner.findFile(ConstValue.userpath).Split('\n'))
                {
                    if (path.Equals("")) continue;
                    fi = new FileInfo(path.Trim());
                    size += fi.Length;
                }
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
            //系统名
            string systemname = "SimOS-FM-System";
            //版本号
            string version = "0.0.3";
            //时间
            string time = DateTime.Now.ToString();
            //用户名
            string user = "管理员";
            if (u != null) user = u.GetName();
            string info = "欢迎使用" + systemname + "---" + version + "\n用户名:" + user + "\n时间:" + time +
                "\nRAM:" + size + "/1048576Byte";
            return info;
        }
    }
}
