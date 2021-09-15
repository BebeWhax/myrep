using Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class ProjectModel:BaseModel
    {
        [Display(Name = "Назва проекта")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name="Клієнт")]
        public Guid ClientId { get; set; }
        [Display(Name = "Клієнт")]
        public ClientModel Client { get; set; }
        [Display(Name="Розробники")]
        public IList<DeveloperModel> Developers { get; set; }
    }
}