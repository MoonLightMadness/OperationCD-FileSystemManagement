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
    class IndexTableReader
    {

        public static string ReadToEnd(User u)
        {
            string envpath = ConstValue.envpath + u.GetName() + ".env";
            StreamReader sr = new StreamReader(envpath);
            string data = sr.ReadToEnd();
            sr.Close();
            return data;
        }
    }
}
