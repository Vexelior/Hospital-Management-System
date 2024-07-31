﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Web.Data.Migrations.HospitalContext
{
    [DbContext(typeof(Infrastructure.Data.HospitalContext))]
    partial class HospitalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Core.Entities.DoctorPractice", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<int>("DoctorId1")
                        .HasColumnType("int");

                    b.Property<int>("PracticeId")
                        .HasColumnType("int");

                    b.HasKey("DoctorId");

                    b.HasIndex("DoctorId1");

                    b.HasIndex("PracticeId");

                    b.ToTable("DoctorPractice");
                });

            modelBuilder.Entity("Core.Entities.DoctorSpecialty", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<int>("DoctorId1")
                        .HasColumnType("int");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("int");

                    b.HasKey("DoctorId");

                    b.HasIndex("DoctorId1");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("DoctorSpecialty");
                });

            modelBuilder.Entity("Core.Entities.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Core.Entities.Practice", b =>
                {
                    b.Property<int>("PracticeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PracticeId"));

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PracticeId");

                    b.ToTable("Practice");
                });

            modelBuilder.Entity("Core.Entities.Specialty", b =>
                {
                    b.Property<int>("SpecialtyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecialtyId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecialtyId");

                    b.ToTable("Specialty");
                });

            modelBuilder.Entity("Core.Entities.DoctorPractice", b =>
                {
                    b.HasOne("Core.Entities.Doctor", "Doctor")
                        .WithMany("Practices")
                        .HasForeignKey("DoctorId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Practice", "Practice")
                        .WithMany("DoctorPractices")
                        .HasForeignKey("PracticeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Practice");
                });

            modelBuilder.Entity("Core.Entities.DoctorSpecialty", b =>
                {
                    b.HasOne("Core.Entities.Doctor", "Doctor")
                        .WithMany("Specialties")
                        .HasForeignKey("DoctorId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Specialty", "Specialty")
                        .WithMany("DoctorSpecialties")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("Core.Entities.Doctor", b =>
                {
                    b.Navigation("Practices");

                    b.Navigation("Specialties");
                });

            modelBuilder.Entity("Core.Entities.Practice", b =>
                {
                    b.Navigation("DoctorPractices");
                });

            modelBuilder.Entity("Core.Entities.Specialty", b =>
                {
                    b.Navigation("DoctorSpecialties");
                });
#pragma warning restore 612, 618
        }
    }
}