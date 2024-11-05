using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using ArgentoApp.Backend.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArgentoApp.Backend.Data.Concrete.Configs
{
  public class CategoryConfig : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id)
      .ValueGeneratedOnAdd();

      builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(100);

      builder.Property(x => x.Description)
      .IsRequired()
      .HasMaxLength(500);

      builder.Property(x => x.CreatedDate)
      .HasDefaultValueSql("date('now')");

      builder.Property(x => x.ModifiedDate)
      .HasDefaultValueSql("date('now')");

      List<Category> categories = [
      new()
            {
              Id=1,
              Name="1. Kök Çakra (Muladhara Çakra)",
              Description="Kök çakra ile uyumlu taşlar burada. Kırmızı renk ile ifade edilir.",
              IsActive=true,
              Url= "Kök",
            },
            new()
            {
              Id=2,
              Name="2.Sakral Çakra (Svadhistana Çakra)",
              Description="Sakral çakra ile uyumlu taşlar burada. Turuncu renk ile ifade edilir.",
              IsActive=true,
              Url= "Sakral",
            },
            new()
            {
              Id=3,
              Name="3. Solar Pleksus Çakra(Manipura Çakra)",
              Description="Solar Plexus çakra ile uyumlu taşlar burada. Sarı renk ile ifade edilir.",
              IsActive=true,
              Url= "SolarPlexus",
            },
             new()
            {
              Id=4,
              Name="4.Kalp Çakrası (Anahata Çakra)",
              Description="Kalp çakrası ile uyumlu taşlar burada. Yeşil renk ile ifade edilir.",
              IsActive=true,
              Url= "Kalp",
            },
            new()
            {
              Id=5,
              Name="5.Boğaz Çakrası (Vishuddha Çakra) ",
              Description="Boğaz çakrası ile uyumlu taşlar burada. Mavi renk ile ifade edilir.",
              IsActive=true,
              Url= "Boğaz",
            },
             new()
            {
              Id=6,
              Name="6.Üçüncü Göz Çakrası (Ajna Çakra)",
              Description="3.Göz çakrası ile uyumlu taşlar burada. İndigo mavi ile ifade edilir.",
              IsActive=true,
              Url= "3.Göz",
            },
             new()
            {
              Id=7,
              Name="7.Taç Çakra (Sahasrara Çakra)",
              Description="Taç çakra ile uyumlu taşlar burada. Menekşe rengi ile ifade edilir.",
              IsActive=true,
              Url= "Taç",
            },
         ];
      builder.HasData(categories);
    }
  }
}