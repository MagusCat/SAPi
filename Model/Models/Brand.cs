using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model.Models
{
    [Table("Brand")]
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("id_brand")]
        public int IdBrand { get; set; }
        [Column("name")]
        [StringLength(45)]
        public string Name { get; set; } = null!;

        [InverseProperty("IdBrandNavigation")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
