using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Bd_3._4
{
    public partial class hotelsContext : DbContext
    {
        public hotelsContext()
        {
        }

        public hotelsContext(DbContextOptions<hotelsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomCategory> RoomCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data source = C:/SQLite/Hotels.db; Foreign Keys = True" );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(e => e.HotelId);

                entity.HasComment("Информация о филиалах");

                entity.Property(e => e.HotelId).HasComment("Идентификатор отеля");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Адресс филиала");

                entity.Property(e => e.DirectorId).HasComment("Директор подразделения");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Название отеля");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Телефонный номер отеля");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("FK_Branches_Staff");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasComment("Персонал организации");

                entity.Property(e => e.EmployeeId).HasComment("Идентификатор сотрудника");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Имя сотрудника");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Телефонный номер сотрудника");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_Staff_Branches");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Staff_Position");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Arrival).HasColumnType("date");

                entity.Property(e => e.DateOfBooking).HasColumnType("date");

                entity.Property(e => e.Departure).HasColumnType("date");

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Client");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Order_RoomCondition");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).ValueGeneratedNever();

                entity.Property(e => e.Position1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Position");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).ValueGeneratedNever();

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_RoomCondition_Branches");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_RoomCondition_RoomCategories");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_RoomCondition_Staff");
            });

            modelBuilder.Entity<RoomCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PriceForDay).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
