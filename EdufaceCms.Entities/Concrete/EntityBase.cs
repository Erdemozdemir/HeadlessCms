using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    public class EntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),Display(Order =0)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Boş Geçilemez"),Display(Order = 20,Name ="Aktif Mi")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage ="Boş Geçilemez"),Display(Order = 21,Name ="Oluşturulma Tarihi")]
        public DateTime CreDate { get; set; }
        [Required(ErrorMessage ="Boş Geçilemez"), Display(Order = 22)]
        public DateTime ModDate { get; set; }
        [StringLength(30), Display(Order = 24)]
        public string ModUser { get; set; }
        [Display(Order = 21, Name = "Oluşturan Kullanıcı")]
        public virtual UserEntity CreUser { get; set; }
    }
}
