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
    /// 执行关于User的操作命令
    /// </summary>
    class UserOperation
    {
        /// <summary>
        /// 取消该用户
        /// </summary>
        /// <param name="u"></param>
        public static void cancle(User u)
        {
            string tpath = ConstValue.userpath + u.GetName();
            Directory.Delete(tpath, true);
            string ipath = ConstValue.envpath + u.GetName() + ".env";
            File.Delete(ipath);
        }
    }
}
