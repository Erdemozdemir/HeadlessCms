using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    [Table("City")]
    public class CityEntity:EntityBase
    {
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Plaka")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Ad")]
        public string Name { get; set; }
    }
}
