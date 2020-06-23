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
    /// 执行文件夹相关命令操作
    /// </summary>
    class DirectoryOperation
    {
        /// <summary>
        /// 新建文件夹
        /// </summary>
        /// <param name="u"></param>
        /// <param name="dname">文件夹名字</param>
        public static void makedir(User u,string dname)
        {
            if (dname.StartsWith(@".\"))
            {
                dname=dname.Substring(2);
            }
            string tpath = TruepathParser.parse(u);
            if (Directory.Exists(tpath + @"\" + dname))
            {
                Console.WriteLine("该文件夹已存在");
            }
            else
            {
                Directory.CreateDirectory(tpath + @"\" + dname);
            }
            //向索引表添加记录
            IndexTableWriter.Write(u, u.GetPath() + @"\" + dname, true);
        }
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="u"></param>
        /// <param name="dname"></param>
        public static void deletedir(User u,string dname)
        {
            if (dname.StartsWith(@".\"))
            {
                dname = dname.Substring(2);
            }
            string tpath = TruepathParser.parse(u);
            try
            {
                Directory.Delete(tpath + @"\" + dname, true);
            }
            catch(Exception e)
            {
                Console.WriteLine("找不到该文件夹");
            }
            //更新索引表
            IndexTableOperation.Update(u);
        }
    }
}
