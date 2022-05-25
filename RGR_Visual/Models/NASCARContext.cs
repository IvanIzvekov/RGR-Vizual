using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RGR_Visual
{
    public partial class NASCARContext : DbContext
    {
        public NASCARContext()
        {
        }

        public NASCARContext(DbContextOptions<NASCARContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Race> Races { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<Tournament> Tournaments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\Иван Извеков\\source\\repos\\RGR_Visual\\RGR_Visual\\bin\\Debug\\net6.0\\NASCAR.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Born).HasColumnName("born");

                entity.Property(e => e.Home).HasColumnName("home");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Cars).HasColumnName("cars");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.IdTournament).HasColumnName("id_tournament");

                entity.Property(e => e.Laps).HasColumnName("laps");

                entity.Property(e => e.Len).HasColumnName("len");

                entity.Property(e => e.Trace).HasColumnName("trace");

                entity.HasOne(d => d.TournamentNavigation)
                    .WithMany(p => p.Races)
                    .HasForeignKey(d => d.IdTournament)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FinishPos).HasColumnName("finish_pos");

                entity.Property(e => e.IdDriver).HasColumnName("id_driver");

                entity.Property(e => e.IdOwner).HasColumnName("id_owner");

                entity.Property(e => e.IdRace).HasColumnName("id_race");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.StartPos).HasColumnName("start_pos");

                entity.HasOne(d => d.IdDriverNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.IdDriver)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.IdOwner)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.IdRaceNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.IdRace)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("Tournament");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
