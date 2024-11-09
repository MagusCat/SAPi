using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model.Models
{
    [Table("Log")]
    public partial class Log
    {
        [Key]
        [Column("id_log")]
        public int IdLog { get; set; }
        [Column("action")]
        [StringLength(100)]
        public string Action { get; set; } = null!;
        [Column("date", TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column("id_user")]
        public int? IdUser { get; set; }

        [ForeignKey("IdUser")]
        [InverseProperty("Logs")]
        public virtual User? IdUserNavigation { get; set; }
    }
}
