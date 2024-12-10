using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            // Указание имени таблицы
            builder.ToTable("Cars");

            // Первичный ключ
            builder.HasKey(c => c.Id);

            // Конфигурация свойств
            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Make)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Year)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(c => c.PricePerDay)
                .IsRequired()
                .HasPrecision(18, 4);

            builder.Property(c => c.IsAvailable)
                .IsRequired()
                .HasDefaultValue(false);

            // Индексы
            builder.HasIndex(c => c.Make);

            // Связь "Один-ко-многим" между Car и CarImage
            builder.HasMany(c => c.CarImages)
                .WithOne(ci => ci.Car)
                .HasForeignKey(ci => ci.CarId)
                .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление
        }
    }
}