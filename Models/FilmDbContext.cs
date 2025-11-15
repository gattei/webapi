using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models;

public partial class FilmDbContext : DbContext
{
    public FilmDbContext()
    {
    }

    public FilmDbContext(DbContextOptions<FilmDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Registi> Registis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Film5G;User Id=SA;Password=burbero2025;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasIndex(e => e.IdRegista, "IX_Films_IdRegista");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdRegistaNavigation).WithMany(p => p.Films).HasForeignKey(d => d.IdRegista);
        });

        modelBuilder.Entity<Registi>(entity =>
        {
            entity.ToTable("Registi");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
