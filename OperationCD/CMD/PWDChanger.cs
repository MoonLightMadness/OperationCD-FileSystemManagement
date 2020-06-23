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
    class PWDChanger
    {
        public static void change(User u)
        {
            //先确认原密码
            Console.WriteLine("请输入原密码");
            string pre = Console.ReadLine();
            string pwd = Supporter.UserSupporter.GetPWD(u.GetName());
            if (pre == pwd)
            {
                Console.WriteLine("请输入新密码");
                pwd = Console.ReadLine();
                SavePWD(u.GetName(), pwd);
            }
            else
            {
                Console.WriteLine("密码错误");
            }
        }
        /// <summary>
        /// 管理员指令，直接更改密码
        /// </summary>
        /// <param name="u"></param>
        /// <param name="pwd"></param>
        //public static void change_s(User u,string pwd)
        //{
        //    SavePWD(u.GetName(), pwd);
        //}

        private static void SavePWD(string name,string pwd)
        {
            string path = ConstValue.userpath  + name + @"\" + name + ".user";
            string bpath = ConstValue.kernelpath + "backup" + @"\" + name + ".user.backup";
            StreamWriter sw = new StreamWriter(path);
            sw.Write("Name=" + name + "\n" + "PWD=" + pwd);
            sw.Flush();
            sw.Close();
            sw = new StreamWriter(bpath);
            sw.Write("Name=" + name + "\n" + "PWD=" + pwd);
            sw.Flush();
            sw.Close();
        }
    }
}
