using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    [Table("PaymentType")]
    public class PaymentTypeEntity : EntityBase
    {
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Ödeme Tipi")]
        public string Name { get; set; }
    }
}
