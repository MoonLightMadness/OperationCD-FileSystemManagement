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
    /// 执行文件操作命令
    /// </summary>
    class FileOperation
    {
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="u"></param>
        /// <param name="fname"></param>
        public static void create(User u,string fname)
        {
            if (fname.StartsWith(@".\"))
            {
                fname = fname.Substring(2);
            }
            string tpath = TruepathParser.parse(u);
            if (File.Exists(tpath + @"\" + fname))
            {
                Console.WriteLine("该文件夹已存在");
            }
            else
            {
               File.Create(tpath + @"\" + fname).Close();
            }
            //向索引表添加记录
            IndexTableWriter.Write(u, u.GetPath() + @"\" + fname, true);
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="u"></param>
        /// <param name="fname"></param>
        public static void delete(User u,string fname)
        {
            if (fname.StartsWith(@".\"))
            {
                fname = fname.Substring(2);
            }
            string tpath = TruepathParser.parse(u);
            try
            {
                File.Delete(tpath + @"\" + fname);
            }
            catch (Exception e)
            {
                Console.WriteLine("找不到该文件");
            }
            //更新索引表
            IndexTableOperation.Update(u);
        }
    }
}
