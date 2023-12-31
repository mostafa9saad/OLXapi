﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable

namespace OlxDataAccess.Models
{
    public partial class City
    {
        public City()
        {
            Posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }
        public int Governorate_Id { get; set; }
        [Required]
        [StringLength(200)]
        public string City_Name_Ar { get; set; }
        [Required]
        [StringLength(200)]
        public string City_Name_En { get; set; }

        [ForeignKey("Governorate_Id")]
        [InverseProperty("Cities")]
        public virtual Governorate Governorate { get; set; }
        [InverseProperty("Post_LocationNavigation")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}