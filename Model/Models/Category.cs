using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model.Models
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("id_category")]
        public int IdCategory { get; set; }
        [Column("name")]
        [StringLength(45)]
        public string Name { get; set; } = null!;

        [InverseProperty("IdCategoryNavigation")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
