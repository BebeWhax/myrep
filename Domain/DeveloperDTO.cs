using Domain.Core;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class DeveloperDTO:BaseDTO
    {
        public string Name { get; set; }
        public IList<ProjectDTO> Projects { get; set; }
        public Guid PositionId { get; set; }
        public PositionDTO Position { get; set; }
    }
}
