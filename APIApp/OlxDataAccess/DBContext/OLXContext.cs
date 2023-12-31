﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable


namespace OlxDataAccess.DBContext;

using Microsoft.EntityFrameworkCore;
using OlxDataAccess.Models;

public partial class OLXContext : DbContext
{
    public OLXContext()
    {
    }

    public OLXContext(DbContextOptions<OLXContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Chat> Chats { get; set; }
    public virtual DbSet<Chat_Message> Chat_Messages { get; set; }
    public virtual DbSet<Choice> Choices { get; set; }
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<Favorite> Favorites { get; set; }
    public virtual DbSet<Field> Fields { get; set; }
    public virtual DbSet<Field_Role> Field_Roles { get; set; }
    public virtual DbSet<Governorate> Governorates { get; set; }
    public virtual DbSet<Permission> Permissions { get; set; }
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Post_Image> Post_Images { get; set; }
    public virtual DbSet<Setting> Settings { get; set; }
    public virtual DbSet<User> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=OLX;Integrated Security=True");
//            }
//        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasMany(d => d.Permissions)
                .WithMany(p => p.Admins)
                .UsingEntity<Dictionary<string, object>>(
                    "Admin_Permission",
                    l => l.HasOne<Permission>().WithMany().HasForeignKey("Permission").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_admin_permission_permission"),
                    r => r.HasOne<Admin>().WithMany().HasForeignKey("Admin").HasConstraintName("FK_admin_permission_admin"),
                    j =>
                    {
                        j.HasKey("Admin", "Permission").HasName("PK_admin_permission");

                        j.ToTable("Admin_Permission");
                    });
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasOne(d => d.Admin)
                .WithMany(p => p.Categories)
                .HasForeignKey(d => d.Admin_Id)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_category_admin");

            entity.HasOne(d => d.Parent)
                .WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.Parent_Id)
                .HasConstraintName("FK_category_category");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasOne(d => d.User_OneNavigation)
                .WithMany(p => p.ChatUser_OneNavigations)
                .HasForeignKey(d => d.User_One)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_chat_user2");

            entity.HasOne(d => d.User_TwoNavigation)
                .WithMany(p => p.ChatUser_TwoNavigations)
                .HasForeignKey(d => d.User_Two)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_chat_user3");
        });

        modelBuilder.Entity<Chat_Message>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Chat)
                .WithMany(p => p.Chat_Messages)
                .HasForeignKey(d => d.Chat_Id)
                .HasConstraintName("FK_chat_message_chat");

            entity.HasOne(d => d.Sender)
                .WithMany(p => p.Chat_Messages)
                .HasForeignKey(d => d.Sender_Id)
                .HasConstraintName("FK_chat_message_user");
        });

        modelBuilder.Entity<Choice>(entity =>
        {
            entity.HasOne(d => d.Field)
                .WithMany(p => p.Choices)
                .HasForeignKey(d => d.Field_Id)
                .HasConstraintName("FK_choice_field");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasOne(d => d.Governorate)
                .WithMany(p => p.Cities)
                .HasForeignKey(d => d.Governorate_Id)
                .HasConstraintName("FK_cities_governorates");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasOne(d => d.OwnerNavigation)
                .WithMany(p => p.Companies)
                .HasForeignKey(d => d.OwnerID)
                .HasConstraintName("FK_company_user");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasOne(d => d.Post)
                .WithMany(p => p.Favorites)
                .HasForeignKey(d => d.Post_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_favorite_post");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Favorites)
                .HasForeignKey(d => d.User_Id)
                .HasConstraintName("FK_favorite_user");
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasOne(d => d.Cat)
                .WithMany(p => p.Fields)
                .HasForeignKey(d => d.Cat_Id)
                .HasConstraintName("FK_field_category");

            entity.HasOne(d => d.Parent)
                .WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.Parent_Id)
                .HasConstraintName("FK_field_field");
        });

        modelBuilder.Entity<Field_Role>(entity =>
        {
            entity.HasOne(d => d.Field)
                .WithMany()
                .HasForeignKey(d => d.Field_Id)
                .HasConstraintName("FK_fieldRole_field");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.Property(e => e.Created_Date).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Is_Visible).HasDefaultValueSql("((1))");

            entity.Property(e => e.Post_Location).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Cat)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.Cat_Id)
                .HasConstraintName("FK_post_category");

            entity.HasOne(d => d.Post_LocationNavigation)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.Post_Location)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_post_cities");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.User_Id)
                .HasConstraintName("FK_post_user");
        });

        modelBuilder.Entity<Post_Image>(entity =>
        {
            entity.HasOne(d => d.Post)
                .WithMany(p => p.Post_Images)
                .HasForeignKey(d => d.Post_Id)
                .HasConstraintName("FK_postImage_post");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}