using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    public class CarImageConfiguration : IEntityTypeConfiguration<CarImage>
    {
        public void Configure(EntityTypeBuilder<CarImage> builder)
        {
            // Указание имени таблицы
            builder.ToTable("CarImages");

            // Первичный ключ
            builder.HasKey(ci => ci.Id);

            // Конфигурация свойств
            builder.Property(ci => ci.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(ci => ci.ImageUrl)
                .IsRequired()
                .HasMaxLength(500); // Максимальная длина для URL

            builder.Property(ci => ci.CarId)
                .IsRequired();

            // Индексы
            builder.HasIndex(ci => ci.CarId);
        }
    }
}
