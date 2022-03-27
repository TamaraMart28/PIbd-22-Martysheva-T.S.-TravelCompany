﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelCompanyDatabaseImplement;

namespace TravelCompanyDatabaseImplement.Migrations
{
    [DbContext(typeof(TravelCompanyDatabase))]
    partial class TravelCompanyDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelCompanyDatabaseImplement.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameResponsible")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TravelCompanyDatabaseImplement.Models.CompanyCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("ConditionId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ConditionId");

                    b.ToTable("CompanyConditions");
                });

            modelBuilder.Entity("TravelCompanyDatabaseImplement.Models.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConditionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("TravelCompanyDatabaseImplement.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateImplement")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TravelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TravelId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TravelCompanyDatabaseImplement.Models.Travel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TravelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("TravelCompanyDatabaseImplement.Models.TravelCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConditionId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("TravelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId");

                    b.HasIndex("TravelId");

                    b.ToTable("TravelConditions");
                });

            modelBuilder.Entity("TravelCompanyDatabaseImplement.Models.CompanyCondition", b =>
                {
                    b.HasOne("TravelCompanyDatabaseImplement.Models.Company", "Company")
                        .WithMany("CompanyConditions")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelCompanyDatabaseImplement.Models.Condition", "Condition")
                        .WithMany()
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Condition");
                });

            modelBuilder.Entity("TravelCompanyDatabaseImplement.Models.Order", b =>
                {
                    b.HasOne("TravelCompanyDatabaseImplement.Models.Travel", "Travel")
                        .WithMany("Orders")
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("TravelCompanyDatabaseImplement.Models.TravelCondition", b =>
                {
                    b.HasOne("TravelCompanyDatabaseImplement.Models.Condition", "Condition")
                        .WithMany("TravelConditions")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelCompanyDatabaseImplement.Models.Travel", "Travel")
                        .WithMany("TravelConditions")
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condition");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("TravelCompanyDatabaseImplement.Models.Company", b =>
                {
                    b.Navigation("CompanyConditions");
                });

            modelBuilder.Entity("TravelCompanyDatabaseImplement.Models.Condition", b =>
                {
                    b.Navigation("TravelConditions");
                });

            modelBuilder.Entity("TravelCompanyDatabaseImplement.Models.Travel", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("TravelConditions");
                });
#pragma warning restore 612, 618
        }
    }
}
