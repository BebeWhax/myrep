using Domain.Core;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class ProjectDTO:BaseDTO
    {
        public string Name { get; set; }
        public Guid ClientId { get; set; }
        public ClientDTO Client { get; set; }
        public IList<DeveloperDTO> Developers { get; set; }
    }
}
