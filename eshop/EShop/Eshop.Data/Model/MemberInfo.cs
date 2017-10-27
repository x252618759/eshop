using Eshop.Core;

namespace Eshop.Data.Model
{
    public class MemberInfo:BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
