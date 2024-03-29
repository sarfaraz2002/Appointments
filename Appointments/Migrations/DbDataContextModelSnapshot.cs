﻿// <auto-generated />
using System;
using Appointments.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Appointments.Migrations
{
    [DbContext(typeof(DbDataContext))]
    partial class DbDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Appointments.Models.Address", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Appointments.Models.AppointmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("AppointmentTime")
                        .HasColumnType("time");

                    b.Property<string>("BloodGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiseaseType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("Appointments.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Specialist")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            DoctorId = 11,
                            Name = "Doctor1",
                            Phone = "111-111-1111",
                            Specialist = "Specialty1"
                        },
                        new
                        {
                            DoctorId = 12,
                            Name = "Doctor2",
                            Phone = "222-222-2222",
                            Specialist = "Specialty2"
                        },
                        new
                        {
                            DoctorId = 13,
                            Name = "Doctor3",
                            Phone = "333-333-3333",
                            Specialist = "Specialty3"
                        },
                        new
                        {
                            DoctorId = 14,
                            Name = "Doctor4",
                            Phone = "444-444-4444",
                            Specialist = "Specialty4"
                        },
                        new
                        {
                            DoctorId = 15,
                            Name = "Doctor5",
                            Phone = "555-555-5555",
                            Specialist = "Specialty5"
                        },
                        new
                        {
                            DoctorId = 16,
                            Name = "Doctor6",
                            Phone = "666-666-6666",
                            Specialist = "Specialty6"
                        },
                        new
                        {
                            DoctorId = 17,
                            Name = "Doctor7",
                            Phone = "777-777-7777",
                            Specialist = "Specialty7"
                        },
                        new
                        {
                            DoctorId = 18,
                            Name = "Doctor8",
                            Phone = "888-888-8888",
                            Specialist = "Specialty8"
                        },
                        new
                        {
                            DoctorId = 19,
                            Name = "Doctor9",
                            Phone = "999-999-9999",
                            Specialist = "Specialty9"
                        },
                        new
                        {
                            DoctorId = 20,
                            Name = "Doctor10",
                            Phone = "000-000-0000",
                            Specialist = "Specialty10"
                        });
                });

            modelBuilder.Entity("Appointments.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Appointments.Models.AppointmentModel", b =>
                {
                    b.HasOne("Appointments.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Appointments.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Doctor");
                });
#pragma warning restore 612, 618
        }
    }
}
