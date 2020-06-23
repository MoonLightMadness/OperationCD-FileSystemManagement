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
    /// 索引表操作
    /// </summary>
    class IndexTableOperation
    {
        /// <summary>
        /// 更新索引表
        /// </summary>
        /// <param name="u"></param>
        public static void Update(User u)
        {
            string[] fds = FDfiner.find(TruepathParser.parse(u)).Split('\n');
            string ipath = ConstValue.envpath + u.GetName() + ".env";
            StreamWriter sw = new StreamWriter(ipath);
            StringBuilder sb = new StringBuilder();
            foreach(string fd in fds)
            {
                sb.AppendLine(LogicalParser.parse(fd, u));
            }
            sw.Write(sb.ToString());
            sw.Flush();
            sw.Close();
        }
    }
}
