using System;

namespace FlatFinder.Core.Domain
{
    public abstract partial class BaseEntityAuditDate : BaseEntity
    {
        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
