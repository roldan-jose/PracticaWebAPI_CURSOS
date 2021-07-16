﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticaWebAPI_CURSOS.DAL.Entities;

namespace PracticaWebAPI_CURSOS.Migrations
{
    [DbContext(typeof(CursosContext))]
    partial class CursosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PracticaWebAPI_CURSOS.DAL.Entities.CursoModel", b =>
                {
                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("Estado")
                        .HasColumnType("bit");

                    b.HasKey("IdCurso")
                        .HasName("PK__Curso__085F27D60C4ACFD5");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("PracticaWebAPI_CURSOS.DAL.Entities.EstudianteModel", b =>
                {
                    b.Property<int>("IdEstudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime?>("FechaNacimiento")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NombreApellido")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(101)
                        .IsUnicode(false)
                        .HasColumnType("varchar(101)")
                        .HasComputedColumnSql("(concat([Nombre],' ',[Apellido]))", false);

                    b.HasKey("IdEstudiante")
                        .HasName("PK__Estudian__B5007C240EA71251");

                    b.ToTable("Estudiante");
                });

            modelBuilder.Entity("PracticaWebAPI_CURSOS.DAL.Entities.InscripcionCursoModel", b =>
                {
                    b.Property<int>("IdEstudiante")
                        .HasColumnType("int");

                    b.Property<int>("IdPeriodo")
                        .HasColumnType("int");

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime");

                    b.HasKey("IdEstudiante", "IdPeriodo", "IdCurso")
                        .HasName("PK__Inscripc__994C4A9C73F0A5A5");

                    b.HasIndex("IdCurso");

                    b.HasIndex("IdPeriodo");

                    b.ToTable("InscripcionCurso");
                });

            modelBuilder.Entity("PracticaWebAPI_CURSOS.DAL.Entities.MatriculaModel", b =>
                {
                    b.Property<int>("IdEstudiante")
                        .HasColumnType("int");

                    b.Property<int>("IdPeriodo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime");

                    b.HasKey("IdEstudiante", "IdPeriodo")
                        .HasName("PK__Matricul__4E4415BB5F78022F");

                    b.HasIndex("IdPeriodo");

                    b.ToTable("Matricula");
                });

            modelBuilder.Entity("PracticaWebAPI_CURSOS.DAL.Entities.PeriodoModel", b =>
                {
                    b.Property<int>("IdPeriodo")
                        .HasColumnType("int");

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.HasKey("IdPeriodo")
                        .HasName("PK__Periodo__B44699FE4ECB1D74");

                    b.ToTable("Periodo");
                });

            modelBuilder.Entity("PracticaWebAPI_CURSOS.DAL.Entities.UsuarioModel", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SAL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PracticaWebAPI_CURSOS.DAL.Entities.InscripcionCursoModel", b =>
                {
                    b.HasOne("PracticaWebAPI_CURSOS.DAL.Entities.CursoModel", "IdCursoNavigation")
                        .WithMany("InscripcionCursos")
                        .HasForeignKey("IdCurso")
                        .HasConstraintName("FK__Inscripci__IdCur__412EB0B6")
                        .IsRequired();

                    b.HasOne("PracticaWebAPI_CURSOS.DAL.Entities.EstudianteModel", "EstudianteM")
                        .WithMany()
                        .HasForeignKey("IdEstudiante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracticaWebAPI_CURSOS.DAL.Entities.PeriodoModel", "PeriodoM")
                        .WithMany()
                        .HasForeignKey("IdPeriodo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracticaWebAPI_CURSOS.DAL.Entities.MatriculaModel", "Id")
                        .WithMany("InscripcionCursos")
                        .HasForeignKey("IdEstudiante", "IdPeriodo")
                        .HasConstraintName("FK__InscripcionCurso__403A8C7D")
                        .IsRequired();

                    b.Navigation("EstudianteM");

                    b.Navigation("Id");

                    b.Navigation("IdCursoNavigation");

                    b.Navigation("PeriodoM");
                });

            modelBuilder.Entity("PracticaWebAPI_CURSOS.DAL.Entities.MatriculaModel", b =>
                {
                    b.HasOne("PracticaWebAPI_CURSOS.DAL.Entities.EstudianteModel", "IdEstudianteNavigation")
                        .WithMany("Matriculas")
                        .HasForeignKey("IdEstudiante")
                        .HasConstraintName("FK__Matricula__IdEst__3E52440B")
                        .IsRequired();

                    b.HasOne("PracticaWebAPI_CURSOS.DAL.Entities.PeriodoModel", "IdPeriodoNavigation")
                        .WithMany("Matriculas")
                        .HasForeignKey("IdPeriodo")
                        .HasConstraintName("FK__Matricula__IdPer__3F466844")
                        .IsRequired();

                    b.Navigation("IdEstudianteNavigation");

                    b.Navigation("IdPeriodoNavigation");
                });

            modelBuilder.Entity("PracticaWebAPI_CURSOS.DAL.Entities.CursoModel", b =>
                {
                    b.Navigation("InscripcionCursos");
                });

            modelBuilder.Entity("PracticaWebAPI_CURSOS.DAL.Entities.EstudianteModel", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("PracticaWebAPI_CURSOS.DAL.Entities.MatriculaModel", b =>
                {
                    b.Navigation("InscripcionCursos");
                });

            modelBuilder.Entity("PracticaWebAPI_CURSOS.DAL.Entities.PeriodoModel", b =>
                {
                    b.Navigation("Matriculas");
                });
#pragma warning restore 612, 618
        }
    }
}
