﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using efcoreapp.Data;

#nullable disable

namespace efcoreapp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("efcoreapp.Data.Bootcamp", b =>
                {
                    b.Property<int>("BootcampId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Baslik")
                        .HasColumnType("TEXT");

                    b.Property<int>("OgretmenId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BootcampId");

                    b.HasIndex("OgretmenId");

                    b.ToTable("Bootcamps");
                });

            modelBuilder.Entity("efcoreapp.Data.BootcampKayit", b =>
                {
                    b.Property<int>("KayitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BootcampId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KayitId");

                    b.HasIndex("BootcampId");

                    b.HasIndex("OgrenciId");

                    b.ToTable("KursKayitlari");
                });

            modelBuilder.Entity("efcoreapp.Data.Ogrenci", b =>
                {
                    b.Property<int>("OgrenciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Eposta")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrenciAd")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrenciSoyad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("OgrenciId");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("efcoreapp.Data.Ogretmen", b =>
                {
                    b.Property<int>("OgretmenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ad")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BaslamaTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Eposta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Soyad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("OgretmenId");

                    b.ToTable("Ogretmenler");
                });

            modelBuilder.Entity("efcoreapp.Data.Bootcamp", b =>
                {
                    b.HasOne("efcoreapp.Data.Ogretmen", "Ogretmen")
                        .WithMany("Bootcamps")
                        .HasForeignKey("OgretmenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ogretmen");
                });

            modelBuilder.Entity("efcoreapp.Data.BootcampKayit", b =>
                {
                    b.HasOne("efcoreapp.Data.Bootcamp", "Bootcamp")
                        .WithMany("KursKayitlari")
                        .HasForeignKey("BootcampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("efcoreapp.Data.Ogrenci", "Ogrenci")
                        .WithMany("KursKayitlari")
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bootcamp");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("efcoreapp.Data.Bootcamp", b =>
                {
                    b.Navigation("KursKayitlari");
                });

            modelBuilder.Entity("efcoreapp.Data.Ogrenci", b =>
                {
                    b.Navigation("KursKayitlari");
                });

            modelBuilder.Entity("efcoreapp.Data.Ogretmen", b =>
                {
                    b.Navigation("Bootcamps");
                });
#pragma warning restore 612, 618
        }
    }
}
