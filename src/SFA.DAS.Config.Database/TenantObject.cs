using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFA.DAS.Config.Database
{
    public class TenantObject
    {
        public Guid TenantObjectId { get; set; }

        public ICollection<TenantGroupMembership> TenantGroupMemberships { get; set; }
    }
}
