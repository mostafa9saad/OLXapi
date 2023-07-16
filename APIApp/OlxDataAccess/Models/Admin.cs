﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable

namespace OlxDataAccess.Models
{
    [Table("Admin")]
    public partial class Admin
    {
        public Admin()
        {
            Categories = new HashSet<Category>();
            Permissions = new HashSet<Permission>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(200)]
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public bool? Gender { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Birth_Date { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Added_Date { get; set; }

        [InverseProperty("Admin")]
        public virtual ICollection<Category> Categories { get; set; }

        [ForeignKey("Admin")]
        [InverseProperty("Admins")]
        public virtual ICollection<Permission> Permissions { get; set; } //= new List<Permission>();
    }
}