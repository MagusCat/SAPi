using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model.Models
{
    [Table("Conversion")]
    public partial class Conversion
    {
        [Key]
        [Column("id_conversion")]
        public int IdConversion { get; set; }
        [Column("id_base")]
        public int IdBase { get; set; }
        [Column("id_factor")]
        public int IdFactor { get; set; }
        [Column("factor")]
        public double? Factor { get; set; }

        [ForeignKey("IdBase")]
        [InverseProperty("ConversionIdBaseNavigations")]
        public virtual Unit IdBaseNavigation { get; set; } = null!;
        [ForeignKey("IdFactor")]
        [InverseProperty("ConversionIdFactorNavigations")]
        public virtual Unit IdFactorNavigation { get; set; } = null!;
    }
}
