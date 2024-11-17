using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.Core.Repositories
{
    public interface ICarsRepository
    {
            Task<List<Car>> GetAllCarsAsync();
            Task<Car> GetCarByIdAsync(int id);
            Task AddCarAsync(Car car);
            Task UpdateCarAsync(Car car);
            Task DeleteCarAsync(int id);
    }
}
