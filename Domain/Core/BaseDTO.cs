using System;

namespace Domain.Core
{
    public abstract class BaseDTO : IBaseDTO
    {
        public Guid Id { get; set; }
    }
}
