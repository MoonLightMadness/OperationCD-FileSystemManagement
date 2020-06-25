using OperationCD.CMD;
using OperationCD.PathParser;
using OperationCD.Supporter;
using OperationCD.UserConstructor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OperationCD
{
    /// <summary>
    /// 操作系统课设
    /// </summary>
    class Program
    {
        /*设计题目：文件系统管理
        设计内容：模拟 unix 多个登录界面（3 个用户）,在系统出现登录模块（输入旧用户或新增
        用户）后 ,输入用户与口令,在用户登录后进行系统初始化,建文件卷、将用户和口令信息保
        存在假定的磁盘空间里,同时备份到几个指定的文件中,供下次启动此系统时恢复用。
            模拟磁盘：
        申请 1M 内存空间,供最多 3 个用户,并对用户的模拟磁盘的目录结构,文件全部存入文件中,
        在下次启动时恢复到系统的目录树及相应的链表中。
        设计要求：模拟 unix 文件系统的命令与其命令的具体实现：
        （1） login:用户登录；
        （2） logout: 用户退出系统
        （3） canceluser:取消一个用户
        （4） modifypsw:修改用户的密码
        （5） dir:列出当前目录下的所有文件及子目录
        （6） cd:显示当前的目录名
        （7） cdback:退到上一级目录
        （8） cdfore: 进入下一级子目录
        （9） cdroot:回到根目录
        （10） mkdir:新建一个子目录
        （11） my_deletedir:删除一个子目录
        （12） my_create:新建一个文件
        （13） my_deletefile:删除一个文件
        设计报告：
        1、给出主要算法流程图
        2、给出用到的主要数据结构
        3、给出测试数据和测试结果
         */
        /// <summary>
        /// 表示用户
        /// </summary>
        private static User user;
        /// <summary>
        /// 命令分析器
        /// </summary>
        private static CMDAnalyser analyser;
        /// <summary>
        /// 命令列表
        /// </summary>
        private static XCMD[] xcmds;
        static void Main(string[] args)
        {
            //反射模式
            //analyser = new CMDAnalyser();
            //xcmds = analyser.Get();
            //string cmd;
            //while (true)
            //{
            //    if (user != null) Console.Write(user.GetName() + "@" + user.GetSinglePath() + ">");
            //    string[] cmds = Console.ReadLine().Split(' ');
            //    cmd = cmds[0];
            //    foreach(XCMD xcmd in xcmds)
            //    {
            //        if (xcmd.cmd == cmd)
            //        {
            //            Type t = Type.GetType(xcmd.classname);
            //            MethodInfo minfo = t.GetMethod(xcmd.funcname);
            //            user= (User)minfo.Invoke(null,new object[] { user});
            //        }
            //    }
            //}
            //显示欢迎信息
            Console.WriteLine(SystemInfo.GetSystemInfo(user));
            //普通模式
            string cmd;
            while (true)
            {
                if (user != null) Console.Write(user.GetName() + "@" + user.GetSinglePath() + ">");
                cmd = Console.ReadLine();
                Loger.Write(cmd, user);
                if (user != null)
                    excutecmd(cmd);
                else
                    //管理员模式
                    excutecmdpre(cmd);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// 未登录时命令,此时为管理员模式
        /// </summary>
        /// <param name="cmd"></param>
        static void excutecmdpre(string cmd)
        {
            string[] cmds = cmd.Split(' ');
            cmd = cmds[0];
            switch (cmd)
            {
                //登录
                case "login":
                    user=Login.login(user);
                    break;
                //创建一个新用户
                case "create_user":
                    SuperCMD.create_user(cmds[1], cmds[2]);
                    break;
                //返回系统信息
                case "info":
                    Console.WriteLine(SystemInfo.GetSystemInfo(user));
                    break;
                default:
                    if (cmd == "\n") Console.WriteLine();
                    else
                    {
                        Console.WriteLine("没有这样的命令，请检查");
                    }
                    break;
            }
        }
        /// <summary>
        /// 登陆后命令
        /// </summary>
        /// <param name="cmd"></param>
        static void excutecmd(string cmd)
        {
            string[] cmds = cmd.Split(' ');
            cmd = cmds[0];
            switch (cmd)
            {
                //登出
                case "logout":
                    CMD.Login.logout(ref user);
                    break;
                //清屏
                case "clr":
                    Console.Clear();
                    break;
                //取消该用户
                case "cancleuser":
                    UserOperation.cancle(user);
                    Login.logout(ref user);
                    break;
                //更改密码
                case "modifypsw":
                    PWDChanger.change(user);
                    break;
                //输出当前目录下所有文件及子目录
                case "dir":
                    Dir.GetDir(user);
                    break;
                //显示当前目录名
                case "cd":
                    Console.WriteLine(user.GetSinglePath());
                    break;
                //进入下一级目录
                case "cdfore":
                    PathChanger.fore(user, cmds[1]);
                    break;
                //返回上一级目录
                case "cdback":
                    PathChanger.back(user);
                    break;
                //返回根目录
                case "cdroot":
                    PathChanger.root(user);
                    break;
                //新建文件夹
                case "mkdir":
                    DirectoryOperation.makedir(user, cmds[1]);
                    break;
                //删除目录
                case "my_deletedir":
                    DirectoryOperation.deletedir(user, cmds[1]);
                    break;
                //新建一个文件
                case "my_create":
                    FileOperation.create(user, cmds[1]);
                    break;
                //删除一个文件
                case "my_deletefile":
                    FileOperation.delete(user, cmds[1]);
                    break;
                //返回系统信息
                case "info":
                    Console.WriteLine(SystemInfo.GetSystemInfo(user));
                    break;
                //输入错误
                default:
                    if (cmd.Trim() == "\n") Console.WriteLine();
                    else
                    {
                        Console.WriteLine("没有这样的命令，请检查");
                    }
                    break;
            }
        }
    }
}
