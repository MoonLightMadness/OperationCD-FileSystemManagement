using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationCD.Supporter
{
    class UserSupporter
    {
        /// <summary>
        ///  根据用户名获取密码
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetPWD(string name)
        {
            string path = ConstValue.userpath +name+@"\"+ name+".user";
            StreamReader sr = new StreamReader(path);
            string data = sr.ReadToEnd().Split('\n')[1];
            sr.Close();
            return data.Replace("PWD=","").Trim();
        }
        /// <summary>
        /// 创建备份文件
        /// </summary>
        /// <param name="name"></param>
        public static void Backup(string name)
        {
            string bpath = ConstValue.kernelpath + @"backup\"+name+".user.backup";
            string upath = ConstValue.userpath + name + @"\" + name + ".user";
            if (!File.Exists(bpath))
            {
                File.Create(bpath).Close();
            }
            StreamReader sr = new StreamReader(upath);
            StreamWriter sw = new StreamWriter(bpath);
            sw.Write(sr.ReadToEnd());
            sw.Flush();
            sw.Close();
            sr.Close();
        }


    }
}
