using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eshop.Data.Model;
using Eshop.IService;
using Eshop.Core;

namespace Eshop.Service
{
    public class LoginService : ILoginService
    {
        IRepository<MemberInfo> memberRepository;
        public LoginService(
            IRepository<MemberInfo> _memberRepository
            )
        {
            memberRepository = _memberRepository;
        }
        public MemberInfo Login(string username, string pwd)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(pwd))
                throw new Exception("用户名或者密码不能为空");
            var model = memberRepository.Table.Where(p => p.UserName == username && p.Password == pwd).FirstOrDefault();
            return model;
        }

        public void Register(MemberInfo memberInfo)
        {
            memberRepository.Insert(memberInfo);
        }
    }
}
