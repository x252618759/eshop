using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eshop.Data.Model;

namespace Eshop.Data.Mapping
{
    public class MemberMap: EntityTypeConfiguration<MemberInfo>
    {
        public MemberMap()
        {
            ToTable("Eshop_Member");
        }
    }
}
