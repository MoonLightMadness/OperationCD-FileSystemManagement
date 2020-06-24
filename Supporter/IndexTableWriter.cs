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
    /// 读取索引表
    /// </summary>
    class IndexTableWriter
    {
        /// <summary>
        /// 向索引表写入数据
        /// </summary>
        /// <param name="u"></param>
        /// <param name="data"></param>
        /// <param name="append">是否为追加模式</param>
        public static void Write(User u,string data,bool append)
        {
            string envpath = ConstValue.envpath + u.GetName() + ".env";
            StreamWriter sw = new StreamWriter(envpath,append);
            sw.WriteLine(data);
            sw.Flush();
            sw.Close();
        }
    }
}
