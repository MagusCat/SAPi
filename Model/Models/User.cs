using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Logs = new HashSet<Log>();
            Records = new HashSet<Record>();
        }

        [Key]
        [Column("id_user")]
        public int IdUser { get; set; }
        [Column("id_role")]
        public int IdRole { get; set; }
        [Column("name")]
        [StringLength(80)]
        public string Name { get; set; } = null!;
        [Column("username")]
        [StringLength(40)]
        public string Username { get; set; } = null!;
        [Column("password")]
        [StringLength(80)]
        public string Password { get; set; } = null!;
        [Column("active")]
        public bool? Active { get; set; }
        [Column("token")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Token { get; set; }

        [ForeignKey("IdRole")]
        [InverseProperty("Users")]
        public virtual Role IdRoleNavigation { get; set; } = null!;
        [InverseProperty("IdUserNavigation")]
        public virtual ICollection<Log> Logs { get; set; }
        [InverseProperty("IdUserNavigation")]
        public virtual ICollection<Record> Records { get; set; }
    }
}
