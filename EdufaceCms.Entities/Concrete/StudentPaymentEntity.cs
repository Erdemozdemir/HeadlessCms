using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    [Table("StudentPayment")]
    public class StudentPaymentEntity : EntityBase
    {
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Peşinat Ödeme Tarihi")]
        public DateTime AdvancePaymentDate { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "İlk Ödeme Tarihi")]
        public DateTime FirstPaymentDate{ get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Taksit Sayısı")]
        public decimal InstallementCount { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez"), Display(Name = "Peşinat Ödeme Tutarı")]
        public decimal AdvancePaymentPrice { get; set; }


        [Required, ForeignKey("Student")]
        public int StudentId { get; set; }
        [Required,ForeignKey("PaymentType")]
        public int PaymentTypeId { get; set; }

        public virtual StudentEntity Student { get; set; }
        public virtual PaymentTypeEntity PaymentType{ get; set; }
    }
}
