using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    [Table("PreRegister")]
    public class PreRegisterEntity:EntityBase
    {
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Soyad")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Görüşmeyi Yapan Kişi")]
        public string InterviewPerson { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Görüşme Tarihi"),DataType(DataType.Date)]
        public string InterviewDate { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Cep Telefonu"), StringLength(15, ErrorMessage = "Maksimum 15 karakter girmelisiniz"), Phone]
        public string CellPhone { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Email"), EmailAddress(ErrorMessage = "Geçersiz mail adresi")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Randevu Tarihi"), DataType(DataType.Date)]
        public string AppointmentDate { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Verilen Fiyat")]
        public decimal GivenPrice { get; set; }
        /// <summary>
        /// Ön görülen fiyat
        /// </summary>
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Ön Görülen Fiyat")]
        public decimal EstimatedPrice { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Not (500 karakter)"), StringLength(500,ErrorMessage ="En fazla 500 karakter girebilirsiniz.")]
        public string Not { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display( Name = "Kayıt Oldu Mu ?")]
        public bool IsRegister { get; set; }



        [Required, ForeignKey("DataQuality")]
        public int DataQualityId { get; set; }
        [Required, ForeignKey("DataSource")]
        public int DataSourceId { get; set; }
        [Required, ForeignKey("Level")]
        public int LevelId { get; set; }
        [Required, ForeignKey("Time")]
        public int TimeId { get; set; }
        [Required, ForeignKey("PaymentType")]
        public int PaymentTypeId { get; set; }


        public virtual DataQualityEntity DataQuality { get; set; }
        public virtual DataSourceEntity DataSource { get; set; }
        public virtual LevelEntity Level{ get; set; }
        public virtual TimeEntity Time{ get; set; }
        public virtual PaymentTypeEntity PaymentType { get; set; }

    }
}
