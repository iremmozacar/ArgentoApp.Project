using System;
using ArgentoApp.Backend.Entity.Concrete.Abstact;
using Microsoft.EntityFrameworkCore;

namespace ArgentoApp.Backend.Data.Concrete.Configs
{
  public class ProductConfig : IEntityTypeConfiguration<Product>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Id)
      .ValueGeneratedOnAdd();

      builder.Property(x => x.Name)
      .IsRequired().
      HasMaxLength(100);

      builder.Property(x => x.Url)
      .IsRequired()
      .HasMaxLength(500);


      List<Product> products = [
      new()
                {
               Id=1,
              Name="Kırmızı Jasper",
              Price=100,
              Properties="Kırmızı Jasper",
              Url= "Jasper",
              ImageUrl="",
              IsHome=true,
              CreatedDate=DateTime.Now,
              ModifiedDate=DateTime.Now,
              IsActive=true,
              CategoryId=1
            },
            new()
                {
               Id=2,
              Name="Turuncu Kalsit",
              Price=200,
              Properties="Turuncu Kalsit",
              Url= "Kalsit",
              ImageUrl="",
              IsHome=true,
              CreatedDate=DateTime.Now,
              ModifiedDate=DateTime.Now,
              IsActive=true,
              CategoryId=2
            },
            new()
                {
               Id=3,
              Name="Kaplan Gözü ",
              Price=300,
              Properties="Kaplan Gözü",
              Url= "KaplanGozu",
              ImageUrl="",
              IsHome=true,
              CreatedDate=DateTime.Now,
              ModifiedDate=DateTime.Now,
              IsActive=true,
              CategoryId=3
            },
            new()
                {
               Id=4,
              Name="Moldavit",
              Price=400,
              Properties="Moldavit",
              Url= "Moldavit",
              ImageUrl="",
              IsHome=true,
              CreatedDate=DateTime.Now,
              ModifiedDate=DateTime.Now,
              IsActive=true,
              CategoryId=4
            },
            new()
                {
               Id=5,
              Name="Larimar",
              Price=500,
              Properties="Larimar",
              Url= "Larimar",
              ImageUrl="",
              IsHome=true,
              CreatedDate=DateTime.Now,
              ModifiedDate=DateTime.Now,
              IsActive=true,
              CategoryId=5
            },
            new()
                {
               Id=6,
              Name="Sodalit",
              Price=600,
              Properties="Sodalit",
              Url= "Sodalit",
              ImageUrl="",
              IsHome=true,
              CreatedDate=DateTime.Now,
              ModifiedDate=DateTime.Now,
              IsActive=true,
              CategoryId=3
            },
            new()
                {
               Id=7,
              Name="Kristal Kuvars",
              Price=700,
              Properties="Kristal Kuvars",
              Url= "KristalKuvars",
              ImageUrl="",
              IsHome=true,
              CreatedDate=DateTime.Now,
              ModifiedDate=DateTime.Now,
              IsActive=true,
              CategoryId=7
            },
         ];
      builder.HasData(products);
    }
  }
}
