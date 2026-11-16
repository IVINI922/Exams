using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WebApiApp.Models;

public partial class Winter14112026Context : DbContext
{
    public Winter14112026Context()
    {
    }

    public Winter14112026Context(DbContextOptions<Winter14112026Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SeasonTicket> SeasonTickets { get; set; }

    public virtual DbSet<SeasonTicketsType> SeasonTicketsTypes { get; set; }

    public virtual DbSet<Training> Trainings { get; set; }

    public virtual DbSet<TrainingList> TrainingLists { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__Default")
                ?? "server=localhost;user=root;password=1234;database=winter14_11_2026;SslMode=None;AllowPublicKeyRetrieval=True";
    
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 4, 0)));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.HasIndex(e => e.SeasonTicket, "clients_season_tickets_FK");

            entity.HasIndex(e => e.UserId, "clients_users_FK");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.SeasonTicket).HasColumnName("season_ticket");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.SeasonTicketNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.SeasonTicket)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clients_season_tickets_FK");

            entity.HasOne(d => d.User).WithMany(p => p.Clients)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("clients_users_FK");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Role1)
                .HasMaxLength(20)
                .HasColumnName("role");
        });

        modelBuilder.Entity<SeasonTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("season_tickets");

            entity.HasIndex(e => e.Type, "season_tickets_season_tickets_types_FK");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.SeasonTickets)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("season_tickets_season_tickets_types_FK");
        });

        modelBuilder.Entity<SeasonTicketsType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("season_tickets_types");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("trainings");

            entity.HasIndex(e => e.Trainer, "trainings_users_FK");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Hall).HasColumnName("hall");
            entity.Property(e => e.IsVisited).HasColumnName("is_visited");
            entity.Property(e => e.Time)
                .HasColumnType("time")
                .HasColumnName("time");
            entity.Property(e => e.Trainer).HasColumnName("trainer");

            entity.HasOne(d => d.TrainerNavigation).WithMany(p => p.Training)
                .HasForeignKey(d => d.Trainer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trainings_users_FK");
        });

        modelBuilder.Entity<TrainingList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("training_lists");

            entity.HasIndex(e => e.Client, "training_lists_clients_FK");

            entity.HasIndex(e => e.Training, "training_lists_trainings_FK");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Client).HasColumnName("client");
            entity.Property(e => e.Training).HasColumnName("training");

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.TrainingLists)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("training_lists_clients_FK");

            entity.HasOne(d => d.TrainingNavigation).WithMany(p => p.TrainingLists)
                .HasForeignKey(d => d.Training)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("training_lists_trainings_FK");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Role, "users_roles_FK");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(25)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .HasColumnName("phone");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Surname)
                .HasMaxLength(20)
                .HasColumnName("surname");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_roles_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
