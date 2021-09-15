using Entity.Core;
using System;
using System.Collections.Generic;

namespace Entity
{
    public class DeveloperEntity:BaseEntity
    {
        public string Name { get; set; }
        public IList<ProjectEntity> Projects { get; set; }
        public Guid PositionId { get; set; }
        public PositionEntity Position { get; set; }
    }
}
