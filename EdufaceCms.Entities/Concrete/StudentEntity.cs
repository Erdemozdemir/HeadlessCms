using EdufaceCms.WebApplication.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    [Table("Student")]
    public class StudentEntity:EntityBase
    {
        [Required(ErrorMessage = "Boş Geçilemez"),MinLength(11,ErrorMessage ="En az 11 karakter girmelisiniz"),MaxLength(11, ErrorMessage = "Maksimum 11 karakter girmelisiniz"), Display(Name = "TC"),TCValidator(ErrorMessage ="Geçersiz TC NO")]
        public string TC { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Soyad")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Cinsiyet")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Adres")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Cep Telefonu"), StringLength(15, ErrorMessage = "Maksimum 15 karakter girmelisiniz"), Phone]
        public string CellPhone { get; set; }
        [Display(Name = "Sabit Telefon"), StringLength(15, ErrorMessage = "Maksimum 15 karakter girmelisiniz"), Phone]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Boş Geçilemez"),Display(Name ="Email"), EmailAddress(ErrorMessage ="Geçersiz mail adresi")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Acil D. Aranıcak Kişi")]
        public string EmergencyPerson { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Yakınlık Derecesi")]
        public string Proximity { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Semt")]
        public string Neighborhood { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Referans")]
        public string Reference { get; set; }

        [Required, ForeignKey("City")]
        public int CityId { get; set; }
        [Required, ForeignKey("County")]
        public int CountyId { get; set; }
        [Required,ForeignKey("Branch")]
        public int BranchId { get; set; }

        public virtual CityEntity City { get; set; }
        public virtual CountyEntity County { get; set; }
        public virtual BranchEntity Branch{ get; set; }

    }
}
