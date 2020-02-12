using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    [Table("Education")]
    public class EducationEntity : EntityBase
    {
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Ad")]
        public string Name { get; set; }
    }
}
