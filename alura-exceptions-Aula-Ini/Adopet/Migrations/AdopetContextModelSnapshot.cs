﻿// <auto-generated />
using Adopet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Adopet.Migrations
{
    [DbContext(typeof(AdopetContext))]
    partial class AdopetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("Adopet.Models.Adocao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Justificativa")
                        .HasColumnType("TEXT");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("PetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TutorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PetId")
                        .IsUnique();

                    b.HasIndex("TutorId");

                    b.ToTable("Adocoes");
                });

            modelBuilder.Entity("Adopet.Models.Pet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Adotado")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Idade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Adopet.Models.Tutor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tutores");
                });

            modelBuilder.Entity("Adopet.Models.Adocao", b =>
                {
                    b.HasOne("Adopet.Models.Pet", "Pet")
                        .WithOne("Adocao")
                        .HasForeignKey("Adopet.Models.Adocao", "PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Adopet.Models.Tutor", "Tutor")
                        .WithMany("Adocoes")
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("Adopet.Models.Pet", b =>
                {
                    b.Navigation("Adocao")
                        .IsRequired();
                });

            modelBuilder.Entity("Adopet.Models.Tutor", b =>
                {
                    b.Navigation("Adocoes");
                });
#pragma warning restore 612, 618
        }
    }
}