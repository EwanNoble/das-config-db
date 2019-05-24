using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFA.DAS.Config.Database
{
    public class TenantGroupMembership
    {
        public Guid TenantGroupId { get; set; }
        public Guid TenantObjectId { get; set; }

        public TenantGroup TenantGroup { get; set; }
        public TenantObject TenantObjectMember { get; set; }
    }
}
