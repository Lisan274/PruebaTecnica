using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prueba_Tecnica_CNBS.Models;

public partial class DeclaracionesDbContext : DbContext
{
    public DeclaracionesDbContext()
    {
    }

    public DeclaracionesDbContext(DbContextOptions<DeclaracionesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Art> Arts { get; set; }

    public virtual DbSet<Ddt> Ddts { get; set; }

    public virtual DbSet<Liq> Liqs { get; set; }

    public virtual DbSet<Lqa> Lqas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured)
        {
            // 
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Art>(entity =>
        {
            entity.HasKey(e => new { e.Iddt, e.Nart }).HasName("PK__ART__6047882582AA62CC");

            entity.ToTable("ART");

            entity.Property(e => e.Iddt)
                .HasMaxLength(17)
                .IsUnicode(false);
            entity.Property(e => e.Cartdesc)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Cartetamrc)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cartpayacq)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cartpayori)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cartpayprc)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Carttyp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cartuntdcl)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cartuntest)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Codbenef)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Iddtapu)
                .HasMaxLength(17)
                .IsUnicode(false);
            entity.Property(e => e.Iespnce)
                .HasMaxLength(17)
                .IsUnicode(false);
            entity.Property(e => e.Martajuded).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Martajuinc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Martass).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Martbasimp).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Martemma).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Martfle).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Martfob).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Martfobdol).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Martfrai).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Martunitar).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Qartbul).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Qartkgrbrt).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Qartkgrnet).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Qartuntdcl).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Qartuntest).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IddtNavigation).WithMany(p => p.Arts)
                .HasForeignKey(d => d.Iddt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ART__Iddt__3B75D760");
        });

        modelBuilder.Entity<Ddt>(entity =>
        {
            entity.HasKey(e => e.Iddt).HasName("PK__DDT__B7709CFEFADB642C");

            entity.ToTable("DDT");

            entity.Property(e => e.Iddt)
                .HasMaxLength(17)
                .IsUnicode(false);
            entity.Property(e => e.Cddtage)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Cddtagr)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Cddtbur)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Cddtburdst)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Cddtcirvis)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cddtdep)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Cddtdevass)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cddtdevfle)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cddtdevfob)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cddtentrep)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Cddteta)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Cddtincote)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cddtmdetrn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cddtobs)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Cddtpaidst)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cddtpayori)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cddtpaytrn)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cddttransp)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Dddtbae).HasColumnType("datetime");
            entity.Property(e => e.Dddtcancel).HasColumnType("datetime");
            entity.Property(e => e.Dddtoficia).HasColumnType("datetime");
            entity.Property(e => e.Dddtrectifa).HasColumnType("datetime");
            entity.Property(e => e.Dddtsalida).HasColumnType("datetime");
            entity.Property(e => e.Iddtext)
                .HasMaxLength(17)
                .IsUnicode(false);
            entity.Property(e => e.Iext)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Ista)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Lddtagr)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Lddtnomfod)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Lddtnomioe)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nddtimmioe)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Qddttaxchg).HasColumnType("decimal(12, 6)");
        });

        modelBuilder.Entity<Liq>(entity =>
        {
            entity.HasKey(e => e.Iliq).HasName("PK__LIQ__46B0E5DAB07D3399");

            entity.ToTable("LIQ");

            entity.Property(e => e.Iliq)
                .HasMaxLength(17)
                .IsUnicode(false);
            entity.Property(e => e.Clipnomope)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Cliqdop)
                .HasMaxLength(17)
                .IsUnicode(false);
            entity.Property(e => e.Cliqeta)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Dlippay)
                .HasColumnType("datetime")
                .HasColumnName("dlippay");
            entity.Property(e => e.Mliq).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Mliqgar).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Lqa>(entity =>
        {
            entity.HasKey(e => new { e.Iliq, e.Iddt, e.Nart }).HasName("PK__LQA__00B49D58C17A6515");

            entity.ToTable("LQA");

            entity.Property(e => e.Iliq)
                .HasMaxLength(17)
                .IsUnicode(false);
            entity.Property(e => e.Iddt)
                .HasMaxLength(17)
                .IsUnicode(false);
            entity.Property(e => e.Clqatax)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Clqatyp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Mlqa).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Mlqabas).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Qlqacoefic).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.IliqNavigation).WithMany(p => p.Lqas)
                .HasForeignKey(d => d.Iliq)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LQA__Iliq__3E52440B");

            entity.HasOne(d => d.Art).WithMany(p => p.Lqas)
                .HasForeignKey(d => new { d.Iddt, d.Nart })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LQA__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
