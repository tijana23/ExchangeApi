using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExchangeWebApi.Data
{
    public partial class ExchangeOfficeContext : DbContext
    {
        public ExchangeOfficeContext()
        {
        }

        public ExchangeOfficeContext(DbContextOptions<ExchangeOfficeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<ClsCurrency> ClsCurrency { get; set; }
        public virtual DbSet<ClsOperationType> ClsOperationType { get; set; }
        public virtual DbSet<ExchangeRates> ExchangeRates { get; set; }
        public virtual DbSet<Loan> Loan { get; set; }
        public virtual DbSet<OfficialRates> OfficialRates { get; set; }
        public virtual DbSet<Operations> Operations { get; set; }
        public virtual DbSet<Tdainfo> Tdainfo { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-A2PCMDA;Database=ExchangeOffice;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClsCurrency>(entity =>
            {
                entity.HasKey(e => e.CurrencyId)
                    .HasName("PK__CLS_Curr__14470AF0830C0302");

                entity.ToTable("CLS_Currency");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClsOperationType>(entity =>
            {
                entity.HasKey(e => e.OperationTypeId)
                    .HasName("PK__CLS_Oper__FF7FE5138AA9FE90");

                entity.ToTable("CLS_OperationType");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExchangeRates>(entity =>
            {
                entity.Property(e => e.ValidityDate).HasColumnType("date");

                entity.HasOne(d => d.CurrencyFromNavigation)
                    .WithMany(p => p.ExchangeRatesCurrencyFromNavigation)
                    .HasForeignKey(d => d.CurrencyFrom)
                    .HasConstraintName("FK__ExchangeR__Curre__0A9D95DB");

                entity.HasOne(d => d.CurrencyToNavigation)
                    .WithMany(p => p.ExchangeRatesCurrencyToNavigation)
                    .HasForeignKey(d => d.CurrencyTo)
                    .HasConstraintName("FK__ExchangeR__Curre__0B91BA14");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(e => e.LoanInfoId)
                    .HasName("PK__Loan__C3686199FE8CDB5C");
            });

            modelBuilder.Entity<OfficialRates>(entity =>
            {
                entity.Property(e => e.ValidityDate).HasColumnType("date");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.OfficialRates)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK__OfficialR__Curre__0E6E26BF");
            });

            modelBuilder.Entity<Operations>(entity =>
            {
                entity.HasKey(e => e.OperationId)
                    .HasName("PK__Operatio__A4F5FC443EEC5800");

                entity.Property(e => e.OperationDate).HasColumnType("date");

                entity.HasOne(d => d.CurrencyFromNavigation)
                    .WithMany(p => p.OperationsCurrencyFromNavigation)
                    .HasForeignKey(d => d.CurrencyFrom)
                    .HasConstraintName("FK__Operation__Curre__18EBB532");

                entity.HasOne(d => d.CurrencyToNavigation)
                    .WithMany(p => p.OperationsCurrencyToNavigation)
                    .HasForeignKey(d => d.CurrencyTo)
                    .HasConstraintName("FK__Operation__Curre__19DFD96B");

                entity.HasOne(d => d.OperationType)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.OperationTypeId)
                    .HasConstraintName("FK__Operation__Opera__17F790F9");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Operation__UserI__17036CC0");
            });

            modelBuilder.Entity<Tdainfo>(entity =>
            {
                entity.ToTable("TDAinfo");

                entity.Property(e => e.TdainfoId).HasColumnName("TDAinfoId");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
