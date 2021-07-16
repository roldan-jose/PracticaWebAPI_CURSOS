using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PracticaWebAPI_CURSOS.DAL.Entities
{
    public partial class CursosContext : IdentityDbContext
    {
        public CursosContext()
        {
        }

        public CursosContext(DbContextOptions<CursosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CursoModel> Cursos { get; set; }
        public virtual DbSet<EstudianteModel> Estudiantes { get; set; }
        public virtual DbSet<InscripcionCursoModel> InscripcionCursos { get; set; }
        public virtual DbSet<MatriculaModel> Matriculas { get; set; }
        public virtual DbSet<PeriodoModel> Periodos { get; set; }
        public virtual DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CursoModel>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Curso__085F27D60C4ACFD5");

                entity.ToTable("Curso");

                entity.Property(e => e.IdCurso).ValueGeneratedNever();

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstudianteModel>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("PK__Estudian__B5007C240EA71251");

                entity.ToTable("Estudiante");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreApellido)
                    .IsRequired()
                    .HasMaxLength(101)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(concat([Nombre],' ',[Apellido]))", false);
            });

            modelBuilder.Entity<InscripcionCursoModel>(entity =>
            {
                entity.HasKey(e => new { e.IdEstudiante, e.IdPeriodo, e.IdCurso })
                    .HasName("PK__Inscripc__994C4A9C73F0A5A5");

                entity.ToTable("InscripcionCurso");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.InscripcionCursos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inscripci__IdCur__412EB0B6");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.InscripcionCursos)
                    .HasForeignKey(d => new { d.IdEstudiante, d.IdPeriodo })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__InscripcionCurso__403A8C7D");
            });

            modelBuilder.Entity<MatriculaModel>(entity =>
            {
                entity.HasKey(e => new { e.IdEstudiante, e.IdPeriodo })
                    .HasName("PK__Matricul__4E4415BB5F78022F");

                entity.ToTable("Matricula");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matricula__IdEst__3E52440B");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matricula__IdPer__3F466844");
            });

            modelBuilder.Entity<PeriodoModel>(entity =>
            {
                entity.HasKey(e => e.IdPeriodo)
                    .HasName("PK__Periodo__B44699FE4ECB1D74");

                entity.ToTable("Periodo");

                entity.Property(e => e.IdPeriodo).ValueGeneratedNever();
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
