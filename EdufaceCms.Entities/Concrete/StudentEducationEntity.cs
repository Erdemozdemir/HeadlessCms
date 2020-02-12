using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    [Table("StudentEducation")]
    public class StudentEducationEntity : EntityBase
    {
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Toplam Saat")]
        public int TotalHour { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Liste Fiyatı")]
        public decimal ListPrice { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Kayıt Fiyatı")]
        public decimal SavePrice { get; set; }


        [Required, ForeignKey("Student")]
        public int StudentId { get; set; }
        [Required, ForeignKey("Education")]
        public int EducationId { get; set; }
        [Required, ForeignKey("Level")]
        public int LevelId { get; set; }
        [Required, ForeignKey("Time")]
        public int TimeId { get; set; }

        public virtual StudentEntity Student{ get; set; }
        public virtual EducationEntity Education{ get; set; }
        public virtual LevelEntity Level{ get; set; }
        public virtual TimeEntity Time{ get; set; }
    }
}
