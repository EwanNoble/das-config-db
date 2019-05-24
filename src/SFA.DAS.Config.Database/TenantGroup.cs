using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFA.DAS.Config.Database
{
    public class TenantGroup
    {
        public Guid TenantGroupId { get; set; }

        [ForeignKey(nameof(TenantObject))]
        public Guid TenantObjectId { get; set; }
        public string GroupName { get; set; }

        public TenantObject TenantObject { get; set; }

        public ICollection<TenantGroupMembership> TenantGroupMembers { get;set; }
    }
}
