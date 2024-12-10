using System;
using System.Collections.Generic;
using System.Text;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class CarImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }  
    }
}
