using System.Collections;
using System.Collections.Generic;

namespace LessonMonitor.Core
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<CarImage> CarImages { get; set; } = null;
    }
}
