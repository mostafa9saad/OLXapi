﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable


namespace OlxDataAccess.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            ChatUser_OneNavigations = new HashSet<Chat>();
            ChatUser_TwoNavigations = new HashSet<Chat>();
            Chat_Messages = new HashSet<Chat_Message>();
            Companies = new HashSet<Company>();
            Favorites = new HashSet<Favorite>();
            Posts = new HashSet<Post>();
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
        [StringLength(50)]
        public string Phone { get; set; }
        public string Bio { get; set; }
        public bool? Gender { get; set; }
        public int? Company { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Birth_Date { get; set; }
        public int? Post_Count { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Register_Date { get; set; }

        [InverseProperty("User_OneNavigation")]
        public virtual ICollection<Chat> ChatUser_OneNavigations { get; set; }
        [InverseProperty("User_TwoNavigation")]
        public virtual ICollection<Chat> ChatUser_TwoNavigations { get; set; }
        [InverseProperty("Sender")]
        public virtual ICollection<Chat_Message> Chat_Messages { get; set; }
        [InverseProperty("OwnerNavigation")]
        public virtual ICollection<Company> Companies { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Favorite> Favorites { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}