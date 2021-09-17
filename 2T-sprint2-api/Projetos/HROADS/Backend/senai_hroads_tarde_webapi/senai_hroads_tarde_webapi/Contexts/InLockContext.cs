using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_hroads_tarde_webapi.Domains;

#nullable disable

namespace senai_hroads_tarde_webapi.Contexts
{
    public partial class InLockContext : DbContext
    {
        public InLockContext()
        {
        }

        public InLockContext(DbContextOptions<InLockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<Classehabilidade> Classehabilidades { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<Tipohabilidade> Tipohabilidades { get; set; }
        public virtual DbSet<Tipousuario> Tipousuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NOTE0113A4\\SQLEXPRESS; initial catalog=HROADS; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__CLASSE__60FFF80169240BCA");

                entity.ToTable("CLASSE");

                entity.Property(e => e.IdClasse)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idClasse");

                entity.Property(e => e.NomeClasse)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomeClasse");
            });

            modelBuilder.Entity<Classehabilidade>(entity =>
            {
                entity.HasKey(e => e.IdClasseHabilidade)
                    .HasName("PK__CLASSEHA__5FC9697233DA77D4");

                entity.ToTable("CLASSEHABILIDADE");

                entity.Property(e => e.IdClasseHabilidade).HasColumnName("idClasseHabilidade");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Classehabilidades)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__CLASSEHAB__idCla__45F365D3");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.Classehabilidades)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__CLASSEHAB__idHab__46E78A0C");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__HABILIDA__655F75288C649172");

                entity.ToTable("HABILIDADE");

                entity.Property(e => e.IdHabilidade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idHabilidade");

                entity.Property(e => e.IdTipoHabilidade).HasColumnName("idTipoHabilidade");

                entity.Property(e => e.NomeHabilidade)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nomeHabilidade");

                entity.HasOne(d => d.IdTipoHabilidadeNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipoHabilidade)
                    .HasConstraintName("FK__HABILIDAD__idTip__403A8C7D");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__PERSONAG__E175C72E3F017BAE");

                entity.ToTable("PERSONAGEM");

                entity.Property(e => e.IdPersonagem).HasColumnName("idPersonagem");

                entity.Property(e => e.CapacidadeMaxMana).HasColumnName("capacidadeMaxMana");

                entity.Property(e => e.CapacidadeMaxVida).HasColumnName("capacidadeMaxVida");

                entity.Property(e => e.DataAtualizacao)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dataAtualizacao");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dataCriacao");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.NomePersonagem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomePersonagem");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__PERSONAGE__idCla__4316F928");
            });

            modelBuilder.Entity<Tipohabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipoHabilidade)
                    .HasName("PK__TIPOHABI__B197B832031D40D4");

                entity.ToTable("TIPOHABILIDADE");

                entity.Property(e => e.IdTipoHabilidade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoHabilidade");

                entity.Property(e => e.NomeTipoHabilidade)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoHabilidade");
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPOUSUA__03006BFF8F07945A");

                entity.ToTable("TIPOUSUARIO");

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__645723A609AAE36F");

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Email, "UQ__USUARIO__AB6E6164C3F608C2")
                    .IsUnique();

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIO__idTipoU__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
