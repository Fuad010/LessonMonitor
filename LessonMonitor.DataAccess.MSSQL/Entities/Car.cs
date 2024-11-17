using System;
using System.Collections.Generic;
using System.Text;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
    }
}
