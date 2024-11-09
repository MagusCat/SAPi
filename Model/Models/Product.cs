using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            Records = new HashSet<Record>();
        }

        [Key]
        [Column("id_product")]
        public int IdProduct { get; set; }
        [Column("name")]
        [StringLength(80)]
        public string Name { get; set; } = null!;
        [Column("price", TypeName = "money")]
        public decimal Price { get; set; }
        [Column("active")]
        public bool? Active { get; set; }
        [Column("id_category")]
        public int IdCategory { get; set; }
        [Column("id_unit")]
        public int IdUnit { get; set; }
        [Column("id_brand")]
        public int IdBrand { get; set; }

        [ForeignKey("IdBrand")]
        [InverseProperty("Products")]
        public virtual Brand IdBrandNavigation { get; set; } = null!;
        [ForeignKey("IdCategory")]
        [InverseProperty("Products")]
        public virtual Category IdCategoryNavigation { get; set; } = null!;
        [ForeignKey("IdUnit")]
        [InverseProperty("Products")]
        public virtual Unit IdUnitNavigation { get; set; } = null!;
        [InverseProperty("IdProductNavigation")]
        public virtual ICollection<Inventory> Inventories { get; set; }
        [InverseProperty("IdProductNavigation")]
        public virtual ICollection<Record> Records { get; set; }
    }
}
