using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFA.DAS.Config.Database
{
    public class TenantUser
    {
        public Guid TenantUserId { get; set; }
        [ForeignKey(nameof(TenantObject))]
        public Guid TenantObjectId { get; set; }

        public TenantObject TenantObject { get; set; }
    }
}
