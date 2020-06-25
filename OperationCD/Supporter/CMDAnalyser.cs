using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OperationCD.Supporter
{
    /// <summary>
    /// 使用反射解析命令
    /// </summary>
    class CMDAnalyser
    {
        XCMD[] xcmds;
        public CMDAnalyser()
        {
            StreamReader sr = new StreamReader(".\\cmds.txt");
            string[] cmds = sr.ReadToEnd().Trim().Split('\n');
            sr.Close();
            xcmds = new XCMD[cmds.Length];
            int count = 0;
            foreach(string cmd in cmds)
            {
                if (cmd == null || cmd == "") continue;
                xcmds[count] = new XCMD();
                xcmds[count].cmd = cmd.Split(';')[0];
                xcmds[count].classname = cmd.Split(';')[1].Replace("class=","");
                xcmds[count].funcname = cmd.Split(';')[2].Replace("func=", "");
                xcmds[count].argstype = cmd.Split(';')[3].Replace("args=", "").Split('-');
                xcmds[count].returntype = cmd.Split(';')[4].Replace("return=","");
                count++;
            }
        }
        /// <summary>
        /// 获取命令清单
        /// </summary>
        /// <returns></returns>
        public XCMD[] Get()
        {
            return xcmds;
        }
    }

    class XCMD
    {
        /// <summary>
        /// 命令
        /// </summary>
        public string cmd { get; set; }
        /// <summary>
        /// 调用的类
        /// </summary>
        public string classname { get; set; }
        /// <summary>
        /// 调用的方法
        /// </summary>
        public string funcname { get; set; }
        /// <summary>
        /// 参数的类型
        /// </summary>
        public string[] argstype { get; set; }
        /// <summary>
        /// 返回值的类型
        /// </summary>
        public string returntype { get; set; }
    }
}
