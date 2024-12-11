using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    public class CarImageConfiguration : IEntityTypeConfiguration<CarImage>
    {
        public void Configure(EntityTypeBuilder<CarImage> builder)
        {
            builder.ToTable("CarImages");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(ci => ci.ImageUrl)
                .IsRequired()
                .HasMaxLength(500); 

            builder.Property(ci => ci.CarId)
                .IsRequired();

            builder.HasIndex(ci => ci.CarId);
        }
    }
}
