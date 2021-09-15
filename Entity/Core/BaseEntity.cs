using System;

namespace Entity.Core
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
    }
}
