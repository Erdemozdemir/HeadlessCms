using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    [Table("Branch")]
    public class BranchEntity:EntityBase
    {
        [Required(ErrorMessage ="Boş Geçilemez"),Display(Name ="Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Boş Geçilemez"),Display(Name ="Telefon"),Phone]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Adres")]
        public string Address { get; set; }
    }
}
