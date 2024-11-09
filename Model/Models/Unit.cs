using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model.Models
{
    [Table("Unit")]
    public partial class Unit
    {
        public Unit()
        {
            ConversionIdBaseNavigations = new HashSet<Conversion>();
            ConversionIdFactorNavigations = new HashSet<Conversion>();
            Products = new HashSet<Product>();
            Records = new HashSet<Record>();
        }

        [Key]
        [Column("id_unit")]
        public int IdUnit { get; set; }
        [Column("name")]
        [StringLength(45)]
        public string Name { get; set; } = null!;
        [Column("abbreviation")]
        [StringLength(10)]
        public string? Abbreviation { get; set; }

        [InverseProperty("IdBaseNavigation")]
        public virtual ICollection<Conversion> ConversionIdBaseNavigations { get; set; }
        [InverseProperty("IdFactorNavigation")]
        public virtual ICollection<Conversion> ConversionIdFactorNavigations { get; set; }
        [InverseProperty("IdUnitNavigation")]
        public virtual ICollection<Product> Products { get; set; }
        [InverseProperty("IdUnitNavigation")]
        public virtual ICollection<Record> Records { get; set; }
    }
}
