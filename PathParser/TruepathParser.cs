using OperationCD.UserConstructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationCD.PathParser
{
    /// <summary>
    /// 将逻辑地址解析为实际地址
    /// </summary>
    class TruepathParser
    {
        /// <summary>
        /// 实际地址原型
        /// </summary>
        private static string prototype = @".\system\kernel\user\";

        public static string parse(User u)
        {
            return prototype + u.GetName() + @"\file\" + u.GetPath();
        }


    }
}
