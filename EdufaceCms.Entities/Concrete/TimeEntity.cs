using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    [Table("Time")]
    public class TimeEntity : EntityBase
    {
        [Required(ErrorMessage ="Boş Geçilemez"),Display(Name ="Zaman") ,StringLength(50, ErrorMessage = "Maksimum 50 karakter girebilirsiniz.")]
        public string Name { get; set; }
    }
}
