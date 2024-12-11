using System;
using System.Collections.Generic;
using System.Text;

namespace LessonMonitor.Core
{
    public class CarImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int CarId { get; set; } // Внешний ключ
        public Car? Car { get; set; }   // Навигационное свойство
    }
}
