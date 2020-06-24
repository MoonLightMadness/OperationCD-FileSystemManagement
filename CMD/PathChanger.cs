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
    /// 执行cdfore、cdback、cdroot命令
    /// </summary>
    class PathChanger
    {
        /// <summary>
        /// 进入下一级目录
        /// </summary>
        /// <param name="u"></param>
        /// <param name="cmd"></param>
        public static void fore(User u,string cmd)
        {
            string nextDir = cmd;
            if (!Directory.Exists(TruepathParser.parse(u) + @"\" + nextDir))
            {
                Console.WriteLine("目录不存在");
            }
            else
            {
                u.SetPath(u.GetPath() + @"\" + nextDir);
                u.SetSinglePath(nextDir);
            }
        }
        /// <summary>
        /// 返回上一级目录
        /// </summary>
        /// <param name="u"></param>
        public static void back(User u)
        {
            string tpath = TruepathParser.parse(u);
            int point = tpath.LastIndexOf(@"\");
            tpath = tpath.Substring(0, point);
            u.SetPath(LogicalParser.parse(tpath,u));
            u.SetSinglePath(LogicalParser.singleParse(u));
        }
        /// <summary>
        /// 返回根目录
        /// </summary>
        /// <param name="u"></param>
        public static void root(User u)
        {
            string tpath = ConstValue.userpath + u.GetName() + @"\file\home";
            u.SetPath(LogicalParser.parse(tpath, u));
            u.SetSinglePath(LogicalParser.singleParse(u));
        }
    }
}
