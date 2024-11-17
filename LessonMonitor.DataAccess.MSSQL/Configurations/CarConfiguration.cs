using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            // Указание имени таблицы в базе данных
            builder.ToTable("Cars");

            // Указание первичного ключа
            builder.HasKey(c => c.Id);

            // Конфигурация свойств
            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Автоинкремент (генерация значений при добавлении)

            builder.Property(c => c.Make)
                .IsRequired()
                .HasMaxLength(100); // Установка максимальной длины для поля "Make"

            builder.Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(100); // Установка максимальной длины для поля "Model"

            builder.Property(c => c.Year)
                .IsRequired()
                .HasDefaultValue(0); // Установка значения по умолчанию для "Year"

            builder.Property(c => c.PricePerDay)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Указание типа данных "decimal" с точностью 18,2

            builder.Property(c => c.IsAvailable)
                .IsRequired()
                .HasDefaultValue(true); // Установка значения по умолчанию для "IsAvailable"

            // Настройка индексов, если это необходимо
            builder.HasIndex(c => c.Make); // Индекс по столбцу "Make" для быстрого поиска

            // Опционально: определение связей с другими сущностями (если они есть)
            // Пример связи с другой сущностью:
            // builder.HasOne(c => c.SomeOtherEntity)
            //        .WithMany()
            //        .HasForeignKey(c => c.SomeForeignKey);
        }
    }
}
