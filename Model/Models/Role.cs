using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model.Models
{
    [Table("Role")]
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [Column("id_role")]
        public int IdRole { get; set; }
        [Column("name")]
        [StringLength(45)]
        public string Name { get; set; } = null!;

        [InverseProperty("IdRoleNavigation")]
        public virtual ICollection<User> Users { get; set; }
    }
}
