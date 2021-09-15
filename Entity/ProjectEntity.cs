using Entity.Core;
using System;
using System.Collections.Generic;

namespace Entity
{
    public class ProjectEntity:BaseEntity
    {
        public string Name { get; set; }
        public Guid ClientId { get; set; }
        public ClientEntity Client { get; set; }
        public IList<DeveloperEntity> Developers { get; set; }
    }
}
