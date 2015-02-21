using System;

namespace FlatFinder.Core.Domain
{
    public abstract partial class BaseEntitySoftDelete : BaseEntityAuditDate
    {

        public bool Deleted { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
