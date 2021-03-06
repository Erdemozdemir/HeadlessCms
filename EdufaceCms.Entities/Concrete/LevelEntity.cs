﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufaceCms.Entities.Concrete
{
    [Table("Level")]
    public class LevelEntity : EntityBase
    {
        [Required(ErrorMessage ="Boş Geçilemez"),Display(Name ="Ad"),StringLength(50,ErrorMessage ="Maksimum 50 karakter girebilirsiniz.")]
        public string Name { get; set; }
    }
}
