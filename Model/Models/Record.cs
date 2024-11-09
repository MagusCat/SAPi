using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model.Models
{
    [Table("Record")]
    public partial class Record
    {
        [Key]
        [Column("id_record")]
        public int IdRecord { get; set; }
        [Column("quantity")]
        public double Quantity { get; set; }
        [Column("date", TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column("entry")]
        public bool Entry { get; set; }
        [Column("id_user")]
        public int IdUser { get; set; }
        [Column("id_product")]
        public int IdProduct { get; set; }
        [Column("id_unit")]
        public int IdUnit { get; set; }

        [ForeignKey("IdProduct")]
        [InverseProperty("Records")]
        public virtual Product IdProductNavigation { get; set; } = null!;
        [ForeignKey("IdUnit")]
        [InverseProperty("Records")]
        public virtual Unit IdUnitNavigation { get; set; } = null!;
        [ForeignKey("IdUser")]
        [InverseProperty("Records")]
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
