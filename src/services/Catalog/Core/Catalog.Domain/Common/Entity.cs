using System;

namespace Catalog.Domain.Common
{
   public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
