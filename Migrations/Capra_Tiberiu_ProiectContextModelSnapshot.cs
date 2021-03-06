﻿// <auto-generated />
using Capra_Tiberiu_Proiect.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Capra_Tiberiu_Proiect.Migrations
{
    [DbContext(typeof(Capra_Tiberiu_ProiectContext))]
    partial class Capra_Tiberiu_ProiectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Capra_Tiberiu_Proiect.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Capra_Tiberiu_Proiect.Models.Producator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NumeProducator")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Producator");
                });

            modelBuilder.Entity("Capra_Tiberiu_Proiect.Models.Telefon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Memorie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<int>("ProducatorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProducatorID");

                    b.ToTable("Telefon");
                });

            modelBuilder.Entity("Capra_Tiberiu_Proiect.Models.TelefonCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("TelefonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("TelefonID");

                    b.ToTable("TelefonCategory");
                });

            modelBuilder.Entity("Capra_Tiberiu_Proiect.Models.Telefon", b =>
                {
                    b.HasOne("Capra_Tiberiu_Proiect.Models.Producator", "Producator")
                        .WithMany("Telefoane")
                        .HasForeignKey("ProducatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Capra_Tiberiu_Proiect.Models.TelefonCategory", b =>
                {
                    b.HasOne("Capra_Tiberiu_Proiect.Models.Category", "Category")
                        .WithMany("TelefonCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Capra_Tiberiu_Proiect.Models.Telefon", "Telefon")
                        .WithMany("TelefonCategories")
                        .HasForeignKey("TelefonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
