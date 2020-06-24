using OperationCD.UserConstructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationCD.PathParser
{
    /// <summary>
    /// 将实际地址转换为模拟文件系统的逻辑地址
    /// </summary>
    class LogicalParser
    {
        /// <summary>
        /// 实际地址原型
        /// </summary>
        private static string prototype = @"\system\kernel\user\";

        public static string parse(string truepath,User u)
        {
            if (truepath != "")
            {
                int point = truepath.IndexOf(prototype);
                //username/file/
                return truepath.Substring(point + prototype.Length + u.GetName().Length + 6);
            }
            return null;
        }
        public static string singleParse(User u)
        {
            int point = u.GetPath().LastIndexOf(@"\");
            if (point > 0)
            {
                return u.GetPath().Substring(point);
            }
            return u.GetPath();
        }
    }
}
