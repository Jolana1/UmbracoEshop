using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoEshop.lib.Repositories
{
   public class UmbracoEshopMemberRepository: _BaseRepository
    {
        public const string UmbracoEshopMemberTypeAlias = "EshopMember";
        public const string UmbracoEshopMemberAdminRole = "EshopAdmin";
        public const string UmbracoEshopMemberCustomerRole = "EshopZakaznik";
    }
}
