﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable

namespace OlxDataAccess.Models
{
    [Table("Choice")]
    public partial class Choice
    {
        [Key]
        public int Id { get; set; }
        public int Field_Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Label { get; set; }
        [Required]
        [StringLength(50)]
        public string Label_Ar { get; set; }
        [StringLength(50)]
        public string Slug { get; set; }
        public string Icon { get; set; }

        [ForeignKey("Field_Id")]
        [InverseProperty("Choices")]
        public virtual Field Field { get; set; }
    }
}