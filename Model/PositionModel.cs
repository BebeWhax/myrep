using Model.Core;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class PositionModel:BaseModel
    {
        [Display(Name = "Посада")]
        [StringLength(25)]
        [Required]
        public string Name { get; set; }
    }
}