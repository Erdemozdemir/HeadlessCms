using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    [Table("DataSource")]
    public class DataSourceEntity : EntityBase
    {
        [Required(ErrorMessage ="Boş Geçilemez"),Display(Name ="Ad"),StringLength(50,ErrorMessage ="Maksimum 50 karakter girebilirsiniz.")]
        public string Name { get; set; }
    }
}
