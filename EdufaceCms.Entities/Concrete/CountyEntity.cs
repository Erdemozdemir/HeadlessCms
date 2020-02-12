using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    [Table("County")]
    public class CountyEntity:EntityBase
    {
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Ad")]
        public string Name { get; set; }
        public virtual CityEntity City { get; set; }
    }
}
