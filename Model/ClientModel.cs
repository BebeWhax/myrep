using Model.Core;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class ClientModel:BaseModel
    {
        [Display(Name="ПІБ")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
    }
}
