﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OOT.Database;

#nullable disable

namespace OOT.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OOT.Database.Entities.BirdEntity", b =>
                {
                    b.Property<long>("RingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RingId"));

                    b.Property<long>("ClassificationId")
                        .HasColumnType("bigint");

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.Property<long>("RingerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RingingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RingingLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RingId");

                    b.HasIndex("ClassificationId");

                    b.HasIndex("RingerId");

                    b.ToTable("Bird");
                });

            modelBuilder.Entity("OOT.Database.Entities.ClassEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SpeciesId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("OOT.Database.Entities.ClassificationEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Classification");
                });

            modelBuilder.Entity("OOT.Database.Entities.LocationEntity", b =>
                {
                    b.Property<long>("PostalCode")
                        .HasColumnType("bigint");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostalCode");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("OOT.Database.Entities.MemberEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint");

                    b.Property<long>("LocationPostalCode")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("MemberSince")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MemberUntil")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationPostalCode");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("OOT.Database.Entities.SpeciesEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ClassificationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClassificationId");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("OOT.Database.Entities.SubclassEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<string>("SubclassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Subclass");
                });

            modelBuilder.Entity("OOT.Database.Entities.TribeEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("SubclassId")
                        .HasColumnType("bigint");

                    b.Property<string>("TribeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubclassId");

                    b.ToTable("Tribe");
                });

            modelBuilder.Entity("OOT.Database.Entities.WatchingEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BirdRingId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MemberId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BirdRingId");

                    b.HasIndex("MemberId");

                    b.ToTable("Watching");
                });

            modelBuilder.Entity("OOT.Database.Entities.BirdEntity", b =>
                {
                    b.HasOne("OOT.Database.Entities.ClassificationEntity", "Classification")
                        .WithMany("Birds")
                        .HasForeignKey("ClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OOT.Database.Entities.MemberEntity", "Ringer")
                        .WithMany("RingedBirds")
                        .HasForeignKey("RingerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Classification");

                    b.Navigation("Ringer");
                });

            modelBuilder.Entity("OOT.Database.Entities.ClassEntity", b =>
                {
                    b.HasOne("OOT.Database.Entities.SpeciesEntity", "Species")
                        .WithMany("Classes")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Species");
                });

            modelBuilder.Entity("OOT.Database.Entities.MemberEntity", b =>
                {
                    b.HasOne("OOT.Database.Entities.LocationEntity", "Location")
                        .WithMany("Members")
                        .HasForeignKey("LocationPostalCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("OOT.Database.Entities.SpeciesEntity", b =>
                {
                    b.HasOne("OOT.Database.Entities.ClassificationEntity", "Classification")
                        .WithMany("Species")
                        .HasForeignKey("ClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classification");
                });

            modelBuilder.Entity("OOT.Database.Entities.SubclassEntity", b =>
                {
                    b.HasOne("OOT.Database.Entities.ClassEntity", "Class")
                        .WithMany("Subclasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("OOT.Database.Entities.TribeEntity", b =>
                {
                    b.HasOne("OOT.Database.Entities.SubclassEntity", "Subclass")
                        .WithMany("Tribes")
                        .HasForeignKey("SubclassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subclass");
                });

            modelBuilder.Entity("OOT.Database.Entities.WatchingEntity", b =>
                {
                    b.HasOne("OOT.Database.Entities.BirdEntity", "Bird")
                        .WithMany("Watchings")
                        .HasForeignKey("BirdRingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("OOT.Database.Entities.MemberEntity", "Member")
                        .WithMany("Watchings")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bird");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("OOT.Database.Entities.BirdEntity", b =>
                {
                    b.Navigation("Watchings");
                });

            modelBuilder.Entity("OOT.Database.Entities.ClassEntity", b =>
                {
                    b.Navigation("Subclasses");
                });

            modelBuilder.Entity("OOT.Database.Entities.ClassificationEntity", b =>
                {
                    b.Navigation("Birds");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("OOT.Database.Entities.LocationEntity", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("OOT.Database.Entities.MemberEntity", b =>
                {
                    b.Navigation("RingedBirds");

                    b.Navigation("Watchings");
                });

            modelBuilder.Entity("OOT.Database.Entities.SpeciesEntity", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("OOT.Database.Entities.SubclassEntity", b =>
                {
                    b.Navigation("Tribes");
                });
#pragma warning restore 612, 618
        }
    }
}
