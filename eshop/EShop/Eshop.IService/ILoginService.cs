using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eshop.Data.Model;

namespace Eshop.IService
{
    public interface ILoginService
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="memberInfo"></param>
        void Register(MemberInfo memberInfo);
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pwd">加密后的密码</param>
        /// <returns></returns>
        MemberInfo Login(string username, string pwd);
    }
}
