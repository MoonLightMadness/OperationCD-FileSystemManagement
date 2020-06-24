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
    /// 管理员操作指令
    /// </summary>
    class SuperCMD
    {

        public static void create_user(string name,string pwd)
        {
            //先创建好文件及文件夹
            string upath = ConstValue.userpath+name;
            Directory.CreateDirectory(upath);
            upath = upath + @"\" + name + ".user";
            File.Create(upath).Close();
            StreamWriter sw = new StreamWriter(upath);
            sw.Write("Name=" + name + "\n" + "PWD=" + pwd);
            sw.Flush();
            sw.Close();
            upath = ConstValue.userpath + name + @"\";
            Directory.CreateDirectory(upath + @"file\home\usr");
            string epath = ConstValue.envpath;
            File.Create(epath + name + ".env").Close();
            string bpath=ConstValue.kernelpath+@"backup\";
            File.Create(bpath + name + ".user.backup").Close();
            sw = new StreamWriter(bpath + name + "user.backup");
            sw.Write("Name=" + name + "\n" + "PWD=" + pwd);
            sw.Flush();
            sw.Close();
            User user = User.GetInstance(name);
            //更新索引表
            IndexTableOperation.Update(user);
            
        }
    }
}
