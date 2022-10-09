using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models
{
    public partial class noteddbContext : DbContext
    {
        public noteddbContext()
        {
        }

        public noteddbContext(DbContextOptions<noteddbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<Notebook> Notebooks { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.NoteId)
                    .HasColumnName("noteID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModified)
                    .HasColumnName("dateModified")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkNotebookId).HasColumnName("fk_notebookID");

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .HasColumnName("title");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.FkNotebook)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.FkNotebookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notes__fk_notebo__73BA3083");
            });

            modelBuilder.Entity<Notebook>(entity =>
            {
                entity.Property(e => e.NotebookId)
                    .HasColumnName("notebookID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModified)
                    .HasColumnName("dateModified")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkUserId)
                    .HasMaxLength(200)
                    .HasColumnName("fk_userID");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.NoteCount)
                    .HasColumnName("noteCount")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Notebooks)
                    .HasForeignKey(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notebooks__fk_us__6C190EBB");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasIndex(e => e.FkUserId, "UQ__Profiles__B88E679FEFEF8C30")
                    .IsUnique();

                entity.Property(e => e.ProfileId)
                    .HasColumnName("profileID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email)
                    .HasMaxLength(64)
                    .HasColumnName("email");

                entity.Property(e => e.FkUserId)
                    .HasMaxLength(200)
                    .HasColumnName("fk_userID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(100)
                    .HasColumnName("nickname");

                entity.Property(e => e.Picture)
                    .HasMaxLength(400)
                    .HasColumnName("picture");

                entity.HasOne(d => d.FkUser)
                    .WithOne(p => p.Profile)
                    .HasForeignKey<Profile>(d => d.FkUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Profiles__fk_use__68487DD7");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasMaxLength(200)
                    .HasColumnName("userID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("dateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModified)
                    .HasColumnName("dateModified")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
