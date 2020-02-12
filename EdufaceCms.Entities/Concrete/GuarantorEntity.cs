using EdufaceCms.WebApplication.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    [Table("Guarantor")]
    public class GuarantorEntity:EntityBase
    {
        [Required(ErrorMessage = "Boş Geçilemez"), MinLength(11, ErrorMessage = "En az 11 karakter girmelisiniz"), MaxLength(11, ErrorMessage = "Maksimum 11 karakter girmelisiniz"), Display(Name = "TC"), TCValidator(ErrorMessage = "Geçersiz TC NO")]
        public string TC { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Soyad")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Adres")]
        public string Address { get; set; }
        [Required(ErrorMessage ="Boş Geçilemez"),Display(Name ="Cep Telefonu") ,StringLength(15, ErrorMessage = "Maksimum 15 karakter girmelisiniz"), Phone]
        public string CellPhone { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Yakınlık Derecesi")]
        public string Proximity { get; set; }


        [Required, ForeignKey("Student")]
        public int StudentId { get; set; }
        [Required, ForeignKey("City")]
        public int CityId { get; set; }
        [Required, ForeignKey("County")]
        public int CountyId { get; set; }

        public virtual StudentEntity Student { get; set; }
        public virtual CityEntity City { get; set; }
        public virtual CountyEntity County { get; set; }
    }
}
