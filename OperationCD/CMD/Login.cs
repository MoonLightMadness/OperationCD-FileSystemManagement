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
    /// 用户登录
    /// </summary>
    class Login
    {
        private static string workpath =ConstValue.userpath;
        public static User login(User u)
        {
            Console.WriteLine("请输入用户名: ");
            string name = Console.ReadLine();
            string[] paths = Directory.GetDirectories(workpath);
            DirectoryInfo info;
            foreach(string path in paths)
            {
                info = new DirectoryInfo(path);
                if (info.Name == name)
                {
                    //接下来验证密码
                    Console.WriteLine("请输入密码");
                    string pwd = Console.ReadLine();
                    if (pwd == Supporter.UserSupporter.GetPWD(name))
                    {
                        u = User.GetInstance(name);
                        return u;
                    }
                    else
                    {
                        Console.WriteLine("密码错误");
                        return null;
                    }
                }
            }
            Console.WriteLine("用户不存在");
            return null;
        }
        //登出
        public static void logout(ref User u)
        {
            u = null;
            Console.WriteLine("已退出");
        }
    }
}
