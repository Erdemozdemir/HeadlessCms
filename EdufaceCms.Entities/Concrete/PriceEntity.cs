using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    [Table("Price")]
    public class PriceEntity : EntityBase
    {
        [Required(ErrorMessage ="Boş Geçilemez"),Display(Name ="Fiyat") ,StringLength(50, ErrorMessage = "Maksimum 50 karakter girebilirsiniz.")]
        public string Name { get; set; }
    }
}
