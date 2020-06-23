using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationCD.Supporter
{
    /// <summary>
    /// 常量池
    /// </summary>
    class ConstValue
    {
        /// <summary>
        /// User目录路径,真实路径
        /// </summary>
        public static readonly string userpath = @".\system\kernel\user\";
        /// <summary>
        /// kernel路径，真实路径
        /// </summary>
        public static readonly string kernelpath = @".\system\kernel\";
        /// <summary>
        /// 索引表的路径,真实路径
        /// </summary>
        public static readonly string envpath = @".\system\kernel\environment\";
    }
}
