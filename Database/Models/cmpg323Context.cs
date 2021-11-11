using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Database.Models
{
    public partial class Cmpg323Context : DbContext
    {
        private readonly string _conStr;

        public Cmpg323Context(string connectionString)
        {
            _conStr = connectionString;
        }

        public Cmpg323Context(DbContextOptions<Cmpg323Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Directory> Directories { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<LogCategory> LogCategories { get; set; }
        public virtual DbSet<Shared> Shareds { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(_conStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.Idalbums)
                    .HasName("PRIMARY");

                entity.ToTable("albums");

                entity.Property(e => e.Idalbums)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idalbums");

                entity.Property(e => e.Caption)
                    .HasMaxLength(500)
                    .HasColumnName("caption");

                entity.Property(e => e.DateCreated).HasColumnName("date_created");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.User)
                    .HasColumnType("int unsigned")
                    .HasColumnName("user");
            });

            modelBuilder.Entity<Directory>(entity =>
            {
                entity.HasKey(e => e.Iddirectories)
                    .HasName("PRIMARY");

                entity.ToTable("directories");

                entity.HasIndex(e => e.Parent, "FK_directories_parent_directories_idx");

                entity.Property(e => e.Iddirectories)
                    .HasColumnType("int unsigned")
                    .HasColumnName("iddirectories");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Parent)
                    .HasColumnType("int unsigned")
                    .HasColumnName("parent");

                entity.HasOne(d => d.ParentNavigation)
                    .WithMany(p => p.InverseParentNavigation)
                    .HasForeignKey(d => d.Parent)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_directories_parent_directories");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.Idfiles)
                    .HasName("PRIMARY");

                entity.ToTable("files");

                entity.HasIndex(e => e.Directory, "FK_files_directory_directories_idx");

                entity.HasIndex(e => e.User, "FK_files_user_users_idx");

                entity.Property(e => e.Idfiles)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idfiles");

                entity.Property(e => e.DateUploaded).HasColumnName("date_uploaded");

                entity.Property(e => e.Directory)
                    .HasColumnType("int unsigned")
                    .HasColumnName("directory");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.User)
                    .HasColumnType("int unsigned")
                    .HasColumnName("user");

                entity.HasOne(d => d.DirectoryNavigation)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.Directory)
                    .HasConstraintName("FK_files_directory_directories");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_files_user_users");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.Idimages)
                    .HasName("PRIMARY");

                entity.ToTable("images");

                entity.HasIndex(e => e.File, "FK_images_file_files_idx");

                entity.HasIndex(e => e.User, "FK_images_user_users_idx");

                entity.Property(e => e.Idimages)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idimages");

                entity.Property(e => e.Caption)
                    .HasMaxLength(500)
                    .HasColumnName("caption");

                entity.Property(e => e.DateCreated).HasColumnName("date_created");

                entity.Property(e => e.File)
                    .HasColumnType("int unsigned")
                    .HasColumnName("file");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .HasColumnName("location");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.User)
                    .HasColumnType("int unsigned")
                    .HasColumnName("user");

                entity.HasOne(d => d.FileNavigation)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.File)
                    .HasConstraintName("FK_images_file_files");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("FK_images_user_users");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.Idlog)
                    .HasName("PRIMARY");

                entity.ToTable("log");

                entity.HasIndex(e => e.Category, "FK_log_category_log_categories_idx");

                entity.Property(e => e.Idlog)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idlog");

                entity.Property(e => e.Category)
                    .HasColumnType("int unsigned")
                    .HasColumnName("category");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .HasColumnName("description");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_log_category_log_categories");
            });

            modelBuilder.Entity<LogCategory>(entity =>
            {
                entity.HasKey(e => e.IdlogCategories)
                    .HasName("PRIMARY");

                entity.ToTable("log_categories");

                entity.HasIndex(e => e.Parent, "FK_log_catgories_parent_log_categories_idx");

                entity.Property(e => e.IdlogCategories)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idlog_categories");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Parent)
                    .HasColumnType("int unsigned")
                    .HasColumnName("parent");

                entity.HasOne(d => d.ParentNavigation)
                    .WithMany(p => p.InverseParentNavigation)
                    .HasForeignKey(d => d.Parent)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_log_catgories_parent_log_categories");
            });

            modelBuilder.Entity<Shared>(entity =>
            {
                entity.HasKey(e => e.IdaccessControl)
                    .HasName("PRIMARY");

                entity.ToTable("shared");

                entity.HasIndex(e => e.Image, "FK_access_control_image_images_idx");

                entity.HasIndex(e => e.User, "FK_access_control_user_users_idx");

                entity.HasIndex(e => e.Album, "FK_shared_album_albums_idx");

                entity.Property(e => e.IdaccessControl)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idaccess_control");

                entity.Property(e => e.Album)
                    .HasColumnType("int unsigned")
                    .HasColumnName("album");

                entity.Property(e => e.Image)
                    .HasColumnType("int unsigned")
                    .HasColumnName("image");

                entity.Property(e => e.User)
                    .HasColumnType("int unsigned")
                    .HasColumnName("user");

                entity.HasOne(d => d.AlbumNavigation)
                    .WithMany(p => p.Shared)
                    .HasForeignKey(d => d.Album)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_shared_album_albums");

                entity.HasOne(d => d.ImageNavigation)
                    .WithMany(p => p.Shareds)
                    .HasForeignKey(d => d.Image)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_shared_image_images");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Idusers)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.Idusers)
                    .HasColumnType("int unsigned")
                    .HasColumnName("idusers");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .HasColumnName("password")
                    .IsFixedLength(true);

                entity.Property(e => e.Surname)
                    .HasMaxLength(45)
                    .HasColumnName("surname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
