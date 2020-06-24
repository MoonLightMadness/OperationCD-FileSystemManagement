using OperationCD.PathParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationCD.UserConstructor
{
    class User
    {
        /// <summary>
        /// 用户名
        /// </summary>
        private string name { get; set; }
        /// <summary>
        /// 用户现在在文件系统的位置
        /// </summary>
        private string nowPath { get; set; }
        /// <summary>
        /// 现在在文件系统的位置，只显示当前文件夹的名字
        /// </summary>
        private string nowSinglePath { get; set; }
        private User(string name)
        {
            this.name = name;
            this.nowPath= @"\system\kernel\user\" + name + @"\file\home";
        }

        public static User GetInstance(string name)
        {
            User newUser = new User(name);
            newUser.SetPath(LogicalParser.parse(newUser.GetPath(), newUser));
            newUser.nowSinglePath = LogicalParser.singleParse(newUser);
            return newUser;
        }
        public string GetName()
        {
            return name;
        }
        /// <summary>
        /// 获取现在用户所在的逻辑地址
        /// </summary>
        /// <returns></returns>
        public string GetPath()
        {
            return nowPath;
        }

        public void SetPath(string path)
        {
            this.nowPath = path;
        }

        public string GetSinglePath()
        {
            return nowSinglePath;
        }

        public void SetSinglePath(string path)
        {
            nowSinglePath = path;
        }
    }
}
