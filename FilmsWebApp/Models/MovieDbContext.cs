using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FilmsWebApp;

public partial class MovieDbContext : DbContext
{
    public MovieDbContext()
    {
    }

    public MovieDbContext(DbContextOptions<MovieDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<FilmStatusRate> FilmStatusRates { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersCollection> UsersCollections { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1S0FD77; Database=MovieDB; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Books");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Films)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Films_Authors");

            entity.HasOne(d => d.Country).WithMany(p => p.Films)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Films_Countries");

            entity.HasOne(d => d.Genre).WithMany(p => p.Films)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Films_Genres");
        });

        modelBuilder.Entity<FilmStatusRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UsersList");

            entity.ToTable("FilmStatusRate");

            entity.HasOne(d => d.Book).WithMany(p => p.FilmStatusRates)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FilmStatus_Films");

            entity.HasOne(d => d.Status).WithMany(p => p.FilmStatusRates)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FilmStatus_Status");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<UsersCollection>(entity =>
        {
            entity.HasOne(d => d.FilmStatusRate).WithMany(p => p.UsersCollections)
                .HasForeignKey(d => d.FilmStatusRateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsersCollections_FilmStatusRate");

            entity.HasOne(d => d.User).WithMany(p => p.UsersCollections)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsersCollections_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
