using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model.Models
{
    [Table("Inventory")]
    public partial class Inventory
    {
        [Key]
        [Column("id_inventory")]
        public int IdInventory { get; set; }
        [Column("quantity")]
        public double Quantity { get; set; }
        [Column("date_entry", TypeName = "datetime")]
        public DateTime DateEntry { get; set; }
        [Column("date_expiration", TypeName = "datetime")]
        public DateTime? DateExpiration { get; set; }
        [Column("active")]
        public bool? Active { get; set; }
        [Column("id_product")]
        public int IdProduct { get; set; }

        [ForeignKey("IdProduct")]
        [InverseProperty("Inventories")]
        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}
